using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class ProductModel:INotifyPropertyChanged
    {
        #region Properties
        private int _ProductId;
        public int ProductId {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
                OnPropertyChanged("ProductId");
            }
        }

        private string _ProductName;
        public string ProductName {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                OnPropertyChanged("ProductName");
            }
        }

        private string _ProductDetail;
        public string ProductDetail {
            get
            {
                return _ProductDetail;
            }
            set
            {
                _ProductDetail = value;
                OnPropertyChanged("ProductDetail");
            }
        }

        private int _Price;
        public int Price {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
                OnPropertyChanged("Price");
            }
        }
        
        #endregion

        #region Consructor
        /// <summary>
        /// Yapıcı Metod. Her yeni ürün nesnesi oluşturulduğunda çalışır.
        /// </summary>
        public ProductModel(int Id,string ProductName,string ProductDetail,int Price)
        {
            _ProductId = Id;
            _ProductName = ProductName;
            _ProductDetail = ProductDetail;
            _Price = Price;
        }
        #endregion

        #region PropertyChanged Event
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
