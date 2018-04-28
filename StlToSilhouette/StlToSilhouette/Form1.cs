using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StlToSilhouette
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private StlFile currentStl = new StlFile();

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.rootDirInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.outputDirInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void colorHelper_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var c = this.colorDialog1.Color;
                var s = string.Format("{0:x2}{1:x2}{2:x2}", c.R, c.G, c.B);
                this.colorInput.Text = s;
                this.colorSample.BackColor = c;
            }
        }

        private void transparentInput_CheckedChanged(object sender, EventArgs e)
        {
            this.colorInput.Enabled = !this.transparentInput.Checked;
            this.colorHelper.Enabled = !this.transparentInput.Checked;
        }

        private void rootDirInput_TextChanged(object sender, EventArgs e)
        {
            var di = new DirectoryInfo(this.rootDirInput.Text);
            if (!di.Exists)
            {
                return;
            }

            this.fileListInput.Items.Clear();
            foreach (var file in di.GetFiles("*.stl"))
            {
                this.fileListInput.Items.Add(file.Name);
            }
        }

        private void fileListInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.fileListInput.SelectedIndex == -1)
                {
                    return;
                }
                var path = Path.Combine(this.rootDirInput.Text, this.fileListInput.SelectedItem.ToString());
                var imgPath = Path.Combine(this.outputDirInput.Text, this.fileListInput.SelectedItem.ToString() + ".bmp");

                var font1 = this.fontSample1.Font;
                var font2 = this.fontSample2.Font;
                var isTransparent = this.transparentInput.Checked;
                var backColor = this.colorSample.BackColor;
                decimal underWater = this.underWaterInput.Value;
                decimal zoom = this.zoomInput.Value;

                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    currentStl.Load(path, font1, font2, backColor, isTransparent, underWater, zoom);

                }).ContinueWith(r => 
                {
                    this.canvas.Width = this.currentStl.Bitmap.Width;
                    this.canvas.Height = this.currentStl.Bitmap.Height;
                    this.canvas.Image = this.currentStl.Bitmap;
                    if (isTransparent)
                    {
                        this.currentStl.Bitmap.MakeTransparent(backColor);
                    }
                    this.currentStl.Bitmap.Save(imgPath, System.Drawing.Imaging.ImageFormat.Png);
                    this.fileListInput.SelectedIndex = -1;
                    this.polygonCount.Text = string.Format("Polygons: {0:###,###,###}", this.currentStl.PolygonCount);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fontHelper_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.fontSample1.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fontSample1.Font = this.fontDialog1.Font;
            }
        }

        private void fontHepler2_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.fontSample2.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fontSample2.Font = this.fontDialog1.Font;
            }
        }

        private Config config = new Config();
        private void Form1_Load(object sender, EventArgs e)
        {
            var cnv = new FontConverter();

            var c = Config.Load();
            if (c == null)
            {
                c = new Config()
                {
                    BackColor = "ffffff",
                    Font1 = cnv.ConvertToString(this.fontSample1.Font),
                    Font2 = cnv.ConvertToString(this.fontSample2.Font),
                    IsTransparent = false,
                    RootDir = "",
                    OutputDir = "",
                    UnderWater = 0,
                    Zoom = 5
                };
            }
            this.config = c;
            this.rootDirInput.Text = this.config.RootDir;
            this.outputDirInput.Text = this.config.OutputDir;
            this.zoomInput.Value = this.config.Zoom;
            this.underWaterInput.Value = this.config.UnderWater;
            this.colorInput.Text = this.config.BackColor;
            var r = Convert.ToInt32(this.config.BackColor.Substring(0, 2), 16);
            var g = Convert.ToInt32(this.config.BackColor.Substring(2, 2), 16);
            var b = Convert.ToInt32(this.config.BackColor.Substring(4, 2), 16);
            this.colorSample.BackColor = Color.FromArgb(r, g, b);
            this.colorInput.Text = this.config.BackColor;

            this.transparentInput.Checked = this.config.IsTransparent;
            try
            {
                this.fontSample1.Font = (Font)cnv.ConvertFromString(this.config.Font1);
                this.fontSample2.Font = (Font)cnv.ConvertFromString(this.config.Font2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.currentStl.ProgressChanged += CurrentStl_ProgressChanged;
        }

        private void CurrentStl_ProgressChanged(long value, long max, decimal rate)
        {
            this.Invoke(new Action(() => {
                this.progress.Maximum = (int)max;
                this.progress.Value = (int)value;
            }));
            System.Threading.Thread.Sleep(1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var cnv = new FontConverter();

            this.config.RootDir = this.rootDirInput.Text;
            this.config.OutputDir = this.outputDirInput.Text;
            this.config.Zoom = this.zoomInput.Value;
            this.config.UnderWater = this.underWaterInput.Value;
            this.config.BackColor = this.colorInput.Text;
            this.config.IsTransparent = this.transparentInput.Checked;
            this.config.Font1 = cnv.ConvertToString(this.fontSample1.Font);
            this.config.Font2 = cnv.ConvertToString(this.fontSample2.Font);
            this.config.Save();
        }

    }
}
