using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RuchProstokata1 {
    public class Basket : INotifyPropertyChanged {
        //public Products ProductsInBasket { get; set; }
        private Dictionary<Article, int> inBasket;

        public Dictionary<Article, int> InBasket {
            get { return inBasket; }
            set {
                inBasket = value;
                OnPropertyChanged("InBasket");
            }
        }


        private List<string> justShoped;

        public List<string> JustShoped {
            get { return justShoped; }
            set {
                justShoped = value;
                OnPropertyChanged("JustShoped");
            }
        }

        public List<Article> GetArticlesFromBasket() {
            if (InBasket != null && InBasket.Count > 0) {
                List<Article> myArticle = new List<Article>();
                foreach (var key in InBasket.Keys) {
                    myArticle.Add(key);
                }
                return myArticle;
            }
            return null;
        }

        public decimal RemoveArticleFromBasket(Article article) {
            if (InBasket.ContainsKey(article)) {
                decimal cashReturned;
                int oldValue = InBasket[article];
                if (oldValue > 1) {
                    InBasket[article] = oldValue - 1;

                    cashReturned = (InBasket[article] - oldValue)*article.Price;
                }
                else {
                    InBasket.Remove(article);
                    cashReturned = -1*article.Price;
                }
                UpdateJustShoped();

                return cashReturned;
            }
            return 0;
        }

        public decimal RemoveAllArticles(Article article) {
            decimal cashRerurned = 0;
            if (inBasket.ContainsKey(article)) {
                cashRerurned = -article.Price*InBasket[article];
                InBasket.Remove(article);
            }
            UpdateJustShoped();
            return cashRerurned;
        }

        public void AddToBasket(Article article) {
            if (InBasket == null) InBasket = new Dictionary<Article, int>();
            if (InBasket.ContainsKey(article)) {
                int oldQuantity = InBasket[article];
                InBasket[article] = oldQuantity + 1;
                OnPropertyChanged("InBasket");
            }
            else {
                InBasket.Add(article, 1);
                OnPropertyChanged("InBasket");
            }
            UpdateJustShoped();
        }

        private void UpdateJustShoped() {
            justShoped = new List<string>();

            string aa;
            foreach (var art in InBasket) {
                aa = art.Key.Name + ", ilość: " + art.Value.ToString();
                justShoped.Add(aa);
            }
        }

        public decimal BasketCost() {
            decimal actualCost = 0;
            if (InBasket != null && InBasket.Count > 0) {
                foreach (var actualArticle in InBasket) {
                    actualCost += actualArticle.Key.Price*actualArticle.Value;
                }
            }
            return actualCost;
        }

        public int GetQuantityFromBasket(Article article) {
            if (InBasket.ContainsKey(article))
                return InBasket[article];
            return 0;
        }

        public int GetNumberOfArticles() {
            return InBasket.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}