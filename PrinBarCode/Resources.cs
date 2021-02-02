using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode
{
    public static class Resources
    {
        public static Dictionary<string, string> BrandDictionary = new Dictionary<string, string>
        {
            ["Buderus"] = "1",
            ["Delonghi"] = "2"
        };
        public static Dictionary<string, string> OptionsDictionary = new Dictionary<string, string>
        {
            ["rs cosi"] = "0",

            ["rs corb"] = "1",
            ["rh corb"] = "2",

            ["rls colb"] = "3",
            ["rlh colb"] = "4"
        };
        public static Dictionary<string, string> LayerDictionary = new Dictionary<string, string>
        {
            ["10"] = "1",
            ["11"] = "2",
            ["20"] = "3",
            ["21"] = "4",
            ["22"] = "5",
            ["30"] = "6",
            ["33"] = "7"
        };
        public static Dictionary<string, string> HeightDictionary = new Dictionary<string, string>
        {
            ["300"] = "3",
            ["400"] = "4",
            ["500"] = "5",
            ["600"] = "6",
            ["900"] = "9"

        };
        public static Dictionary<string, string> LengthDictionary = new Dictionary<string, string>
        {
            ["400"] = "04",
            ["500"] = "05",
            ["600"] = "06",
            ["700"] = "07",
            ["800"] = "08",
            ["900"] = "09",
            ["1000"] = "10",
            ["1200"] = "12",
            ["1400"] = "14",
            ["1600"] = "16",
            ["1800"] = "18",
            ["2000"] = "20"
        };
    }
}
