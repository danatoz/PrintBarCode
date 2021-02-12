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
            dpDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }
        private void btnPrintBarCode_Click(object sender, RoutedEventArgs e)
        {
            string cbBrandText = cbBrand.Text;
            string cbLayerText = cbLayer.Text;
            string cbHeightText = cbHeight.Text;
            string cbLengthText = cbLength.Text;
            string cbOptionsText = cbOptions.Text;
            string lbArtricul = lblArticul.Text;

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
            try
            {
                GenerateArticle article = new GenerateArticle(cbBrandText, cbLayerText, cbHeightText, cbLengthText, cbOptionsText);
                lblArticul.Text = article.Generate();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Ошибка");
            }

            string lbArtricul = lblArticul.Text;
            string getDate = dpDate.Text;


            try
            { 
                new LabelBarCode(cbBrandText, cbLayerText,
                    cbHeightText, cbLengthText,
                    cbOptionsText, lbArtricul, getDate).ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Ошибка");
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new ReferenceBooksView().ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
