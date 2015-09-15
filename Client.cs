using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace RuchProstokata1
{
    public class Client : IMoveable, INotifyPropertyChanged
    {
        private decimal cash;
        private bool isCalculate;
        private string cashString;
        public string CashString {
            get { return cashString; }
            set { cashString = value;
            OnPropertyChanged("CashString");}
        }

        public bool IsLearning { get; set; }
        public string Name { get; set; }
        public FrameworkElement GraphElem { get; set; }
        public decimal Cash { 
            get{ return cash;} 
            set{ cash = value;
                CashString = value.ToString("C2");
            this.OnPropertyChanged("Cash");
            }
        }
        public bool IsCalculate {
            get { return isCalculate; }
            set {
                isCalculate = value;
                this.OnPropertyChanged("IsCalculate");
            }
        }

        private bool isShowList;
        public bool IsShowList {
            get { return isShowList; }
            set{if(isShowList!=value) {
                isShowList = value;
                this.OnPropertyChanged("IsShowList");
            }}
        }
        int Score { get; set; }
        public Products ToShoping { get; set; }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
