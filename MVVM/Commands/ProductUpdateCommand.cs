using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Commands
{
    internal class ProductUpdateCommand:ICommand
    {

        #region Constructor
        /// <summary>
        /// Yapıcı metod. Her komut nesnesi oluşturulduğunda çalışır.
        /// </summary>
        /// <param name="ViewModel"></param>
        public ProductUpdateCommand(ProductViewModel ViewModel)
        {
            _viewModel = ViewModel;
        }
        #endregion

        #region Properties
        private ProductViewModel _viewModel;
        #endregion

        #region Command Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _viewModel.UpdateProduct();
        }

        #endregion
    }
}
