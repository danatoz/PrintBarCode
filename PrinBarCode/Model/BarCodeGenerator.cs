using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode.Model
{
    class BarCodeGenerator : INotifyPropertyChanged
    {
        private string brand;
        private string layer;
        private string height;
        private string length;
        private string options;

        public string Brand
        {
            get => brand;
            set
            {
                brand = value;
                OnPropertyChanged("cbBrand");
            }
        }
        public string Layer
        {
            get => layer;
            set
            {
                layer = value;
                OnPropertyChanged("cbLayer");
            }
        }
        public string Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged("cbHeight");
            }
        }
        public string Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged("cbLength");
            }
        }
        public string Options
        {
            get => options;
            set
            {
                options = value;
                OnPropertyChanged("cbOptions");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
