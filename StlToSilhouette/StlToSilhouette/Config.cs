using System;

namespace StlToSilhouette
{
    public class Config
    {
        public string BackColor { get; set; }
        public string Font1 { get; set; }
        public string Font2 { get; set; }
        public bool IsTransparent { get; set; }
        public string RootDir { get; set; }
        public decimal UnderWater { get; set; }
        public decimal Zoom { get; set; }
        public string OutputDir { get; set; }

        internal void Save()
        {
            using (var sw = new System.IO.StreamWriter("config.xml"))
            {
                var ser = new System.Xml.Serialization.XmlSerializer(typeof(Config));
                ser.Serialize(sw, this);
            }
        }

        internal static Config Load()
        {
            try
            {
                using (var sw = new System.IO.StreamReader("config.xml"))
                {
                    var ser = new System.Xml.Serialization.XmlSerializer(typeof(Config));
                    return (Config)ser.Deserialize(sw);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}