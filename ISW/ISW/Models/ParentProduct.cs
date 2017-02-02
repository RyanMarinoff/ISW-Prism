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
using System;
using System.Collections.Generic;

namespace ISW.Models
{
    class ParentProduct : Product
    {
        // ***************
        // * Constructor *
        // ***************

        public ParentProduct(string ProductCode) : base(ProductCode)
        {
            // initialize list
            _childProducts = new List<ChildProduct>();
        }

        // ***********************
        // * Derrived Properties *
        // ***********************

        // Product Code [string] productcode
        public override string ID
        {
            get { return _id; }
        }

        // List of Category IDs assigned to the shoe [List<Category>] categoryids
        public override List<Category> Categories {
            get { return _categories; }
            set
            {
                SetProperty(ref _categories, value);
                OnPropertyChanged(() => ID);
            }
        }

        // List of Option IDs assigned to the shoe [List<Option>] optionids
        public override List<Option> Options
        {
            get { return _options; }
            set
            {
                SetProperty(ref _options, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Product Name [string] productname
        public override string Name {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Shortened version of the product name [string] productnameshort
        public override string ShortName
        {
            get { return _shortName; }
            set
            {
                SetProperty(ref _shortName, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Short statement of product(mens/womens/accessories) [string] productdescriptionshort
        public override string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                SetProperty(ref _shortDescription, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Date product first displayed [DateTime] displaybegindate
        public override DateTime? DisplayBeginDate
        {
            get { return _displayBeginDate; }
            set
            {
                SetProperty(ref _displayBeginDate, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Is the product taxable [bool] taxableproduct
        public override bool? Taxable
        {
            get { return _taxable; }
            set
            {
                SetProperty(ref _taxable, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Is the product hidden [bool] hideproduct
        public override bool? Hidden
        {
            get { return _hidden; }
            set
            {
                SetProperty(ref _hidden, value);
                OnPropertyChanged(() => ID);
            }
        }

        public bool IsHidden
        {
            get
            {
                return _hidden == true;
            }
        }

        // SEO Title [string] metatag_title
        public override string MetaTagTitle
        {
            get { return _metaTagTitle; }
            set
            {
                SetProperty(ref _metaTagTitle, value);
                OnPropertyChanged(() => ID);
            }
        }

        // SEO Description [string] metatag_description
        public override string MetaTagDescription
        {
            get { return _metaTagDescription; }
            set
            {
                SetProperty(ref _metaTagDescription, value);
                OnPropertyChanged(() => ID);
            }
        }

        // SEO Photo alternative text [string] photo_alttext
        public override string PhotoAltText
        {
            get { return _photoAltText; }
            set
            {
                SetProperty(ref _photoAltText, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Is the product designated as a sale product [string] customfield1
        public override string SaleText
        {
            get { return _saleText; }
            set
            {
                SetProperty(ref _saleText, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Manufacturer of the product [string] productmanufacturer
        public override string ItemVendor
        {
            get { return _itemVendor; }
            set
            {
                SetProperty(ref _itemVendor, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Price of product [float] productprice
        //   ** Issues with Internet database requires this field
        public override float? ProductPrice
        {
            get { return _productPrice; }
            set
            {
                SetProperty(ref _productPrice, value);
                OnPropertyChanged(() => ID);
            }
        }

        // *****************************
        // * New Fields and Properties *
        // *****************************

        //List of Child Products assigned to the shoe [List] ischildofproductcode
        private List<ChildProduct> _childProducts;
        public List<ChildProduct> ChildProducts
        {
            get { return _childProducts; }
            set
            {
                SetProperty(ref _childProducts, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Determine if seen on home page [int? or bool] homepage_section
        //   ** Note: Unsure if this should be an int or bool. 
        //   ** This will be determined during testing of data from the downloaded database.
        private bool? _onHomePage;
        public bool? OnHomePage
        {
            get { return _onHomePage; }
            set
            {
                SetProperty(ref _onHomePage, value);
                OnPropertyChanged(() => ID);
            }
        }

        // HTML of product description [string] productdescription
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
                OnPropertyChanged(() => ID);
            }
        }

        // Keyword for SEO (no longer to be used, blank it out) [string] metatag_keywords
        private string _metaTagKeywords;
        public string MetaTagKeywords
        {
            get { return _metaTagKeywords; }
            set
            {
                SetProperty(ref _metaTagKeywords, value);
                OnPropertyChanged(() => ID);
            }
        }

        // ************************
        // * additional accessors *
        // ************************

        public int GetInventoryCount
        {
            get
            {
                int count = 0;
                foreach(ChildProduct child in _childProducts)
                {
                    count += child.StockStatus;
                }
                return count;
            }
        }

        // *************
        // * overrides *
        // *************

        // ToString
        public override string ToString()
        {
            return "ID: " + ID + " - " + Name;
        }

        // GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals(obj as ParentProduct);
        }
        public bool Equals(ParentProduct other)
        {
            if (other == default(ParentProduct))
                return false;
            return Equals(other.ID);
        }

        // Comparison Operators
        //public static bool operator ==(ParentProduct a, ParentProduct b)
        //{
        //    if (ReferenceEquals(a, b))
        //        return true;
        //    return a.Equals(b);
        //}

        //public static bool operator !=(ParentProduct a, ParentProduct b)
        //{
        //    return !(a == b);
        //}

        //public static bool operator ==(ParentProduct a, string b)
        //{
        //    return a.Equals(b);
        //}

        //public static bool operator !=(ParentProduct a, string b)
        //{
        //    return !(a == b);
        //}

        //public static bool operator ==(string a, ParentProduct b)
        //{
        //    return (b == a);
        //}

        //public static bool operator !=(string a, ParentProduct b)
        //{
        //    return !(a == b);
        //}

        // ********************
        // * Member Functions *
        // ********************

        // Update Function
        public bool UpdateData(ParentProduct update)
        {
            if (Equals(update))
            {
                UpdateData(update);

                MetaTagKeywords = update.MetaTagKeywords;
                Description = update.Description;
                OnHomePage = update.OnHomePage;

                // Update Child Products with new data
                foreach (var child in update.ChildProducts)
                {
                    var index = ChildProducts.FindIndex(x => x == child);
                    if (index == -1)
                    {
                        ChildProducts.Add(child);
                    }
                    else
                    {
                        ChildProducts[index].UpdateData(child);
                    }
                }

                return true;
            }

            return false;
        }

        // **************************
        // * INotifyPropertyChanged *
        // **************************
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void RaisePropertyChanged(string property)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        //}
    }
}