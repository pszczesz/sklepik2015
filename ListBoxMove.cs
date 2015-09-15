using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace RuchProstokata1
{
    class ListBoxMove
    {
        public static void Move(ObservableCollection<Article> fromList,
            ObservableCollection<Article> toList,int indexFrom, int indexTo) {
            if(indexFrom!=-1) {
                if(indexTo==-1) {
                    MoveToEnd(fromList,toList,indexFrom);
                }
                else
                    MoveAt(fromList,toList,indexFrom,indexTo);
            }
            
        }
        public static void MoveToEnd(ObservableCollection<Article> fromList,
            ObservableCollection<Article> toList,int indexFrom) {
            if(indexFrom!=-1) {
                toList.Add(fromList[indexFrom]);
                fromList.RemoveAt(indexFrom);
            }
            
        }
        public static void MoveAt(ObservableCollection<Article> fromList,
            ObservableCollection<Article> toList,int indexFrom,int indexTo) {
                if(indexFrom!=-1) {
                    toList.Insert(indexTo,fromList[indexFrom]);
                    fromList.RemoveAt(indexFrom);
                }
        }
    }
}
