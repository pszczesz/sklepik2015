using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RuchProstokata1
{
    [TestFixture]
    public class ShopTest 
    {
        private Shop testShop;
    [TestFixtureSetUp]
        public void SetUp() {
        testShop = new Shop();
        testShop.NameShop = "mój sklep spożywczy";
        ArticlesRepository myArticlesRepository=new ArticlesRepository();
        testShop.AllArticles = myArticlesRepository.GenerSomeOfProducts("images/");
       

    }
        [TestCase]
        public void GenerShopTest() {
            Assert.AreEqual(12, testShop.GetNumberOfProducts(), "test liczby artykułów");
            string wynik = "maslo";
            Assert.AreEqual(1000.0,testShop.GetArticle("Śmietana").Quantity);
        }
        [TestCase]
        public void EnableArticlesTest() {
            IEnumerable<Article> enableArticles;
            enableArticles = testShop.GetForShopingProducts();
            Assert.AreEqual(8,enableArticles.Count());
        }


    }
}
