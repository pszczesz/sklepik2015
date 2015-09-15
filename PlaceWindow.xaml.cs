using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RuchProstokata1
{
    /// <summary>
    /// Interaction logic for PlaceWindow.xaml
    /// </summary>
    /// 
    public partial class PlaceWindow : Window {
        private StarWindow startWindow;
        private const int NumberInDeskMain = 12;
        private const int NumberInDeskOther = 10;
        private DragDropData articleDragDrop;
        private Brush brushcolor;
        public PlaceWindow(StarWindow startWindow) {
            InitializeComponent();
            brushcolor = AllArticles.BorderBrush;
            //zdarzena obslugujace dodawanie elementow do list
            ((INotifyCollectionChanged) lbDesk1.Items).CollectionChanged += lbDesk1_CollectionChanged;
            ((INotifyCollectionChanged)lbDesk2.Items).CollectionChanged += lbDesk2_CollectionChanged;
            ((INotifyCollectionChanged)lbDesk3.Items).CollectionChanged += lbDesk3_CollectionChanged;
            ((INotifyCollectionChanged)lbDesk4.Items).CollectionChanged += lbDesk4_CollectionChanged;
            this.startWindow = startWindow;
            articleDragDrop=startWindow.DataRepoAll.MyDragDropData;
            DataContext = articleDragDrop;
        }

       
        private void lbDesk1_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            // MessageBox.Show("zdarzenie zmiana ilości elementów");
            tbDesk1.Text = " " + (NumberInDeskMain - lbDesk1.Items.Count);
            if (lbDesk1.Items.Count >= NumberInDeskMain) {
                lbDesk1.SetValue(DragDropHelper.IsDropTargetProperty, false);
                lbDesk1.BorderBrush = Brushes.Red;
            }
            else {
                lbDesk1.SetValue(DragDropHelper.IsDropTargetProperty, true);
                lbDesk1.BorderBrush = brushcolor;
            }
        }

        private void lbDesk2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            tbDesk2.Text = " " + (NumberInDeskOther - lbDesk2.Items.Count);
            if (lbDesk2.Items.Count >= NumberInDeskOther) {
                lbDesk2.SetValue(DragDropHelper.IsDropTargetProperty, false);
                lbDesk2.BorderBrush = Brushes.Red;
            }
            else {
                lbDesk2.SetValue(DragDropHelper.IsDropTargetProperty, true);
                lbDesk2.BorderBrush = brushcolor;
            }
        }

        private void lbDesk3_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            tbDesk3.Text = " " + (NumberInDeskOther - lbDesk3.Items.Count);
            if (lbDesk3.Items.Count >= NumberInDeskOther) {
                lbDesk3.SetValue(DragDropHelper.IsDropTargetProperty, false);
                lbDesk3.BorderBrush = Brushes.Red;
            }
            else {
                lbDesk3.SetValue(DragDropHelper.IsDropTargetProperty, true);
                lbDesk3.BorderBrush = brushcolor;
            }
        }
        private void lbDesk4_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            tbDesk4.Text = " " + (NumberInDeskMain - lbDesk4.Items.Count);
            if (lbDesk4.Items.Count >= NumberInDeskMain) {
                lbDesk4.SetValue(DragDropHelper.IsDropTargetProperty, false);
                lbDesk4.BorderBrush = Brushes.Red;
            }
            else {
                lbDesk4.SetValue(DragDropHelper.IsDropTargetProperty, true);
                lbDesk4.BorderBrush = brushcolor;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            articleDragDrop.UpdateProductsPlaces();
            startWindow.Show();
        }

       

       
        private void ToDesk1Click(object sender, RoutedEventArgs e) {
            int indexFrom = AllArticles.SelectedIndex;
            int indexTo = lbDesk1.SelectedIndex;
            if(lbDesk1.Items.Count==0) {
                ListBoxMove.MoveToEnd(articleDragDrop.AllArticleToDesk, articleDragDrop.Desk1, indexFrom);
            }else 
                ListBoxMove.Move(articleDragDrop.AllArticleToDesk,articleDragDrop.Desk1,indexFrom,indexTo);

        }

       

        private void lbDesk1_MouseEnter(object sender, MouseEventArgs e) {
         //   MessageBox.Show("zmiana zródła : elementów: " + lbDesk1.Items.Count);
            //if (lbDesk1.Items.Count >= NumberInDeskMain)
            //    lbDesk1.SetValue(DragDropHelper.IsDropTargetProperty, false);
            //else lbDesk1.SetValue(DragDropHelper.IsDropTargetProperty, true);
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            StringBuilder sb = new StringBuilder();
            foreach (Article article in articleDragDrop.Desk1) {
                sb.Append(article.Name + " " + article.Price + " zł. Obrazek: "+article.ImagePath+" \n");
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
