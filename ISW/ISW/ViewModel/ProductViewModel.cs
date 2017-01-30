/**************************************************************************
 *                                                                        *
 *  ISW - Internet Sales Work    Internet task assistance application.    *
 *  Copyright (C) 2016  Ryan Marinoff                                     *
 *                                                                        *
 *  This program is free software: you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation, either version 3 of the License, or     *
 *  (at your option) any later version.                                   *
 *                                                                        *
 *  This program is distributed in the hope that it will be useful,       *
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *  GNU General Public License for more details.                          *
 *                                                                        *
 *  You should have received a copy of the GNU General Public License     *
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *                                                                        *
 **************************************************************************/

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
