using System.Collections.ObjectModel;

namespace RuchProstokata1 {
    public class ArticlesRepository {
        private Products generProducts;

        public Products GenerProducts {
            get { return generProducts; }
            set { generProducts = value; }
        }

        public Products SetToShoping(string pathToImages) {
            var toShoping = new Products();

            #region Demo1

            /*  Article artTest1 = new Article() {
                Name = "Maslo",
                ImagePath = pathToImages + "maslo.png",
                GraphElem = null,
                Price = 3.4m,
                Quantity = 100,
                IsForShooping = true,
            };
            Article artTest2 = new Article() {
                Name = "Mleko",
                ImagePath = pathToImages + "mleko.png",
                GraphElem = null,
                Price = 0.89m,
                Quantity = 50,
                IsForShooping = true,
            };
            Article artTest3 = new Article() {
                Name = "Cukier",
                ImagePath = pathToImages + "cukier.png",
                GraphElem = null,
                Price = 3.99m,
                Quantity = 200,
                IsForShooping = true,
            };
            toShoping.AddArticle(artTest1);
            toShoping.AddArticle(artTest2);
            toShoping.AddArticle(artTest3);*/

            #endregion

            if (generProducts == null) generProducts = GenerSomeOfProducts(pathToImages);

            foreach (Article article in generProducts.GetProducts) {
                if (article.IsForShooping) {
                    toShoping.AddArticle(article);
                }
            }
            return toShoping;
        }

