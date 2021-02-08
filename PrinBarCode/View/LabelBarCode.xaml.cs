using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IronBarCode;

namespace PrinBarCode.View
{
    /// <summary>
    /// Логика взаимодействия для LabelBarCode.xaml
    /// </summary>
    public partial class LabelBarCode : Window
    {
        private string cbBrandText;
        private string cbLayerText;
        private string cbHeightText;
        private string cbLengthText;
        private string cbOptionsText;
        private string lbArtricul;

        public LabelBarCode(string brand, string layer, string height, string length, string options,string articul)
        {
            InitializeComponent();

            GenerateArticle generateArticle = new GenerateArticle(brand, layer, height, length, options);
            string l = generateArticle.Split(layer);
            string h = generateArticle.Split(height);
            string len = generateArticle.Split(length);
            string b = generateArticle.Split(brand);
            string o = generateArticle.Split(options);
            tbTHL1.Text = $"{l}/{h}/{len}";
            tbTHL2.Text = tbTHL1.Text;
            tbArticul1.Text = articul;
            tbArticul12.Text = tbArticul1.Text;
            tbArticul13.Text = tbArticul1.Text;
            tbArticul2.Text = tbArticul1.Text;
            //Используем библиотеку IronBarCode для генерации шк
            GeneratedBarcode articulBarcode =
                BarcodeWriter.CreateBarcode(tbArticul1.Text, BarcodeEncoding.Code128);
            GenerateBarcodeImage generateBarcodeImage = new GenerateBarcodeImage();

            //генерируем шк и приводим его к imagesource с
            //помощью метода BitmapToImageSource
            imgBarCode.Source = generateBarcodeImage.BitmapToImageSource(articulBarcode.ToBitmap());
            imgBarCode2.Source = imgBarCode.Source;
            string moreInformation = $"{articul}{b}{l}/{h}/{len}";
            GeneratedBarcode moreInformationBarcode =
                BarcodeWriter.CreateBarcode(moreInformation, BarcodeEncoding.Code128);
            imgBarCodeInformation.Source = generateBarcodeImage.BitmapToImageSource(moreInformationBarcode.ToBitmap());

        }

        public LabelBarCode()
        {
            
        }
        //public string Label { get => label; set; }
        public LabelBarCode(string cbBrandText, string cbLayerText, string cbHeightText, string cbLengthText, string cbOptionsText, string lbArtricul, System.Drawing.Image barCodeImage)
        {
            this.cbBrandText = cbBrandText;
            this.cbLayerText = cbLayerText;
            this.cbHeightText = cbHeightText;
            this.cbLengthText = cbLengthText;
            this.cbOptionsText = cbOptionsText;
            this.lbArtricul = lbArtricul;
        }

        private void btnPrint_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(mainPanel, "Вывод этикетки на печать");
            }
        }
    }
}
