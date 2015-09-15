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

namespace RuchProstokata1
{
    /// <summary>
    /// Interaction logic for ArticleInfo.xaml
    /// </summary>
    public partial class ArticleInfo : Window
    {
        public ArticleInfo(Article control) {
            InitializeComponent();
            string imageFile = control.ImagePath;
            //string basePath = AppDomain.CurrentDomain.BaseDirectory + "images\\";
            Contener.DataContext = control;
            try {
                ArticleInfoImg.Source = new BitmapImage(new Uri( imageFile));
            } catch {
                string path = AppDomain.CurrentDomain.BaseDirectory + "images\\png\\noimage.png";
                ArticleInfoImg.Source = new BitmapImage(new Uri(path));
                //MessageBox.Show("Nie znaleziono!!");
            }
          
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
