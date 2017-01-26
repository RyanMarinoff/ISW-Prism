using ISW.IoC;
using ISW.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISW.ViewModel
{
    class TestViewModel : BindableBase
    {
        public TestViewModel()
        {
            LoadProducts();
        }

        public ObservableCollection<ParentProduct> Product5 { get; set; }

        public void LoadProducts()
        {
            ObservableCollection<ParentProduct> products = new ObservableCollection<ParentProduct>(IDataLoader.Products);

            Product5 = products;

            for(int i = 0; i < Product5.Count; i++)
            {
                if(Product5[i].GetInventoryCount < 5 || Product5[i].IsHidden)
                {
                    Product5.RemoveAt(i);
                    i--;
                }
            }
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
