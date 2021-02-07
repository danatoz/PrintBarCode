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
            drawing.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Brush textBrush = new SolidBrush(textColor);

            #region Draw text down
            drawing.DrawString("VK-Profil", font, textBrush, 11, 415);
            drawing.DrawString("22/200/2000", font, textBrush, 160, 415);
            font = new Font(ff, 18);
            drawing.DrawString("Buderus", font, textBrush, 11, 340);
            font = new Font(ff, 9);
            drawing.DrawString(text, font, textBrush, 15, 330);
            drawing.DrawString("Bosh Group", font, textBrush, 15, 365);
            drawing.DrawString("ООО Еврорадиаторы", font, textBrush, 15, 378);
            drawing.DrawString("Россия г. Энгельс", font, textBrush, 15, 389);
            drawing.DrawString("413105 Саратовская обл.", font, textBrush, 15, 400);
            font = new Font(ff, 18);
            drawing.DrawString(text, font, textBrush, 270, 390);
            #endregion

            //drawing.RotateTransform(90);
            drawing.RotateTransform(180);
            #region Draw text down
            font = new Font(ff, 26);
            drawing.DrawString("VK-Profil", font, textBrush, -410, -40);
            drawing.DrawString("22/200/2000", font, textBrush, 160, 415);
            font = new Font(ff, 18);
            drawing.DrawString("Buderus", font, textBrush, 11, 340);
            font = new Font(ff, 9);
            drawing.DrawString("Bosh Group", font, textBrush, 15, 365);
            drawing.DrawString("ООО Еврорадиаторы", font, textBrush, 15, 378);
            drawing.DrawString("Россия г. Энгельс", font, textBrush, 15, 389);
            drawing.DrawString("413105 Саратовская обл.", font, textBrush, 15, 400);
            font = new Font(ff, 18);
            drawing.DrawString(text, font, textBrush, 270, 390);


            #endregion

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
