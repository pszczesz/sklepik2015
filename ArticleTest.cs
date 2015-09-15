using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using NUnit.Framework;

namespace RuchProstokata1
{
    
    [TestFixture]
    public class ArticleTest
    {
        private Article artTest;
        
        //[TestFixtureSetUp]
        //public void SetUp() {
        //    artTest= new Article() {
        //                                            Name = "maslo",
        //                                            Image = "c:\\image\\maslo.png",
        //                                            GraphElem = new Image(),
        //                                            Price = 12.2m,
        //                                            Quantity = 3.4
        //                                        };
        //}


        [Test]
        public void NameTest() {
            artTest = new Article() {
                Name = "maslo",
                ImagePath = "c:\\image\\maslo.png",
                GraphElem = null,
                Price = 12.2m,
                Quantity = 3.4
            };
            string wynik = "maslo";
            Assert.AreEqual(wynik, artTest.Name);
            Assert.AreEqual(12.2m,artTest.Price);
        }

    }
}
