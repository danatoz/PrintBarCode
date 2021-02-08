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

namespace PrinBarCode.View
{
    /// <summary>
    /// Логика взаимодействия для LabelBarCode.xaml
    /// </summary>
    public partial class LabelBarCode : Window
    {
        public LabelBarCode(string brand, string layer, string height, string length, string options)
        {
            InitializeComponent();
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
