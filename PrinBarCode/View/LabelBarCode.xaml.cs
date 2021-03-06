﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
using BarcodeLib;
using PrinBarCode.DataModel;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;

namespace PrinBarCode.View
{
    /// <summary>
    /// Логика взаимодействия для LabelBarCode.xaml
    /// </summary>
    public partial class LabelBarCode : Window
    {
        public object panel;
        public LabelBarCode(string brand, string layer, string height, string length, string options, string articul, string getDate)
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                panel = mainPanel;
                GenerateArticle generateArticle = new GenerateArticle(brand, layer, height, length, options);
                string l = generateArticle.Split(layer);
                string h = generateArticle.Split(height);
                string len = generateArticle.Split(length);
                string b = generateArticle.Split(brand);
                string o = generateArticle.Split(options);
                tbDate.Text = DateTime.Now.ToString("d");
                tbDate2.Text = tbDate.Text;

                #region Присвоение

                tbTHL1.Text = $"{l}/{h}/{len}";
                tbTHL2.Text = tbTHL1.Text;
                tbArticul1.Text = articul;
                tbArticul12.Text = tbArticul1.Text;
                tbArticul13.Text = tbArticul1.Text;
                tbArticul2.Text = tbArticul1.Text;
                tbBrand.Text = b;
                tbBrand2.Text = tbBrand.Text;
                tbAdress.Text = "Bosh Group";
                tbFirm.Text = "ООО Еврорадиаторы";
                tbManufacturerAddress.Text = "Россия г. Энгельс";
                tbIndex.Text = "413105";
                tbRegion.Text = "Саратовска обл.";
                tbAdress2.Text = tbAdress.Text;
                tbFirm2.Text = tbFirm.Text;
                tbManufacturerAddress2.Text = tbManufacturerAddress.Text;
                tbIndex2.Text = tbIndex.Text;
                tbRegion2.Text = tbRegion.Text;
                string mInfo = $"{tbAdress.Text}{tbFirm.Text}{tbManufacturerAddress.Text}{tbIndex.Text}{tbRegion.Text}";

                #endregion

                //Используем библиотеку BarCodeLib для генерации шк
                var barcode = new Barcode();
                //Генерируем ШК
                Image articulBarcode = barcode.Encode(TYPE.CODE128, tbArticul1.Text, Color.Black, Color.White, 133, 110);
                GenerateBarcodeImage generateBarcodeImage = new GenerateBarcodeImage();
                //Приводим ШК к Bitmap
                Bitmap bitmapArticulBarcode = new Bitmap(articulBarcode);

                //генерируем шк и приводим его к imagesource с
                //помощью метода BitmapToImageSource
                imgBarCode.Source = generateBarcodeImage.BitmapToImageSource(bitmapArticulBarcode);
                imgBarCode2.Source = imgBarCode.Source;

                string moreInformation = $"{b}{l}/{h}/{len}";
                //Генерируем ШК
                var moreInformationBarcode = barcode.Encode(TYPE.CODE128, moreInformation, Color.Black, Color.White, 390, 100);
                //Приводим ШК к Bitmap
                Bitmap bitmapMoreInformationBarcode = new Bitmap(moreInformationBarcode);
                imgBarCodeInformation.Source = generateBarcodeImage.BitmapToImageSource(bitmapMoreInformationBarcode);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Ошибка");
            }

            try
            {
                DBContextDate dbContext = new DBContextDate();
                Cast cast = new Cast();
                string[] dateSplit = cast.Split(getDate);
                string day = dateSplit[0], month = dateSplit[1], year = dateSplit[2];
                tbDate.Text = dbContext.GetEncryptedDate(day, month, year);
                tbDate2.Text = tbDate.Text;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Ошибка");
            }
        }

        private void btnPrint_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    dialog.PrintVisual(mainPanel, "Вывод этикетки на печать");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
