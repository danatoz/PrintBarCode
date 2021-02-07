﻿using System;
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
            string _brand = Split(this.brand).ToString();
            string brand = Resources.BrandDictionary[_brand];

            string _layer = Split(this.layer).ToString();
            string layer = Resources.LayerDictionary[_layer];

            string _height = Split(this.height).ToString();
            string height = Resources.HeightDictionary[_height];

            string _length = Split(this.length).ToString();
            string length = Resources.LengthDictionary[_length];

            string _options = Split(this.options).ToString();
            string options = Resources.OptionsDictionary[_options];

            string result = $"7724{brand}{layer}{height}{length}{options}";//"7724{0}{1}{2}{3}{4}",brand, layer, height, length, options);
            return result;
        }

        private string Split(string split)
        {
            int found = split.IndexOf("[");
            split = split.Remove(found,1);
            int count = split.Length;
            found = split.IndexOf(",");
            
            split = split.Remove(found);

            return split;
        }
    }
}
