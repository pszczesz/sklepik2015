using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RuchProstokata1 {
    public class ArticleRepository {
        public List<Article> GenerateArticles {
            get {
                Article article0 = Article.ArticleGenerate("masło", new UIElement(), true, "masło", 3.0, 12.00m);
                Article article1 = Article.ArticleGenerate("chleb", new UIElement(), true, "chleb", 3.0, 2.5m);
                Article article2 = Article.ArticleGenerate("ziemniaki", new UIElement(), true, "ziemniaki", 20.0, 0.5m);
                Article article3 = Article.ArticleGenerate("olej", new UIElement(), false, "olej", 23.0, 1.1m);
                return new List<Article>() {article0, article1, article2, article3};
            }
        }
    }
}