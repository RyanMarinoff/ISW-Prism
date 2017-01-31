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

using ISW.IoC;
using ISW.Models;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ISW.ViewModels
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