        public Products GenerSomeOfProductsDB(string patthImages, ObservableCollection<Article> articlesDB) {
            var products = new Products();
            foreach (var articleDB in articlesDB) {
                products.AddArticle(articleDB);
            }
            if (products.GetNumberOfProducts() > 0) return products;
            return null;

        }
        public Products GenerSomeOfProducts(string pathToImages) {
            var products = new Products();
            #region ArticleTestGener
            var artTest1 = new Article {
                Name = "Maslo",
                ImagePath = pathToImages + "maslo.png",
                GraphElem = null,
                Price = 3.4m,
                Quantity = 100,
                IsForShooping = true,
                PlaceNo = 0,
                DeskNo = 1,
            };
            var artTest2 = new Article {
                Name = "Mleko",
                ImagePath = pathToImages + "mleko.png",
                GraphElem = null,
                Price = 0.89m,
                Quantity = 50,
                IsForShooping = true,
                PlaceNo = 1,
                DeskNo = 1,
            };
            var artTest3 = new Article {
                Name = "Cukier",
                ImagePath = pathToImages + "cukier.png",
                GraphElem = null,
                Price = 3.99m,
                Quantity = 200,
                IsForShooping = false,
                PlaceNo = 2,
                DeskNo = 1,
            };
            var artTest4 = new Article {
                Name = "Śmietana",
                ImagePath = pathToImages + "smietana.png",
                GraphElem = null,
                Price = 1.99m,
                Quantity = 1000,
                IsForShooping = false,
                PlaceNo = 3,
                DeskNo = 1,
            };
            var artTest5 = new Article {
                Name = "Bułka",
                ImagePath = pathToImages + "bulka.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 100,
                IsForShooping = true,
                DeskNo = 1,
            };
            var artTest6 = new Article {
                Name = "Makaron",
                ImagePath = pathToImages + "makaron.png",
                GraphElem = null,
                Quantity = 5.00,
                IsForShooping = false,
                Price = 3.49M,
                DeskNo = 1,
            };
            var artTest7 = new Article {
                Name = "Cukierki",
                ImagePath = pathToImages + "cukierki.png",
                GraphElem = null,
                Price = 7.40m,
                Quantity = 100,
                IsForShooping = false,
                DeskNo = 1,
            };
            var artTest8 = new Article {
                Name = "Czekolada",
                ImagePath = pathToImages + "czekolada.png",
                GraphElem = null,
                Price = 0.89m,
                Quantity = 50,
                IsForShooping = false,
                DeskNo = 2,
            };
            var artTest9 = new Article {
                Name = "Woda gazow.",
                ImagePath = pathToImages + "woda_gaz.png",
                GraphElem = null,
                Price = 3.99m,
                Quantity = 200,
                IsForShooping = false,
                DeskNo = 2,
            };
            var artTest10 = new Article {
                Name = "Kawa",
                ImagePath = pathToImages + "kawa.png",
                GraphElem = null,
                Price = 11.99m,
                Quantity = 1000,
                IsForShooping = false,
                DeskNo = 2,
            };
            var artTest11 = new Article {
                Name = "Ser",
                ImagePath = pathToImages + "ser_z.png",
                GraphElem = null,
                Price = 7.99m,
                Quantity = 100,
                IsForShooping = false,
                DeskNo = 2,
            };
            var artTest12 = new Article {
                Name = "Inna Woda gaz",
                ImagePath = pathToImages + "woda_gaz2.png",
                GraphElem = null,
                Quantity = 5.00,
                IsForShooping = true,
                Price = 1.49M,
            };
            var artTest13 = new Article {
                Name = "Banany",
                ImagePath = pathToImages + "png\\banany2.png",
                GraphElem = null,
                Quantity = 10.00,
                Price = 3.99m,
                IsForShooping = true,
            };
            var artTest14 = new Article {
                Name = "Cukier2",
                ImagePath = pathToImages + "png\\cukier.png",
                GraphElem = null,
                Price = 2.99m,
                Quantity = 100,
                IsForShooping = true,
            };
            var artTest15 = new Article {
                Name = "Kiełbasa zwycz.",
                ImagePath = pathToImages + "png\\kielbasa.png",
                GraphElem = null,
                Price = 7.89m,
                Quantity = 20,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest16 = new Article {
                Name = "Żelki cukierki",
                ImagePath = pathToImages + "png\\zelki.png",
                GraphElem = null,
                Price = 4.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest17 = new Article {
                Name = "Pasztet",
                ImagePath = pathToImages + "png\\pasztet.png",
                GraphElem = null,
                Price = 6.49m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest18 = new Article {
                Name = "Pomarańcze",
                ImagePath = pathToImages + "png\\pomarancze.png",
                GraphElem = null,
                Price = 23.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest19 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest20 = new Article {
                Name = "pasta do zebow",
                ImagePath = pathToImages + "pasta do zebow.jpg",
                GraphElem = null,
                Price = 13.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest21 = new Article {
                Name = "zel pod prysznic",
                ImagePath = pathToImages + "zel pod prysznic.jpg",
                GraphElem = null,
                Price = 10.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 3,
            };
            var artTest22 = new Article {
                Name = "krem nivea",
                ImagePath = pathToImages + "krem nivea.jpg",
                GraphElem = null,
                Price = 3.79m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest23 = new Article {
                Name = "szampon do wlosow",
                ImagePath = pathToImages + "szampon do wlosow.jpg",
                GraphElem = null,
                Price = 13.90m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest24 = new Article {
                Name = "zel do golenia",
                ImagePath = pathToImages + "zel do golenia.jpg",
                GraphElem = null,
                Price = 15.99m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest25 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest26 = new Article {
                Name = "mydlo",
                ImagePath = pathToImages + "mydlo.jpg",
                GraphElem = null,
                Price = 2.19m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };

            var artTest27 = new Article {
                Name = "mydlo kostka",
                ImagePath = pathToImages + "mydlo kostka.jpg",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest28 = new Article {
                Name = "plyn do mycia rak",
                ImagePath = pathToImages + "plyn do mycia rak.jpg",
                GraphElem = null,
                Price = 2.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest29 = new Article {
                Name = "prezerwatywy",
                ImagePath = pathToImages + "prezerwatywy.jpg",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest30 = new Article {
                Name = "plyn do plukania ust",
                ImagePath = pathToImages + "plyn do plukania ust.jpg",
                GraphElem = null,
                Price = 19.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest31 = new Article {
                Name = "krem ochronny",
                ImagePath = pathToImages + "krem ochronny.jpg",
                GraphElem = null,
                Price = 10.90m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest32 = new Article {
                Name = "dezodorant",
                ImagePath = pathToImages + "dezodorant.jpg",
                GraphElem = null,
                Price = 11.90m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest33 = new Article {
                Name = "szczoteczka do zebow",
                ImagePath = pathToImages + "szczoteczka do zebow.jpg",
                GraphElem = null,
                Price = 6.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest34 = new Article {
                Name = "oliwka bambino",
                ImagePath = pathToImages + "oliwka bambino.jpg",
                GraphElem = null,
                Price = 11.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest35 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };

            var artTest36 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
                DeskNo = 4,
            };
            var artTest37 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest38 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest39 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
            };
            var artTest40 = new Article {
                Name = "Papier toaletowy",
                ImagePath = pathToImages + "png\\papier toaletowy.png",
                GraphElem = null,
                Price = 0.99m,
                Quantity = 10,
                IsForShooping = true,
            };
            
            #endregion
            products.AddArticle(artTest1);
            products.AddArticle(artTest2);
            products.AddArticle(artTest3);
            products.AddArticle(artTest4);
            products.AddArticle(artTest5);
            products.AddArticle(artTest6);

            products.AddArticle(artTest7);
            products.AddArticle(artTest8);
            products.AddArticle(artTest9);
            products.AddArticle(artTest10);
            products.AddArticle(artTest11);
            products.AddArticle(artTest12);
            products.AddArticle(artTest13);
            products.AddArticle(artTest14);
            products.AddArticle(artTest15);
            products.AddArticle(artTest16);
            products.AddArticle(artTest17);
            products.AddArticle(artTest18);
            products.AddArticle(artTest19);
            products.AddArticle(artTest20);
            products.AddArticle(artTest21);
            products.AddArticle(artTest22);
            products.AddArticle(artTest23);
            products.AddArticle(artTest24);
            products.AddArticle(artTest25);
            products.AddArticle(artTest26);
            products.AddArticle(artTest27);
            products.AddArticle(artTest28);
            products.AddArticle(artTest29);
            products.AddArticle(artTest30);
            products.AddArticle(artTest31);
            products.AddArticle(artTest32);
            products.AddArticle(artTest33);
            products.AddArticle(artTest34);
            products.AddArticle(artTest35);
            products.AddArticle(artTest36);
            products.AddArticle(artTest37);
            products.AddArticle(artTest38);
            products.AddArticle(artTest39);
            products.AddArticle(artTest40);
            generProducts = products;
           
                return products;
        }
    }
}