using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RuchProstokata1
{
    public class Products  {
        private List<Article> products;
        public List<Article> GetProducts { get {
            return products;
        } set {
            products = value as List<Article>;
        } }
        public void AddArticle(Article article) {
            if(products == null) {
                products = new List<Article>();
            }
            products.Add(article);
        }
        public Article GetArticle(string name) {
            return products.Find(article => article.Name == name);
        }
        public int GetNumberOfProducts() {
            return products.Count;
        }

       
        public ObservableCollection<Article> GetArticlesPlaced() {
            var articlesPladed = new ObservableCollection<Article>();
            foreach (var product in products) {
                if(product.DeskNo!=-1) articlesPladed.Add(product);
            }
            return articlesPladed.Count != 0 ? articlesPladed : null;
        }  
        public ObservableCollection<Article> GetShopingProducts() {
            var result = new ObservableCollection<Article>();
            foreach (var enableArticle in products) {
                if(enableArticle.IsForShooping) result.Add(enableArticle);
            }
            return result.Count > 0 ? result : null;
        }

      
    }
}
