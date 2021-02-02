using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrinBarCode;

namespace GenerateTest
{
    [TestClass]
    public class GenerateArticleTest
    {
        [TestMethod]
        public void TestGeneratedArticle()
        {
            string brand = "Buderus";
            string options = "rs corb";
            string layer = "20";
            string height = "900";
            string length = "1000";

            GenerateArticle article = new GenerateArticle(brand,layer,height,length,options);

            article.Generate();
        }
    }
}
