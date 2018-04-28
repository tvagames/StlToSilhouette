namespace StlToSilhouette
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rootDirInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fileListInput = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.framePanel = new System.Windows.Forms.Panel();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.zoomInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.underWaterInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.transparentInput = new System.Windows.Forms.CheckBox();
            this.colorInput = new System.Windows.Forms.TextBox();
            this.colorHelper = new System.Windows.Forms.Button();
            this.colorSample = new System.Windows.Forms.Label();
            this.progresText = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.fontSample1 = new System.Windows.Forms.Label();
            this.fontHelper = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.fontSample2 = new System.Windows.Forms.Label();
            this.fontHepler2 = new System.Windows.Forms.Button();
            this.outputDirInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.polygonCount = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.framePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.underWaterInput)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootDirInput
            // 
            this.rootDirInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootDirInput.Location = new System.Drawing.Point(89, 12);
            this.rootDirInput.Name = "rootDirInput";
            this.rootDirInput.Size = new System.Drawing.Size(792, 19);
            this.rootDirInput.TabIndex = 0;
            this.rootDirInput.TextChanged += new System.EventHandler(this.rootDirInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "FtD folder";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(887, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileListInput
            // 
            this.fileListInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileListInput.FormattingEnabled = true;
            this.fileListInput.ItemHeight = 12;
            this.fileListInput.Location = new System.Drawing.Point(16, 154);
            this.fileListInput.Name = "fileListInput";
            this.fileListInput.Size = new System.Drawing.Size(201, 364);
            this.fileListInput.TabIndex = 3;
            this.fileListInput.SelectedIndexChanged += new System.EventHandler(this.fileListInput_SelectedIndexChanged);
            // 
            // framePanel
            // 
            this.framePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.framePanel.AutoScroll = true;
            this.framePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.framePanel.Controls.Add(this.canvas);
            this.framePanel.Location = new System.Drawing.Point(223, 151);
            this.framePanel.Name = "framePanel";
            this.framePanel.Size = new System.Drawing.Size(698, 455);
            this.framePanel.TabIndex = 4;
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(100, 50);
            this.canvas.TabIndex = 11;
            this.canvas.TabStop = false;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progress.Location = new System.Drawing.Point(16, 545);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(201, 23);
            this.progress.TabIndex = 5;
            // 
            // zoomInput
            // 
            this.zoomInput.Location = new System.Drawing.Point(89, 62);
            this.zoomInput.Name = "zoomInput";
            this.zoomInput.Size = new System.Drawing.Size(60, 19);
            this.zoomInput.TabIndex = 6;
            this.zoomInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.zoomInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "zoom (px/m)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "under water (m)";
            // 
            // underWaterInput
            // 
            this.underWaterInput.Location = new System.Drawing.Point(274, 62);
            this.underWaterInput.Name = "underWaterInput";
            this.underWaterInput.Size = new System.Drawing.Size(60, 19);
            this.underWaterInput.TabIndex = 6;
            this.underWaterInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "background color";
            // 
            // transparentInput
            // 
            this.transparentInput.AutoSize = true;
            this.transparentInput.Location = new System.Drawing.Point(607, 64);
            this.transparentInput.Name = "transparentInput";
            this.transparentInput.Size = new System.Drawing.Size(82, 16);
            this.transparentInput.TabIndex = 7;
            this.transparentInput.Text = "transparent";
            this.transparentInput.UseVisualStyleBackColor = true;
            this.transparentInput.CheckedChanged += new System.EventHandler(this.transparentInput_CheckedChanged);
            // 
            // colorInput
            // 
            this.colorInput.Enabled = false;
            this.colorInput.Location = new System.Drawing.Point(451, 61);
            this.colorInput.Name = "colorInput";
            this.colorInput.ReadOnly = true;
            this.colorInput.Size = new System.Drawing.Size(62, 19);
            this.colorInput.TabIndex = 8;
            // 
            // colorHelper
            // 
            this.colorHelper.Location = new System.Drawing.Point(556, 62);
            this.colorHelper.Name = "colorHelper";
            this.colorHelper.Size = new System.Drawing.Size(34, 19);
            this.colorHelper.TabIndex = 2;
            this.colorHelper.Text = "...";
            this.colorHelper.UseVisualStyleBackColor = true;
            this.colorHelper.Click += new System.EventHandler(this.colorHelper_Click);
            // 
            // colorSample
            // 
            this.colorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorSample.Location = new System.Drawing.Point(520, 61);
            this.colorSample.Name = "colorSample";
            this.colorSample.Size = new System.Drawing.Size(30, 20);
            this.colorSample.TabIndex = 9;
            // 
            // progresText
            // 
            this.progresText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progresText.AutoSize = true;
            this.progresText.Location = new System.Drawing.Point(14, 530);
            this.progresText.Name = "progresText";
            this.progresText.Size = new System.Drawing.Size(49, 12);
            this.progresText.TabIndex = 1;
            this.progresText.Text = "progress";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "font1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontSample1
            // 
            this.fontSample1.AutoSize = true;
            this.fontSample1.Location = new System.Drawing.Point(114, 0);
            this.fontSample1.Name = "fontSample1";
            this.fontSample1.Size = new System.Drawing.Size(135, 12);
            this.fontSample1.TabIndex = 1;
            this.fontSample1.Text = "ABC-012 戦艦あいうアイウ";
            // 
            // fontHelper
            // 
            this.fontHelper.Location = new System.Drawing.Point(74, 3);
            this.fontHelper.Name = "fontHelper";
            this.fontHelper.Size = new System.Drawing.Size(34, 19);
            this.fontHelper.TabIndex = 2;
            this.fontHelper.Text = "...";
            this.fontHelper.UseVisualStyleBackColor = true;
            this.fontHelper.Click += new System.EventHandler(this.fontHelper_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(255, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "font2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fontSample2
            // 
            this.fontSample2.AutoSize = true;
            this.fontSample2.Location = new System.Drawing.Point(372, 0);
            this.fontSample2.Name = "fontSample2";
            this.fontSample2.Size = new System.Drawing.Size(135, 12);
            this.fontSample2.TabIndex = 1;
            this.fontSample2.Text = "ABC-012 戦艦あいうアイウ";
            // 
            // fontHepler2
            // 
            this.fontHepler2.Location = new System.Drawing.Point(332, 3);
            this.fontHepler2.Name = "fontHepler2";
            this.fontHepler2.Size = new System.Drawing.Size(34, 19);
            this.fontHepler2.TabIndex = 2;
            this.fontHepler2.Text = "...";
            this.fontHepler2.UseVisualStyleBackColor = true;
            this.fontHepler2.Click += new System.EventHandler(this.fontHepler2_Click);
            // 
            // outputDirInput
            // 
            this.outputDirInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirInput.Location = new System.Drawing.Point(89, 37);
            this.outputDirInput.Name = "outputDirInput";
            this.outputDirInput.Size = new System.Drawing.Size(792, 19);
            this.outputDirInput.TabIndex = 0;
            this.outputDirInput.TextChanged += new System.EventHandler(this.rootDirInput_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "output folder";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(887, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 19);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // polygonCount
            // 
            this.polygonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.polygonCount.AutoSize = true;
            this.polygonCount.Location = new System.Drawing.Point(14, 581);
            this.polygonCount.Name = "polygonCount";
            this.polygonCount.Size = new System.Drawing.Size(57, 12);
            this.polygonCount.TabIndex = 1;
            this.polygonCount.Text = "Polygons: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.fontHelper);
            this.flowLayoutPanel1.Controls.Add(this.fontSample1);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.fontHepler2);
            this.flowLayoutPanel1.Controls.Add(this.fontSample2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 87);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(906, 58);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 618);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.colorSample);
            this.Controls.Add(this.colorInput);
            this.Controls.Add(this.transparentInput);
            this.Controls.Add(this.underWaterInput);
            this.Controls.Add(this.zoomInput);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.framePanel);
            this.Controls.Add(this.fileListInput);
            this.Controls.Add(this.colorHelper);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.polygonCount);
            this.Controls.Add(this.progresText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputDirInput);
            this.Controls.Add(this.rootDirInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "stl to silhouette for windows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.framePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.underWaterInput)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rootDirInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox fileListInput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel framePanel;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.NumericUpDown zoomInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown underWaterInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox transparentInput;
        private System.Windows.Forms.TextBox colorInput;
        private System.Windows.Forms.Button colorHelper;
        private System.Windows.Forms.Label colorSample;
        private System.Windows.Forms.Label progresText;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label fontSample1;
        private System.Windows.Forms.Button fontHelper;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label fontSample2;
        private System.Windows.Forms.Button fontHepler2;
        private System.Windows.Forms.TextBox outputDirInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label polygonCount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

