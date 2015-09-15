using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RuchProstokata1
{
    [TestFixture]
    public class ProductsTest
    {
        private Products testProducts;
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
          
        }
        [Test]
        public void GetArticleTest() {
            Assert.AreEqual(15.2m, testProducts.GetArticle("cukier").Price,"szukanie towaru maslo");
        }
        [Test]
        public void GetNumberProductsTest() {
            Assert.AreEqual(3,testProducts.GetNumberOfProducts(),"test ilosci produktów");
        }
        [Test]
        public void GetNumberEnabledArticles() {
            ObservableCollection<Article> articles;
            articles = testProducts.GetShopingProducts();
            Assert.AreEqual(2,articles.Count);
        }
    }
}
