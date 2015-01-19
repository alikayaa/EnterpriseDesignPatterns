using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Commands
{
    internal class ProductDeleteCommand:ICommand
    {
        #region Consructor
        public ProductDeleteCommand(ProductViewModel ViewModel)
        {
            _viewModel = ViewModel;
        }

        #region Properties
        private ProductViewModel _viewModel;
        #endregion

        #endregion
        #region Command Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanDelete;
        }

        public void Execute(object parameter)
        {
            _viewModel.DeleteProduct();
        }

        #endregion
    }
}
