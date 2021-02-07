using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PrinBarCode
{
    class GenerateBarcodeImage
    {
        #region Properties

        public string Article { get; set; }
        public string NameRadiator { get; set; }
        public string DLR { get; set; }
        public string TypeHeighgLength { get; set; }
        public string DmcCode { get; set; }
        public string EncodedDate { get; set; }
        public string Brand { get; set; }
        public string ManufacturerAddress { get; set; }
        public object BarCode { get; set; }

        

        #endregion

        public Bitmap drawImage(string text)
        {
            FontFamily ff = new FontFamily("Arial");
            Font font = new Font(ff, 26);
            Color textColor = Color.Black;
            Color bgColor = Color.Blue;

            //создаем растровое изображение, чтобы получить граффический обьект
            Bitmap img = new Bitmap(420,460);
            Graphics drawing = Graphics.FromImage(img);

            // измеряем строку, чтобы увидеть,
            // насколько большим должно быть изображение
            //SizeF textSize = drawing.MeasureString(text, font);

            img.Dispose();
            drawing.Dispose();

            //создаем новое изображение нужного размера
            img = new Bitmap(420,460);

            drawing = Graphics.FromImage(img);

            //заливаем фон цветом
            drawing.Clear(bgColor);

            //создаем кисть для текста
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text,font,textBrush,11,415,StringFormat.GenericTypographic);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }

        public BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}
