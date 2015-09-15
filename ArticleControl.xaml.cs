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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RuchProstokata1
{
	/// <summary>
	/// Interaction logic for ArticleControl.xaml
	/// </summary>
	public partial class ArticleControl : UserControl {
        public Article ArticleCrt { get; set; }
		public ArticleControl()
		{
			this.InitializeComponent();
		    

		}

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            ArticleInfo myInfo = new ArticleInfo(this.ArticleCrt);
            myInfo.ShowDialog();
        }
	}
}