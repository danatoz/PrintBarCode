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
using Brushes = System.Drawing.Brushes;

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
            #region GenerateVariable

            string cbBrandText = cbBrand.Text;
            string cbLayerText = cbLayer.Text;
            string cbHeightText = cbHeight.Text;
            string cbLengthText = cbLength.Text;
            string cbOptionsText = cbOptions.Text;
            GenerateArticle article = new GenerateArticle(cbBrandText,cbLayerText,cbHeightText,cbLengthText,cbOptionsText);

            lblArticul.Text = article.Generate();
            #endregion

            //string lblArticle = lblArticul.Text;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                streamToPrint = new StreamReader(filePath);
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pdPrintPage);
                    // Print the document.
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pdPrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 20;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
                           printFont.GetHeight(ev.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage &&
                   ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
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

        private void btnPrintBarCode_Click(object sender, RoutedEventArgs e)
        {
            GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode(lblArticul.Text, BarcodeEncoding.Code128);
            MyBarCode.SaveAsPng("MyBarCode.png");

            System.Diagnostics.Process.Start("MyBarCode.png");
        }
    }
}
