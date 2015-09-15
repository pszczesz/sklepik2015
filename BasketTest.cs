using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RuchProstokata1 {
    [TestFixture]
    public class BasketTest {
        private Products testProducts;
        private Basket myBasket;

        [TestFixtureSetUp]
        public void SetUp() {
            testProducts = new Products();

            Article testArticle1 = new Article() {
                                                     GraphElem = null,
                                                     ImagePath = "c:\\ggg.png",
                                                     Name = "maslo",
                                                     Price = 23.2M,
                                                     Quantity = 23.6,
                                                     IsForShooping = true,
                                                 };
            Article testArticle2 = new Article() {
                                                     GraphElem = null,
                                                     ImagePath = "c:\\ggg.png",
                                                     Name = "mleko",
                                                     Price = 0M,
                                                     Quantity = 23.6,
                                                     IsForShooping = false,
                                                 };
            Article testArticle3 = new Article() {
                                                     GraphElem = null,
                                                     ImagePath = "c:\\ggg.png",
                                                     Name = "cukier",
                                                     Price = 15.2m,
                                                     Quantity = 100.1,
                                                     IsForShooping = true,
                                                 };
            testProducts.AddArticle(testArticle1);
            testProducts.AddArticle(testArticle2);
            testProducts.AddArticle(testArticle3);
            myBasket = new Basket();
        }

        [Test]
        public void AddToBasketTest() {
            if (myBasket.InBasket != null && myBasket.InBasket.Count > 0) myBasket.InBasket.Clear();
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("cukier"));
            Assert.AreEqual(3, myBasket.GetQuantityFromBasket(testProducts.GetArticle("maslo")));
            Assert.AreEqual(1,myBasket.GetQuantityFromBasket(testProducts.GetArticle("cukier")));
        }
        [Test]
        public void GetNumberOfArticle() {
            if (myBasket.InBasket != null && myBasket.InBasket.Count > 0) myBasket.InBasket.Clear();
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("cukier"));
            Assert.AreEqual(2,myBasket.GetNumberOfArticles());
        }
        [TestCase]
        public void RemoveArticleTest() {
            if (myBasket.InBasket != null && myBasket.InBasket.Count > 0) myBasket.InBasket.Clear();
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("cukier"));
           
            myBasket.RemoveArticleFromBasket(testProducts.GetArticle("maslo"));
            Assert.AreEqual(2, myBasket.GetQuantityFromBasket(testProducts.GetArticle("maslo")), "wymazanie masla");
          //  Assert.AreEqual(testProducts.GetArticle("maslo").Price,);
            myBasket.RemoveArticleFromBasket(testProducts.GetArticle("maslo"));
            myBasket.RemoveArticleFromBasket(testProducts.GetArticle("cukier"));
          //  Assert.AreEqual(1,myBasket.GetQuantityFromBasket(testProducts.GetArticle("maslo")),"wymazanie masla");
          //  Assert.AreEqual(0,myBasket.GetQuantityFromBasket(testProducts.GetArticle("cukier")),
          //      "wymazanie ostatniego cukru");
            
        }
        [TestCase]
        public void RemoveAllarticleTest() {
            if (myBasket.InBasket!=null && myBasket.InBasket.Count > 0) myBasket.InBasket.Clear();
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("maslo"));
            myBasket.AddToBasket(testProducts.GetArticle("cukier"));
            myBasket.RemoveAllArticles(testProducts.GetArticle("maslo"));
            Assert.AreEqual(0,myBasket.GetQuantityFromBasket(testProducts.GetArticle("maslo")));
        }
       
    }
}