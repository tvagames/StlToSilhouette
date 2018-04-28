using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StlToSilhouette
{
    class StlFile
    {
        public List<Vertex> vertexList { get; set; }
        public Bitmap Bitmap { get; set; }
        public delegate void ProgressHandler(long value,long max, decimal rate);
        public event ProgressHandler ProgressChanged;
        public int PolygonCount { get; set; }
        protected void OnProgressChanged(long value, long max, decimal rate)
        {
            if (this.ProgressChanged != null)
            {
                ProgressChanged(value, max, rate);
            }
        }

        private float ToNum(string value)
        {
            var f = value.Split('e');
            return Convert.ToSingle(f[0]) * (float)Math.Pow(10, Convert.ToSingle(f[1]));
        }

        public void Load(string filePath, Font font1, Font font2, Color backColor, bool isTransparent, decimal underWater, decimal zoom)
        {
            var rowNumber = 1;
            var line = "";
            try
            {
                this.PolygonCount = 0;
                bool[] sw = new bool[] { false, false, false, false, false, false };
                var maxVertex = new Vertex();
                var minVertex = new Vertex();
                var percent = 0;
                var f = new FileInfo(filePath);
                using (var sr = new StreamReader(filePath))
                {
                    long currentByte = 0;
                    OnProgressChanged(0, 100, 0.5m);
                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine();
                        if (line.StartsWith("vertex"))
                        {
                            var factor = line.Split(' ');
                            var x = ToNum(factor[1]);
                            var y = ToNum(factor[2]);
                            var z = ToNum(factor[3]);
                            if (!sw[0] || minVertex.x > x){ minVertex.x = x;  sw[0] = true; }
                            if (!sw[1] || minVertex.y > y) { minVertex.y = y; sw[1] = true; }
                            if (!sw[2] || minVertex.z > z) { minVertex.z = z; sw[2] = true; }
                            if (!sw[3] || maxVertex.x < x) { maxVertex.x = x; sw[3] = true; }
                            if (!sw[4] || maxVertex.y < y) { maxVertex.y = y; sw[4] = true; }
                            if (!sw[5] || maxVertex.z < z) { maxVertex.z = z; sw[5] = true; }
                        }

                        rowNumber++;
                        currentByte += line.Length + 2;
                        if (percent != (int)((decimal)currentByte / (decimal)f.Length * 100))
                        {
                            percent = (int)((decimal)currentByte / (decimal)f.Length * 100);
                            OnProgressChanged(percent, 200, 0.5m);
                        }
                    }
                }

                var zoomX = (int)zoom;
                var zoomY = (int)zoom;
                var margin = 10;

                var vw = Math.Abs(maxVertex.x - minVertex.x);
                var vh = Math.Abs(maxVertex.y - minVertex.y);
                var vl = Math.Abs(maxVertex.z - minVertex.z);
                var w = vl + vw + margin * 4;
                var h = vh + vw + margin * 4;

                int canvaswidth = Convert.ToInt32(w * zoomX);
                int canvasheight = Convert.ToInt32(h * zoomY);
                var fi = new FileInfo(filePath);
                var filename = fi.Name;
                var fn = filename.Substring(0, filename.Length - 31);

                using (var bmp = new System.Drawing.Bitmap(canvaswidth, canvasheight))
                {
                    var g = System.Drawing.Graphics.FromImage(bmp);
                    var size1 = g.MeasureString(fn, font1);
                    var size2 = g.MeasureString("W:000.0m", font2);
                    var maxTextWidth = Math.Max(size1.Width, size2.Width);
                    if (vw < maxTextWidth)
                    {
                        canvaswidth += (int)(maxTextWidth - vw);
                    }
                }


                var topOffsetX = margin;
                var topOffsetY = vw + margin;
                var sideOffsetX = topOffsetX;
                var sideOffsetY = vw + vh + margin * 3;
                var frontOffsetX = vl + margin * 3;
                var frontOffsetY = sideOffsetY;
                using (var sr = new StreamReader(filePath))
                {
                    long currentByte = 0;

                    var bmp = new System.Drawing.Bitmap(canvaswidth, canvasheight);
                    this.Bitmap = bmp;
                    var g = System.Drawing.Graphics.FromImage(bmp);
                    var list = new List<Polygon>();
                    var temp = new Polygon();
                    var flg = 0;
                    percent = 0;
                    
                    g.FillRectangle(new SolidBrush(backColor), 0, 0, bmp.Width, bmp.Height);

                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine();
                        if (line.StartsWith("outer"))
                        {
                            temp.vertexs = new Vertex[3];
                            flg = 1;
                        }
                        else if (line.StartsWith("vertex"))
                        {
                            var factor = line.Split(' ');
                            temp.vertexs[flg - 1] = new Vertex()
                            {
                                x = ToNum(factor[1]),
                                y = ToNum(factor[2]),
                                z = ToNum(factor[3]),
                            };
                            flg++;
                        }
                        else if (line.StartsWith("endloop"))
                        {
                            this.PolygonCount++;
                            g.FillPolygon(System.Drawing.Brushes.Black, new System.Drawing.PointF[]
                            {
                                new System.Drawing.PointF(
                                    (temp.vertexs[0].z + topOffsetX + (minVertex.z * -1)) * zoomX,
                                    ((temp.vertexs[0].x + (minVertex.x * -1)) * -1 + topOffsetY) * zoomY),
                                new System.Drawing.PointF(
                                    (temp.vertexs[1].z + topOffsetX + (minVertex.z * -1)) * zoomX,
                                    ((temp.vertexs[1].x + (minVertex.x * -1)) * -1 + topOffsetY) * zoomY),
                                new System.Drawing.PointF(
                                    (temp.vertexs[2].z + topOffsetX + (minVertex.z * -1)) * zoomX,
                                    ((temp.vertexs[2].x + (minVertex.x * -1)) * -1 + topOffsetY) * zoomY)
                            });

                            g.FillPolygon(System.Drawing.Brushes.Black, new System.Drawing.PointF[]
                            {
                                new System.Drawing.PointF(
                                    (temp.vertexs[0].z + sideOffsetX + (minVertex.z * -1)) * zoomX,
                                    ((temp.vertexs[0].y + (minVertex.y * -1)) * -1 + sideOffsetY) * zoomY),
                                new System.Drawing.PointF(
                                    (temp.vertexs[1].z + sideOffsetX + (minVertex.z * -1)) * zoomX,
                                    ((temp.vertexs[1].y + (minVertex.y * -1)) * -1 + sideOffsetY) * zoomY),
                                new System.Drawing.PointF(
                                    (temp.vertexs[2].z + sideOffsetX + (minVertex.z * -1)) * zoomX,
                                    ((temp.vertexs[2].y + (minVertex.y * -1)) * -1 + sideOffsetY) * zoomY)
                            });

                            g.FillPolygon(System.Drawing.Brushes.Black, new System.Drawing.PointF[]
                            {
                                new System.Drawing.PointF(
                                    (temp.vertexs[0].x + frontOffsetX + (minVertex.x * -1)) * zoomX,
                                    ((temp.vertexs[0].y + (minVertex.y * -1)) * -1 + frontOffsetY) * zoomY),
                                new System.Drawing.PointF(
                                    (temp.vertexs[1].x + frontOffsetX + (minVertex.x * -1)) * zoomX,
                                    ((temp.vertexs[1].y + (minVertex.y * -1)) * -1 + frontOffsetY) * zoomY),
                                new System.Drawing.PointF(
                                    (temp.vertexs[2].x + frontOffsetX + (minVertex.x * -1)) * zoomX,
                                    ((temp.vertexs[2].y + (minVertex.y * -1)) * -1 + frontOffsetY) * zoomY)
                            });

                            flg = 0;
                        }
                        currentByte += line.Length + 2;
                        if (percent != (int)((decimal)currentByte / (decimal)f.Length * 100))
                        {
                            percent = (int)((decimal)currentByte / (decimal)f.Length * 100);
                            OnProgressChanged(percent + 100, 200, 0.5m);
                        }
                    }

                    // underwater
                    if (underWater > 0)
                    {
                        g.FillRectangle(new SolidBrush(backColor), 0, (sideOffsetY - (float)underWater) * zoomY, bmp.Width, (float)underWater * zoomY);
                    }


                    // text
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    var size1 = g.MeasureString(fn, font1);
                    var size2 = g.MeasureString("Length:0000.0m", font2);
                    var size3 = g.MeasureString("0000.0m", font2);
                    var size4 = g.MeasureString("Length:", font2);
                    var sizeTextOffset = frontOffsetX * zoomX;
                    if (size1.Width > size2.Width)
                    {
                        sizeTextOffset += size1.Width - size2.Width;
                    }
                    g.DrawString(fn, font1, Brushes.Black, frontOffsetX * zoomX, (margin) * zoomY);

                    g.DrawString("Width:", font2, Brushes.Black, sizeTextOffset, (margin) * zoomY + font1.Height + font2.Height * 0);
                    var s = string.Format("{0:0.0}m", (Math.Round(vw * 10) / 10));
                    g.DrawString(s, font2, Brushes.Black, sizeTextOffset + (size4.Width + size3.Width - g.MeasureString(s, font2).Width), (margin) * zoomY + font1.Height + font2.Height * 0);

                    g.DrawString("Height:", font2, Brushes.Black, sizeTextOffset, (margin) * zoomY + font1.Height + font2.Height * 1);
                    s = string.Format("{0:0.0}m", (Math.Round(vh * 10) / 10));
                    g.DrawString(s, font2, Brushes.Black, sizeTextOffset + (size4.Width + size3.Width - g.MeasureString(s, font2).Width), (margin) * zoomY + font1.Height + font2.Height * 1);

                    g.DrawString("Length:", font2, Brushes.Black, sizeTextOffset, (margin) * zoomY + font1.Height + font2.Height * 2);
                    s = string.Format("{0:0.0}m", (Math.Round(vl * 10) / 10));
                    g.DrawString(s, font2, Brushes.Black, sizeTextOffset + (size4.Width + size3.Width - g.MeasureString(s, font2).Width), (margin) * zoomY + font1.Height + font2.Height * 2);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    struct Polygon
    {
        public Vertex[] vertexs;

    }

    struct Vertex
    {
        public float x;
        public float y;
        public float z;
    }
}

