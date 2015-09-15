using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace RuchProstokata1
{
    public class Article:SceneElement, IShopable,INotifyPropertyChanged
    {
        private string name;
        public string Name {
            get { return name; }
            set { name = value; 
            this.OnPropertyChanged("Name");}
         }
        public string ImagePath { get; set; }
        public string ImagePathAlt { get; set; }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                this.OnPropertyChanged("Price");
            }
        }
        public Article() {
            PlaceNo = -1;
            DeskNo = -1;
        }
        private int deskNo;
        public int DeskNo {
            get { return deskNo; }
            set {
                if(deskNo!=value) {
                    deskNo = value;
                    OnPropertyChanged("DeskNo");
                }
            }
        }

        private int placeNo;
        public int PlaceNo {
            get { return placeNo; }
            set {
                if(placeNo!=value) {
                    placeNo = value;
                    OnPropertyChanged("PlaceNo");
                }
            }
        }
        public double Quantity { get; set; }
        private bool isForShoping;
        public bool IsForShooping {
            get{ return isForShoping;} 
            set {
                if(isForShoping!=value) {
                    isForShoping = value;
                    OnPropertyChanged("IsForShooping");
                }
            }  
        }
        public string NamePrice {
            get { return Name + ", " + PriceStr(); }
        }
        public string PriceStr() {
            return Price.ToString("C2");
        }
        public string PriceValue { get { return PriceStr(); } }
       
        //public override string ToString() {
        //    string wynik = "Nazwa: " + Name + ", src = " + ImagePath + ", cena = " + Price.ToString() + ", ilość: " +
        //                   Quantity + GraphElem.ToString();
        //    return wynik;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            if(PropertyChanged!=null) {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
       
    }
}
