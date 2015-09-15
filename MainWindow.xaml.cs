using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RuchProstokata1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private StarWindow startWindow;
       // private ArticlesRepository myArticlesRepository;
        public MainWindow(StarWindow window) {
            InitializeComponent();
            // nie lubie definiowac funkcji obslugi zdarzen w xamlu.
            // this.MouseLeftButtonDown += WindowMouseLeftButtonDown;
            //  this.MouseLeftButtonUp += WindowMouseLeftButtonUp;
            //  this.MouseMove += WindowMouseMove;
            startWindow = window;
            //myArticlesRepository=new ArticlesRepository();
            double topCorner = 0;
            double leftCorner = 0;

            KeyDown += WindowKeyDown;

            //SetProductLayout(topCorner);
            SetArticlesLayout(topCorner);
            SetClient();
            myBasket = new Basket();
            BasketShoping.ItemsSource = myBasket.JustShoped;
            if (!client.IsCalculate) SumCoast.Visibility = Visibility.Collapsed;
            if (!client.IsShowList) ArticleShoping.Visibility = Visibility.Collapsed;
            
           
        }

        private void SetClient() {

          //  Products toShoping = startWindow.GetProductsForShoping;
            ObservableCollection<Article> toShoping = startWindow.GetProducts.GetShopingProducts();
            //client = new Client() {
            //                          GraphElem = clientRect,
            //                          Name = "sluchacz1",
            //                          ToShoping = toShoping,
            //                          Cash = 100.00M,
            //                          IsCalculate = true,
            //                          IsShowList = true,};

            client = startWindow.DataRepoAll.Clients[0];
            client.GraphElem = clientRect;
            // cashBinding = new Binding();
            // cashBinding.Source = client;
            //decimal ff = 23.23M;
            // ClientCash.DataContext = client;
            ClientCash.DataContext = client;


            clientX = Canvas.GetLeft(client.GraphElem);
            clientY = Canvas.GetTop(client.GraphElem);
            clientRect.RenderTransform = transform;
            ClientName.Content = client.Name;
            ArticleShoping.ItemsSource = toShoping;
        }
        private void SetArticlesLayout(double topCorner) {
            ObservableCollection<Article> desk1=startWindow.DataRepoAll.MyDragDropData.Desk1;
            ObservableCollection <Article> desk2 = startWindow.DataRepoAll.MyDragDropData.Desk2;
            ObservableCollection<Article> desk3 = startWindow.DataRepoAll.MyDragDropData.Desk3;
            ObservableCollection<Article> desk4 = startWindow.DataRepoAll.MyDragDropData.Desk4;
            List<ArticleControl> articleControls = new List<ArticleControl>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            elements = new List<SceneElement>();
            //     elements.Add(new SceneElement() {GraphElem = kasa, Name = "kasa"});
            //     elements.Add(new SceneElement() {GraphElem = Exit, Name = "Wyjście"});
            try {
                MyKasa.Source = new BitmapImage(new Uri(path+"images\\Kasa.png"));
            } catch {
                path = AppDomain.CurrentDomain.BaseDirectory + "images\\noimage.png";
                MyKasa.Source = new BitmapImage(new Uri(path));
            }
            try {
                MyExit.Source = new BitmapImage(new Uri(path + "\\images\\wyjscie.png"));
            }catch {
                MyExit.Source = new BitmapImage(new Uri(path + "images\\noimage.png"));
            }
                elements.Add(new SceneElement() { GraphElem = MyKasa, Name = "Kasa" });
            elements.Add(new SceneElement() { GraphElem = MyExit, Name = "Wyscie" });
            const int up = 0;
            const int articleWidth = 72;
            double left = canvas1.Width - articleWidth;
            double center = canvas1.Width/2 - articleWidth;
            SetOneDeskLayout(desk1,articleControls,up,0);
            SetOneDeskLayout(desk2,articleControls,0,center);
            SetOneDeskLayout(desk3, articleControls,up, center + articleWidth);
            SetOneDeskLayout(desk4,articleControls,up,left);
          



        }

         void SetOneDeskLayout(ObservableCollection<Article> lista ,List<ArticleControl> allControlArticle,double topCorner,double leftCorner) {
             foreach (var article in lista) {
                 ArticleControl articleControl = new ArticleControl();
                allControlArticle.Add(articleControl);
                 
                 canvas1.Children.Add(articleControl);
                 article.GraphElem = articleControl;
                 BindingArticle.AddImage(article,articleControl);
                 Canvas.SetTop(articleControl,topCorner);
                 Canvas.SetLeft(articleControl,leftCorner);
                 articleControl.ArticleCrt = article;
                 if(article.GraphElem!=null) {
                     SceneElement sceneElement = article as SceneElement;
                     elements.Add(sceneElement);
                 }
                 topCorner += articleControl.Height;
             }
         }
       // private void SetProductLayout(double topCorner) {

       //     string imagePath = AppDomain.CurrentDomain.BaseDirectory + "images\\";   //tutaj ustawiam sciezke do obrazkow artykulow
       //     //Products products = ArticlesRepository.GenerSomeOfProducts(imagePath);
       //     Products products = startWindow.GetProducts;
       //     List<ArticleControl> articleControls = new List<ArticleControl>();
       //     articles = products.GetProducts;
       //     elements = new List<SceneElement>();
       ////     elements.Add(new SceneElement() {GraphElem = kasa, Name = "kasa"});
       ////     elements.Add(new SceneElement() {GraphElem = Exit, Name = "Wyjście"});
       //     elements.Add(new SceneElement(){GraphElem = MyKasa, Name="Kasa"});
       //     elements.Add(new SceneElement(){GraphElem = MyExit, Name = "Wyscie"});
       //     int ileWRzedzie = 8;
       //     for (int i = 0; i < ileWRzedzie; i++) {
       //         articleControls.Add(new ArticleControl());
       //         topCorner += articleControls[i].Height;
       //         canvas1.Children.Add(articleControls[i]);
       //         articles[i].GraphElem = articleControls[i];
       //         BindingArticle.AddImage(products.GetProducts[i], articleControls[i]);
       //         Canvas.SetTop(articleControls[i], topCorner);
       //         Canvas.SetLeft(articleControls[i], 0);
       //         articleControls[i].ArticleCrt = articles[i];
       //     }
       //     topCorner = 0;
       //     double rightCorner = 0;
       //     for (int i = ileWRzedzie; i < 15; i++) {
       //         articleControls.Add(new ArticleControl());
       //         topCorner += articleControls[i].Height;
       //         canvas1.Children.Add(articleControls[i]);
       //         articles[i].GraphElem = articleControls[i];
       //         BindingArticle.AddImage(products.GetProducts[i], articleControls[i]);
       //         Canvas.SetTop(articleControls[i], topCorner);
       //         Canvas.SetRight(articleControls[i], rightCorner);
       //         articleControls[i].ArticleCrt = articles[i];
       //     } 

       //     // dodawaie artykulow do elementow sceny
       //     foreach (Article article in articles) {
       //         if (article.GraphElem != null) {
       //             SceneElement sceneElement = article as SceneElement;
       //             elements.Add(sceneElement);
       //         }
       //     }
       // }

        //--------------------claas fields

        private TranslateTransform transform = new TranslateTransform();

        private Binding cashBinding;
        private Client client;
        public Client GetClient { get { return client; } set { client = value; } }
        public Basket GetBasket { get { return myBasket; } set { myBasket = value; } }
       // public MainWindow MyWindow { get { return this; } }
        private List<Article> articles;
        private List<SceneElement> elements;
        private Basket myBasket;
        public Basket MyBasket { get { return myBasket; }
           }
        //private List<Article> products;
        private double clientX;
        private double clientY;

        private void WindowKeyDown(object sender, KeyEventArgs e) {
            if((e.KeyboardDevice.Modifiers==ModifierKeys.Control)&&(e.Key==Key.Q)&&(client.IsShowList)) {
                if (ArticleShoping.Visibility == Visibility.Visible) ArticleShoping.Visibility = Visibility.Hidden;
                else ArticleShoping.Visibility = Visibility.Visible;
                return;
            }
            if((e.KeyboardDevice.Modifiers==ModifierKeys.Control)&&(e.Key==Key.L)&&(client.IsCalculate)) {
                if (SumCoast.Visibility == Visibility.Visible) SumCoast.Visibility = Visibility.Hidden;
                else SumCoast.Visibility = Visibility.Visible;
            }
            double left = Canvas.GetLeft(clientRect);
            double top = Canvas.GetTop(clientRect);
            Move move = new Move(client, canvas1, elements);
            switch (e.Key) {
                case Key.Down:

                    move.MoveDown(clientRect, transform);
                    break;

                case Key.Up:


                    move.MoveUp(clientRect, this.transform);
                    break;

                case Key.Left:

                    move.MoveLeft(clientRect, this.transform);
                    break;

                case Key.Right:
                    move.MoveRight(clientRect, transform);
                    break;
            }
            if (move.GetColisionWith != null && move.GetColisionWith is Article)
                WeHaveShoping(move.GetColisionWith as Article, client.IsLearning);
            else if(move.GetColisionWith!=null ) {
                Transaction transaction=new Transaction(GetClient,GetBasket);
                string message = transaction.TransactionInfo();
                MessageBox.Show(message);
            }
        }

        private void WeHaveShoping(Article getColisionWith, bool isLearning) {
            DoShoping doShoping = new DoShoping(client,myBasket);
            string message;
            if (getColisionWith.IsForShooping || !isLearning) {
              /*  message = "Możesz kupić artykuł: " + getColisionWith.Name + "\n w cenie "
                                 + getColisionWith.Price.ToString("C2") + ".\n"
                                 + "Obecnie masz : " + client.CashString;
                MessageBoxResult dialogResult = MessageBox.Show(message, "Czy kupujesz?\n", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes) {
                    doShoping.ArticleToBasket(getColisionWith);
               *  UpdateBasketList();
                */
                    message = "Możesz kupić artykuł:\n " + getColisionWith.Name + "\n w cenie "
                                 + getColisionWith.Price.ToString("C2") + ".\n"
                                 + "Obecnie masz : " + client.CashString;
                    TransWindow newTransWindow = new TransWindow(this,getColisionWith,message,doShoping,isLearning);
                newTransWindow.ShowDialog();
                }
             else {
                message = "Nie możesz kupić tego towaru!";
                TransWindow newTransWindow = new TransWindow(this, getColisionWith, message,doShoping,isLearning);
                newTransWindow.ShowDialog();
            }
           
        }

        private void Expander_KeyDown(object sender, KeyEventArgs e) {
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            client.Cash -= 15;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            myBasket.AddToBasket(articles[0]);
            myBasket.AddToBasket(articles[1]);
            myBasket.AddToBasket(articles[1]);
            myBasket.AddToBasket(articles[0]);
            myBasket.AddToBasket(articles[0]); 
            myBasket.AddToBasket(articles[0]);
            UpdateBasketList();
        }

        public void UpdateBasketList() {
            BasketShoping.ItemsSource = myBasket.JustShoped;
            decimal cost = myBasket.BasketCost();
            SumCoast.Content = cost.ToString("C2");
        }

        private void BasketShoping_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
           
        }

        private void BasketShoping_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show("xcvxcvxvxvx");
            KoszWindow myKoszWindow = new KoszWindow(this);
            Nullable<bool> dialog =  myKoszWindow.ShowDialog();
            if (dialog == true) {
               UpdateBasketList();
            }
           
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
           //startWindow.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            startWindow.Show();
        }

        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            canvas1.Focus();
        }
    }
}