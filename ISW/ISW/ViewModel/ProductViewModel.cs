using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using ISW.Model;
using ISW.IoC;

namespace ISW.ViewModel
{
    class ProductViewModel : BindableBase
    {
        public MyICommand DeleteCommand { get; set; }

        public ProductViewModel()
        {
            LoadProducts();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        public ObservableCollection<ParentProduct> Products { get; set; }

        public void LoadProducts()
        {
            ObservableCollection<ParentProduct> products = new ObservableCollection<ParentProduct>(IDataLoader.Products);

            Products = products;
        }

        private ParentProduct _selectedProduct;

        public ParentProduct SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
            Products.Remove(SelectedProduct);
        }

        private bool CanDelete()
        {
            return SelectedProduct as Product != default(ParentProduct);
        }


    }
}
