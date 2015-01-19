using MVVM.Commands;
using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    internal class ProductViewModel
    {
        #region Yapıcı Metod
        /// <summary>
        /// Yapıcı metod. Her yeni Ürün ViewModel nesnesi oluşturulduğunda çalışır.
        /// </summary>
        public ProductViewModel()
        {
            _product = new ProductModel(1,"Macbook Pro","i5 işlemcili Macbook Pro",3400);
            UpdateCommand = new ProductUpdateCommand(this);
            DeleteCommand = new ProductDeleteCommand(this);
        }
        #endregion

        #region Model
        private ProductModel _product;
        /// <summary>
        /// Ürün model nesnesi döner
        /// </summary>
        public ProductModel Product
        {
            get
            {
                return _product;
            }
        }

        #endregion

        #region Model Fonksiyonları
        /// <summary>
        /// Ürünü kaydetme fonksiyonu.
        /// </summary>
        public void UpdateProduct()
        {
            Debug.Assert(false, string.Format("{0} isimli ürün değişiklikleri uygulandı.",_product.ProductName));
        }

        public void DeleteProduct()
        {
            Debug.Assert(false, string.Format("{0} isimli ürün silindi.",_product.ProductName));
        }
        #endregion

        #region Komut Çalışma Koşulları
        public bool CanUpdate
        {
            get
            {
                if (_product == null)
                    return false;
                return !string.IsNullOrEmpty(_product.ProductName) && !string.IsNullOrEmpty(_product.ProductDetail) && _product.Price > 0;
            }
        }

        public bool CanDelete
        {
            get
            {
                if (_product == null)
                    return false;
                return _product.ProductId > 0;
            }
        }

        #endregion

        #region Komutlar
        public ICommand UpdateCommand
        {
            get;
            private set;

        }

        public ICommand DeleteCommand
        {
            get;
            private set;
        }

        #endregion

    }
}
