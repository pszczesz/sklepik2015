using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuchProstokata1
{
    public class DoShoping
    {
        public Client MyClient { get; set; }
        public Basket MyBasket { get; set; }
        public bool IsCanShoping { get; set; }
        public DoShoping(Client client,Basket basket) {
            MyBasket = basket;
            MyClient = client;
            IsCanShoping = false;
        }
        public DoShoping() {
            MyBasket = null;
            MyClient = null;
            IsCanShoping = false;
        }
        public bool ArticleToBasket(Article article) {
            if (article.IsForShooping || !MyClient.IsLearning /*&& ClientHaveCash(article)*/)
                if(MyBasket!=null) {
                    MyBasket.AddToBasket(article);
                   // MyClient.Cash -= article.Price;
                    return true;
                }
            return false;
        }

        private bool ClientHaveCash(Article article) {
            return MyClient.Cash > article.Price ? true : false;
        }
    }
}
