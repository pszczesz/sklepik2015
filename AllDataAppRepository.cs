using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RuchProstokata1 {
    public class AllDataAppRepository {
        #region fields

        private static string ImageDir = "images\\";
        private ObservableCollection<Client> clients;
        private ObservableCollection<Article> articles;
        private ArticlesRepository myArticlesRepository = new ArticlesRepository();
        private ArticlesFromDatabase _articlesFromDatabase;
        public ArticlesFromDatabase FromDatabase { get { return _articlesFromDatabase; } }
        private Products products;
        public Products GetProducts() {
            return products;
        }
        private Products productsForShoping;
        private string imagePath = AppDomain.CurrentDomain.BaseDirectory + ImageDir;
        private DragDropData dragDropData;
 
        #endregion

        //----------properties-------------------------------

        #region Properities
        public ObservableCollection<Client> Clients {
            get { return clients; }
        }

        public ObservableCollection<Article> Articles {
            get { return articles; }
        }

        public ArticlesRepository MyArticlesRepository {
            get { return myArticlesRepository; }
        }

        public Products MyProducts {
            get { return products; }
        }

        public Products ProductsForShoping {
            get { return productsForShoping; }
        }

        public string ImagePath {
            get { return imagePath; }
        }

       public DragDropData MyDragDropData{
           get { return dragDropData; }
            set { dragDropData = value; }
       }
        
        #endregion
        //------------- metods------------------------------ 
        public AllDataAppRepository() {
            clients = new ObservableCollection<Client>();
            clients.Add(new Client() {Cash = 100m, IsCalculate = true, IsShowList = true, IsLearning = false,
                Name = "TestClient1"});
           // products = myArticlesRepository.GenerSomeOfProducts(imagePath);
            _articlesFromDatabase = new ArticlesFromDatabase(imagePath);
            products = myArticlesRepository.GenerSomeOfProductsDB(imagePath, _articlesFromDatabase.ArticleDB);
            articles = new ObservableCollection<Article>();
            productsForShoping = myArticlesRepository.SetToShoping(imagePath);
            MyDragDropData = new DragDropData(products);
        }
    }
}