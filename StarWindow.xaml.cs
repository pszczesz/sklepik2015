using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RuchProstokata1
{
    /// <summary>
    /// Interaction logic for StarWindow.xaml
    /// </summary>
    public partial class StarWindow : Window {
        private AllDataAppRepository allDataAppRepository;
        public AllDataAppRepository DataRepoAll { get { return allDataAppRepository; } }
       // ArticlesRepository myArticlesRepository = new ArticlesRepository();
        private Products products;
        private Products productsForShoping;
        string imagePath = AppDomain.CurrentDomain.BaseDirectory + "images\\";
        public Products GetProducts {
            get { return products; }
        }
        public Products GetProductsForShoping { get { return productsForShoping; } set { productsForShoping = value; } }
        public StarWindow() {
            InitializeComponent();
            string imageFile = "koszyk.png";
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "images\\";
            try {
                Obrazek.Source = new BitmapImage(new Uri(basePath + imageFile));
            } catch {
                MessageBox.Show("Nie znaleziono!!");
            }
            allDataAppRepository = new AllDataAppRepository(); 
            products = allDataAppRepository.MyProducts;
            productsForShoping = allDataAppRepository.ProductsForShoping;
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnDoShop_Click(object sender, RoutedEventArgs e) {
            MainWindow myMainwindow = new MainWindow(this);
            this.Hide();
            myMainwindow.ShowDialog();
        }

        private void btnArticles_Click(object sender, RoutedEventArgs e) {
            Demo();
        }

        private void btmWatchUsers_Click(object sender, RoutedEventArgs e) {
            Demo();
        }

        private void btnGetUser_Click(object sender, RoutedEventArgs e) {
            Demo();
        }
        private void Demo() {
            MessageBox.Show("to wersja Demo i brak tej funkcjonalności", "Wersja Demo");
        }

        private void btnSetArticle_Click(object sender, RoutedEventArgs e) {
            ArticlesForShoping aricleWindow = new ArticlesForShoping(this);
            this.Hide();
            aricleWindow.ShowDialog();
            productsForShoping =allDataAppRepository.MyArticlesRepository.SetToShoping(allDataAppRepository.ImagePath);
        }

        private void btnSortArticles_Click(object sender, RoutedEventArgs e) {
            PlaceWindow placeWindow = new PlaceWindow(this);
            this.Hide();
            placeWindow.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            DataRepoAll.FromDatabase.UpdateArticles(products);
        }
    }
    }
