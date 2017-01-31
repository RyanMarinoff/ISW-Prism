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

using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;


using ISW.Models;
using System.Collections.ObjectModel;
using ISW.IoC;
using System.Collections.Generic;
using System.Linq;

namespace ISW.ViewModels
{
    internal class ProductList : BindableBase
    {
        private readonly List<ParentProduct> _products = new List<ParentProduct>(IDataLoader.Products);

        public IReadOnlyCollection<ProductViewModel> TheCollection => _products.Select(x => new ProductViewModel(x)).ToList();
    }

    class ProductViewModel : BindableBase
    {
        public ProductViewModel(ParentProduct product)
        {
            _product = product;
            VerifyCommand = new DelegateCommand(() =>
            {

            }, () => !string.IsNullOrWhiteSpace(ID) && !string.IsNullOrWhiteSpace(Name));
        }

        public string ID => _product.ID;
        public string Name => _product.Name;

        public DelegateCommand VerifyCommand { get; }

        private readonly ParentProduct _product;
    }
}
