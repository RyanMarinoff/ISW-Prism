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
        public ProductViewModel()
        {
            LoadProducts();
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
            }
        }
    }
}
