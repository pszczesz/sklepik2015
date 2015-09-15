using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuchProstokata1
{
    public class Transaction
    {
        public Transaction(Client client, Basket basket) {
            this.MyClient = client;
            this.MyBasket = basket;
        }

        private Client myClient;
        private Basket myBasket;
        public Client MyClient { get { return myClient; } set { myClient = value; } }
        public Basket MyBasket { get { return myBasket; } set { myBasket = value; } }
        public bool CheckTransaction() {
            if (MyClient.Cash >= MyBasket.BasketCost()) return true;
            return false;
        }
        public string TransactionInfo() {
            if (MyBasket.InBasket != null) {
                string message = "Chcesz kupić następujące towary:\n";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(message);
                foreach (Article article in myBasket.GetArticlesFromBasket()) {
                    //message += article.Name + "\n";
                    stringBuilder.Append("\t"+article.Name + "\n");
                }
                if (CheckTransaction()) {
                    stringBuilder.Append("kwota jaką dysponujesz to: " + MyClient.Cash.ToString("C2") + "\n");
                    stringBuilder.Append("Cena towarów w koszyku: " + MyBasket.BasketCost().ToString("C2") + "\n");
                }
                else {
                    stringBuilder.Append("Masz za mało gotówki aby to wszystko kupić\n");
                }
                return stringBuilder.ToString();
            }
            return "Koszyk jest pusty!!";
        }
    }
}
