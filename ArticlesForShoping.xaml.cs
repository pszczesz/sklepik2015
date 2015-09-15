using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ArticlesForShoping.xaml
    /// </summary>
    public partial class ArticlesForShoping : Window
    {
        private Products products;

        private StarWindow startWindow;
        public ArticlesForShoping(StarWindow window) {
            InitializeComponent();
            startWindow = window;
            products = window.GetProducts;
            
          
            dbArticles.DataContext = products.GetProducts;
            dbArticles.ItemsSource = products.GetArticlesPlaced();
          

        }

       

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            startWindow.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            foreach (var product in products.GetProducts) {
                product.IsForShooping = false;
            }
        }

        

        private void dbArticles_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Article article = dbArticles.SelectedValue as Article;
            if (article!=null) {
                article.IsForShooping = article.IsForShooping ? false : true;
            }
         
        }

      }
}
