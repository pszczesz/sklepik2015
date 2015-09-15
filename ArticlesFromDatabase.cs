using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using RuchProstokata1.SklepDBDataSetTableAdapters;

namespace RuchProstokata1
{
    public class ArticlesFromDatabase {
        private ObservableCollection<Article> articlesDB;
        private SklepDBDataSet sklepDBDataSet;
        private SklepDBDataSetTableAdapters.ArticlesTableAdapter sklepArticlesTableAdapter;
        public ObservableCollection<Article> ArticleDB {
            get { return articlesDB; }
        }
        private void InicializeArticles(string imagePath) {
            sklepDBDataSet = new SklepDBDataSet();
            sklepArticlesTableAdapter = new ArticlesTableAdapter();
            sklepArticlesTableAdapter.Fill(sklepDBDataSet.Articles);
            GetArticlesFromDataSet(imagePath);
        }
        private void GetArticlesFromDataSet(string imagePath) {
            articlesDB = new ObservableCollection<Article>();
            foreach (var article in sklepDBDataSet.Articles) {
                articlesDB.Add(FillArticle(article,imagePath));
            }
        }
        public ArticlesFromDatabase(string imagePath) {
            InicializeArticles(imagePath);
        }
        private Article FillArticle(SklepDBDataSet.ArticlesRow article, string imagePath) {
            Article art = new Article();
            art.Name =article.Name;
            art.Price = article.Price;
            art.ImagePath =imagePath+ article.ImagePath;
            art.ImagePathAlt = article.IsImagePathAltNull() ?imagePath+ "noname.png" : imagePath+article.ImagePathAlt;
            art.IsForShooping = article.IsForShoping;
            art.Quantity = article.Quantity;
            art.PlaceNo = article.PlaceNo;
            art.DeskNo = article.DeskNo;

            return art;

        }
        public void UpdateArticles(Products products) {
            foreach (var article in sklepDBDataSet.Articles) {
                Article artToUpdate = products.GetArticle(article.Name);
                if(artToUpdate!=null) {
                    //wybór cech do updatownia w bazie danych
                    article.DeskNo = artToUpdate.DeskNo;
                    article.IsForShoping = artToUpdate.IsForShooping;
                }
            }
            //wymuszenie zapisu do bazy z data setu

            try {
                sklepArticlesTableAdapter.Update(sklepDBDataSet.Articles);
            } catch (Exception) {
                
               MessageBox.Show("Nieudane zapisanie do bazy danych!!");
            }
        }
        
    }
}
