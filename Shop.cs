using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuchProstokata1
{
    public class Shop
    {
        private Products products;
        public Products AllArticles { get { return products; } set { products = value;}}
        public IEnumerable<Article> GetProducts {
            get { return products as IEnumerable<Article>; }
        }
        public Article GetArticle(string name) {
            return products.GetArticle(name);
        }
        public IEnumerable<Article> GetForShopingProducts() {
            return products.GetShopingProducts();
        }
        public string NameShop { get; set; }
        public int GetNumberOfProducts() {
            return products.GetNumberOfProducts();
        }
         public Shop() {
             products= null;
             NameShop = "noname";
         }
        public Shop(Products products,string name) {
            this.products = products;
            NameShop = name;
        }
    }
}
