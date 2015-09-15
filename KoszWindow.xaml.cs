using System;
using System.Collections.Generic;
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

namespace RuchProstokata1 {
    /// <summary>
    /// Interaction logic for KoszWindow.xaml
    /// </summary>
    public partial class KoszWindow : Window {
        public Client MyClient { get; set; }
        public Basket MyBasket { get; set; }

        public KoszWindow(MainWindow mainWindow) {
            InitializeComponent();
            MainWindow WinGl = mainWindow;
            MyClient = mainWindow.GetClient;
            MyBasket = mainWindow.GetBasket;
            ArticlesItem.ItemsSource = MyBasket.GetArticlesFromBasket();
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Article article = ArticlesItem.SelectedItem as Article;
            if (article != null) {
                if (rbtnAllArticle.IsChecked == true) {
                    MyClient.Cash -= MyBasket.RemoveAllArticles(article);
                }
                else {
                    MyClient.Cash -= MyBasket.RemoveArticleFromBasket(article);
                }
            }
            this.DialogResult = true;
            Close();
        }
    }
}