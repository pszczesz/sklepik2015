using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RuchProstokata1 {
    public enum Desks {
        ArtNoSort = -1,
        Desk1 = 1,
        Desk2 = 2,
        Desk3 = 3,
        Desk4 = 4,
    }

    public class DragDropData {
        private AllDataAppRepository allDataAppRepository;
        private const int NumberInDeskMain = 12;
        private const int NumberInDeskOther = 10;

        public void SetProductsNoDesk(IEnumerable<Article> articles) {
            foreach (Article article in articles) {
                if (article.DeskNo == (int) Desks.ArtNoSort) AllArticleToDesk.Add(article);
            }
        }

        //public void SetProductsDeskNo(IEnumerable<Article> articles,Desks deskNo) {
        //    foreach (Article article in articles) {
        //        switch (deskNo) {
        //            case Desks.Desk1:
        //                if (Desk1.Count < NumberInDeskMain && article.DeskNo==(int)Desks.ArtNoSort) {
        //                    Desk1.Add(article);
        //                    article.DeskNo = (int) Desks.Desk1;
        //                }
        //                else article.DeskNo = (int) Desks.ArtNoSort;
        //                break;
        //            case Desks.Desk2:
        //                if (Desk2.Count < NumberInDeskOther && article.DeskNo==(int)Desks.ArtNoSort) {
        //                    Desk2.Add(article);
        //                    article.DeskNo = (int) Desks.Desk2;
        //                }
        //                else article.DeskNo = (int) Desks.ArtNoSort;
        //                break;
        //            case Desks.Desk3:
        //                if (Desk3.Count < NumberInDeskMain  && article.DeskNo==(int)Desks.ArtNoSort) {
        //                    Desk3.Add(article);
        //                    article.DeskNo = (int) Desks.Desk3;
        //                }
        //                else article.DeskNo = (int) Desks.ArtNoSort;
        //                break;
        //        }
        //    }
        //}
        public void SetDeskNoBegin(IEnumerable<Article> articles, Desks noDesk) {
            ObservableCollection<Article> actualDesk;
            switch (noDesk) {
                case Desks.Desk1:
                    actualDesk = Desk1;
                    break;
                case Desks.Desk2:
                    actualDesk = Desk2;
                    break;
                case Desks.Desk3:
                    actualDesk = Desk3;
                    break;
                case Desks.Desk4:
                    actualDesk = Desk4;
                    break;
                default:
                    actualDesk = AllArticleToDesk;
                    break;
            }
            if (actualDesk != null) {
                foreach (var article in articles) {
                    if (article.DeskNo == (int) noDesk) actualDesk.Add(article);
                }
            }
        }

        public ObservableCollection<Article> Desk1 { get; set; }
        public ObservableCollection<Article> Desk2 { get; set; }
        public ObservableCollection<Article> Desk3 { get; set; }
        public ObservableCollection<Article> Desk4 { get; set; }
        public ObservableCollection<Article> AllArticleToDesk { get; set; }

        public DragDropData(Products products) {
            Desk1 = new ObservableCollection<Article>();
            Desk2 = new ObservableCollection<Article>();
            Desk3 = new ObservableCollection<Article>();
            Desk4 = new ObservableCollection<Article>();
            AllArticleToDesk = new ObservableCollection<Article>();
            //SetProductsDeskNo(products.GetProducts, Desks.Desk1);
            //SetProductsDeskNo(products.GetProducts, Desks.Desk2);
            //SetProductsDeskNo(products.GetProducts, Desks.Desk3);
            ValidateDeskno(products);
            SetDeskNoBegin(products.GetProducts, Desks.Desk1);
            SetDeskNoBegin(products.GetProducts, Desks.Desk2);
            SetDeskNoBegin(products.GetProducts, Desks.Desk3);
            SetDeskNoBegin(products.GetProducts, Desks.Desk4);
            SetProductsNoDesk(products.GetProducts);
        }

        private void ValidateDeskno(Products products) {
            foreach (var article in products.GetProducts) {
                if (article.DeskNo != (int)Desks.Desk1 &&
                    article.DeskNo != (int)Desks.Desk2 &&
                    article.DeskNo != (int)Desks.Desk3 &&
                    article.DeskNo != (int)Desks.Desk4)
                    article.DeskNo = -1;
            }
        }

        public void UpdateProductsPlaces() {
            //todo wpisac miejsca produktow do kolekcji

            foreach (var article in Desk1) {
                article.DeskNo = (int) Desks.Desk1;
            }
            foreach (var article in Desk2) {
                article.DeskNo = (int) Desks.Desk2;
            }
            foreach (var article in Desk3) {
                article.DeskNo = (int)Desks.Desk3;
            }
            foreach (var article in Desk4) {
                article.DeskNo = (int) Desks.Desk4;
            }
            foreach (var article in AllArticleToDesk) {
                article.DeskNo = (int) Desks.ArtNoSort;
            }
        }
    }
}