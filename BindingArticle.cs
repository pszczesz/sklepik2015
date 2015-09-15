using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace RuchProstokata1
{
    public class BindingArticle
    {
        public static void AddImage(Article article,ArticleControl control,string path ="") {
            if (path == "") path = article.ImagePath;
            AddImageToControl(control,path);
            BindingPrice(article, control);
            BindingName(article, control);
        }

        public static void BindingName(Article article, ArticleControl control) {
            control.nazwa.Text = article.Name;
        }

        public static void BindingPrice(Article article, ArticleControl control) {
            control.cena.Text=article.PriceStr();
        }

        public static void AddImageToControl(ArticleControl control, string path) {
           // BitmapImage btn = new BitmapImage();
          //  btn.BeginInit();
          //  btn.UriSource = new Uri(path, UriKind.Relative);
          //  btn.EndInit();
            try {
                control.image1.Source = new BitmapImage(new Uri(path));
            } catch {
                path = AppDomain.CurrentDomain.BaseDirectory + "images\\noimage.png";
                control.image1.Source = new BitmapImage(new Uri(path));
            }
        }
    }
}
