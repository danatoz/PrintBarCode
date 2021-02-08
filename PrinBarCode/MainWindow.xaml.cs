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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Microsoft.Win32;
using IronBarCode;
using PrinBarCode.View;
using Brushes = System.Drawing.Brushes;
using Image = System.Drawing.Image;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace PrinBarCode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string result = "";
        private Font printFont;
        private StreamReader streamToPrint;
        private string filePath;//  = @"C:\Users\Dante\Desktop\asd.txt"
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {


        }

        private void pdPrintPage(object sender, PrintPageEventArgs ev)
        {
            //Image img = Image.FromHbitmap(imgBarCode);
        }


        void PrinPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void btnOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            var fileContent = string.Empty;
            if (openFileDialog.ShowDialog() != DialogResult)
            {
                filePath = openFileDialog.FileName;

                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

        }

        //private System.Drawing.Bitmap imgBitmap;
        private void btnPrintBarCode_Click(object sender, RoutedEventArgs e)
        {
            GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode(lblArticul.Text, BarcodeEncoding.Code128);
            //MyBarCode.AddAnnotationTextBelowBarcode(lblArticul.Text);
            GenerateBarcodeImage generateBarcode = new GenerateBarcodeImage();
            //imgBarCode.Source = generateBarcode.BitmapToImageSource(MyBarCode.ToBitmap());


        }
        /// <summary>
        /// Передаем данные в класс GenerateArticle и пременяем метод сбора артикула к лейблу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            string cbBrandText = cbBrand.Text;
            string cbLayerText = cbLayer.Text;
            string cbHeightText = cbHeight.Text;
            string cbLengthText = cbLength.Text;
            string cbOptionsText = cbOptions.Text;
            new LabelBarCode(cbBrandText, cbLayerText, cbHeightText, cbLengthText, cbOptionsText).ShowDialog();
            /*GenerateArticle article = new GenerateArticle(cbBrandText, cbLayerText, cbHeightText, cbLengthText, cbOptionsText);

            lblArticul.Text = article.Generate();

            GenerateBarcodeImage generateBarcode = new GenerateBarcodeImage();
            imgBarCode.Source = generateBarcode.BitmapToImageSource(generateBarcode.drawImage(lblArticul.Text));*/

        }
    }
}
