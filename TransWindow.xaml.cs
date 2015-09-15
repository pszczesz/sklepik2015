using System;
using System.Collections.Generic;
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
	/// Interaction logic for TransWindow.xaml
	/// </summary>
	public partial class TransWindow : Window
	{
	    private MainWindow shopWin;
	    private Article actualArticle;
	    private DoShoping shoping;
		public TransWindow(MainWindow sklepWin, Article article, string message,DoShoping doShoping, bool isLearning)
		{
			this.InitializeComponent();
		    shopWin = sklepWin;
		    actualArticle = article;
		    shoping = doShoping;
		    Info.Text = message;
           // BitmapImage btn = new BitmapImage();
          //  btn.BeginInit();
          //  btn.UriSource = new Uri(article.ImagePath, UriKind.Relative);
         //   btn.EndInit();
            try {
                InfoImage.Source = new BitmapImage(new Uri(article.ImagePath));
            }catch(Exception ex) {
                string path = AppDomain.CurrentDomain.BaseDirectory + "images\\png\\noimage.png";
                InfoImage.Source = new BitmapImage(new Uri(path));
            }
		    if(!article.IsForShooping && isLearning) {
                btnGet.Visibility = System.Windows.Visibility.Hidden;

                /////////////
                btnCancel.IsDefault = true;
            }
            if ( shopWin.MyBasket.InBasket==null || (!shopWin.MyBasket.InBasket.ContainsKey(article))) {
                btnOut.Visibility=Visibility.Hidden;
            }
			// Insert code required on objsect creation below this point.
		}

        private void btnGet_Click(object sender, RoutedEventArgs e) {
            shoping.ArticleToBasket(actualArticle);
            shopWin.UpdateBasketList();
            Close();
        }

        private void btnOut_Click(object sender, RoutedEventArgs e) {
          //  shopWin.GetClient.Cash -= 
            shopWin.GetBasket.RemoveArticleFromBasket(actualArticle);
            shopWin.UpdateBasketList();
            Close();
        }

	}
}