using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RuchProstokata1
{
     [TestFixture]
    class DoShopingTest
    {
         private Shop testShop;
         private Client MyClient;
         private Products toShoping;
         private DoShoping myDoShoping;
         private Basket MyBasket;
         [TestFixtureSetUp]
         public void SetUp()
         {
             MyBasket=new Basket();
             toShoping = new Products();
             
             testShop = new Shop();
             testShop.NameShop = "mój sklep spożywczy";
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
            toShoping.AddArticle(testArticle1);
            toShoping.AddArticle(testArticle2);
            toShoping.AddArticle(testArticle3);
             
             MyClient=new Client(){Cash = 50m,Name = "klient",ToShoping = toShoping};
             ArticlesRepository myArticlesRepository = new ArticlesRepository();
             testShop.AllArticles = myArticlesRepository.GenerSomeOfProducts("images/");
             myDoShoping = new DoShoping(MyClient, MyBasket);


         }
         [TestCase]
         public void ShopArticleTest() {
            // MyClient = new Client() { Cash = 200m, Name = "klient", ToShoping = toShoping };
             decimal clientcash = MyClient.Cash;
             Article article = toShoping.GetArticle("cukier");
             Assert.AreEqual(true,myDoShoping.ArticleToBasket(article));
             Assert.AreEqual(clientcash-article.Price,MyClient.Cash);
         }
    }
}
