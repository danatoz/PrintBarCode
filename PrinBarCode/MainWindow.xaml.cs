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

        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnPrintBarCode_Click(object sender, RoutedEventArgs e)
        {
            LabelBarCode lblBarCode = new LabelBarCode();
            var labelPrint = lblBarCode.mainPanel;

            string cbBrandText = cbBrand.Text;
            string cbLayerText = cbLayer.Text;
            string cbHeightText = cbHeight.Text;
            string cbLengthText = cbLength.Text;
            string cbOptionsText = cbOptions.Text;
            string lbArtricul = lblArticul.Text;

            /*new LabelBarCode(cbBrandText, cbLayerText,
                cbHeightText, cbLengthText,
                cbOptionsText, lbArtricul).Hide();

            var dialog = new PrintDialog();
            try
            {
                if (dialog.ShowDialog() == true)
                    dialog.PrintVisual(labelPrint, "Вывод этикетки на печать");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(),"Ошибка");
            }*/
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
            string lbArtricul = lblArticul.Text;
            GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode(lblArticul.Text, BarcodeEncoding.Code128);

            new LabelBarCode(cbBrandText, cbLayerText, 
                cbHeightText, cbLengthText, 
                cbOptionsText, lbArtricul).ShowDialog();

        }
    }
}
