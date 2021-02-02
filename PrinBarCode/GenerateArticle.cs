using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode
{
    public class GenerateArticle
    {
        private string brand;
        private string options;
        private string layer;
        private string height;
        private string length;

        public GenerateArticle()
        {

        }

        public GenerateArticle(string brand, string layer, string height, string length, string options)
        {
            this.brand = brand;
            this.layer = layer;
            this.height = height;
            this.length = length;
            this.options = options;
        }

        public string Generate()
        {
            string brand = Resources.BrandDictionary[this.brand];
            string layer = Resources.LayerDictionary[this.layer];
            string height = Resources.HeightDictionary[this.height];
            string length = Resources.LengthDictionary[this.length];
            string options = Resources.OptionsDictionary[this.options];

            string result = brand + layer + height + length + options;
            return result;
        }
    }
}
