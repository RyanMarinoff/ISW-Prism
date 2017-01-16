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
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ISW.Model
{
    class ParentProduct : Product, IEquatable<ParentProduct>, INotifyPropertyChanged
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
                _categories = value;
                RaisePropertyChanged("CategoryIDs");
            }
        }

        // List of Option IDs assigned to the shoe [List<Option>] optionids
        public override List<Option> Options
        {
            get { return _options; }
            set
            {
                _options = value;
                RaisePropertyChanged("OptionIDs");
            }
        }

        // Product Name [string] productname
        public override string Name {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("ProductName");
            }
        }

        // Shortened version of the product name [string] productnameshort
        public override string ShortName
        {
            get { return _shortName; }
            set
            {
                _shortName = value;
                RaisePropertyChanged("ProductNameShort");
            }
        }

        // Short statement of product(mens/womens/accessories) [string] productdescriptionshort
        public override string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                _shortDescription = value;
                RaisePropertyChanged("ProductDescriptionShort");
            }
        }

        // Date product first displayed [DateTime] displaybegindate
        public override DateTime? DisplayBeginDate
        {
            get { return _displayBeginDate; }
            set
            {
                _displayBeginDate = value;
                RaisePropertyChanged("DisplayBeginDate");
            }
        }

        // Is the product taxable [bool] taxableproduct
        public override bool? Taxable
        {
            get { return _taxable; }
            set
            {
                _taxable = value;
                RaisePropertyChanged("TaxableProduct");
            }
        }

        // Is the product hidden [bool] hideproduct
        public override bool? Hidden
        {
            get { return _hidden; }
            set
            {
                _hidden = value;
                RaisePropertyChanged("HideProduct");
            }
        }

        // SEO Title [string] metatag_title
        public override string MetaTagTitle
        {
            get { return _metaTagTitle; }
            set
            {
                _metaTagTitle = value;
                RaisePropertyChanged("METATAG_Title");
            }
        }

        // SEO Description [string] metatag_description
        public override string MetaTagDescription
        {
            get { return _metaTagDescription; }
            set
            {
                _metaTagDescription = value;
                RaisePropertyChanged("METAGAG_Description");
            }
        }

        // SEO Photo alternative text [string] photo_alttext
        public override string PhotoAltText
        {
            get { return _photoAltText; }
            set
            {
                _photoAltText = value;
                RaisePropertyChanged("Photo_AltText");
            }
        }

        // Is the product designated as a sale product [string] customfield1
        public override string SaleText
        {
            get { return _saleText; }
            set
            {
                _saleText = value;
                RaisePropertyChanged("CustomField1");
            }
        }

        // Manufacturer of the product [string] productmanufacturer
        public override string ItemVendor
        {
            get { return _itemVendor; }
            set
            {
                _itemVendor = value;
                RaisePropertyChanged("ProductManufacturer");
            }
        }

        // Price of product [float] productprice
        //   ** Issues with Internet database requires this field
        public override float? ProductPrice
        {
            get { return _productPrice; }
            set
            {
                _productPrice = value;
                RaisePropertyChanged("ProductPrice");
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
                _childProducts = value;
                RaisePropertyChanged("IsChildOfProductCode");
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
                _onHomePage = value;
                RaisePropertyChanged("HomePage_Section");
            }
        }

        // HTML of product description [string] productdescription
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("ProductDescription");
            }
        }

        // Keyword for SEO (no longer to be used, blank it out) [string] metatag_keywords
        private string _metaTagKeywords;
        public string MetaTagKeywords
        {
            get { return _metaTagKeywords; }
            set
            {
                _metaTagKeywords = value;
                RaisePropertyChanged("METATAG_Keywords");
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
        public static bool operator ==(ParentProduct a, ParentProduct b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(ParentProduct a, ParentProduct b)
        {
            return !(a == b);
        }

        public static bool operator ==(ParentProduct a, string b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ParentProduct a, string b)
        {
            return !(a == b);
        }

        public static bool operator ==(string a, ParentProduct b)
        {
            return (b == a);
        }

        public static bool operator !=(string a, ParentProduct b)
        {
            return !(a == b);
        }

        // ********************
        // * Member Functions *
        // ********************

        // Update Function
        public bool UpdateData(ParentProduct update)
        {
            if (this == update)
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
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
