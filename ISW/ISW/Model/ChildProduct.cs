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
    class ChildProduct : Product, IEquatable<ChildProduct>, INotifyPropertyChanged
    {
        // ***************
        // * Constructor *
        // ***************

        public ChildProduct(ParentProduct Parent) : base(Parent.ID)
        {
            UpdateData(Parent as Product);
        }

        // public ChildProduct(string id) : base(id) { }
        // ***********************
        // * Derrived Properties *
        // ***********************

        // Product Code [string] productcode
        public override string ID
        {
            get { return _id; }
        }

        // List of Category IDs assigned to the shoe [List<Category>] categoryids
        public override List<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Child_CategoryIDs");
            }
        }

        // List of Option IDs assigned to the shoe [List<Option>] optionids
        public override List<Option> Options
        {
            get { return _options; }
            set
            {
                _options = value;
                RaisePropertyChanged("Child_OptionIDs");
            }
        }

        // Product Name [string] productname
        public override string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Child_ProductName");
            }
        }

        // Shortened version of the product name [string] productnameshort
        public override string ShortName
        {
            get { return _shortName; }
            set
            {
                _shortName = value;
                RaisePropertyChanged("Child_ProductNameShort");
            }
        }

        // Short statement of product(mens/womens/accessories) [string] productdescriptionshort
        public override string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                _shortDescription = value;
                RaisePropertyChanged("Child_ProductDescriptionShort");
            }
        }


        // Date product first displayed [DateTime] displaybegindate
        public override DateTime? DisplayBeginDate
        {
            get { return _displayBeginDate; }
            set
            {
                _displayBeginDate = value;
                RaisePropertyChanged("Child_DisplayBeginDate");
            }
        }

        // Is the product taxable [bool] taxableproduct
        public override bool? Taxable
        {
            get { return _taxable; }
            set
            {
                _taxable = value;
                RaisePropertyChanged("Child_TaxableProduct");
            }
        }

        // Is the product hidden [bool] hideproduct
        public override bool? Hidden
        {
            get { return _hidden; }
            set
            {
                _hidden = value;
                RaisePropertyChanged("Child_HideProduct");
            }
        }

        // SEO Title [string] metatag_title
        public override string MetaTagTitle
        {
            get { return _metaTagTitle; }
            set
            {
                _metaTagTitle = value;
                RaisePropertyChanged("Child_METATAG_Title");
            }
        }

        // SEO Description [string] metatag_description
        public override string MetaTagDescription
        {
            get { return _metaTagDescription; }
            set
            {
                _metaTagDescription = value;
                RaisePropertyChanged("Child_METAGAG_Description");
            }
        }

        // SEO Photo alternative text [string] photo_alttext
        public override string PhotoAltText
        {
            get { return _photoAltText; }
            set
            {
                _photoAltText = value;
                RaisePropertyChanged("Child_Photo_AltText");
            }
        }

        // Is the product designated as a sale product [string] customfield1
        public override string SaleText
        {
            get { return _saleText; }
            set
            {
                _saleText = value;
                RaisePropertyChanged("Child_CustomField1");
            }
        }

        // Manufacturer of the product [string] productmanufacturer
        public override string ItemVendor
        {
            get { return _itemVendor; }
            set
            {
                _itemVendor = value;
                RaisePropertyChanged("Child_ProductManufacturer");
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
                RaisePropertyChanged("Child_ProductPrice");
            }
        }

        // *****************************
        // * New Fields and Properties *
        // *****************************

        // Number of shoes in stock [int] stockstatus
        private int _stockStatus;
        public int StockStatus
        {
            get { return _stockStatus; }
            set
            {
                _stockStatus = value;
                RaisePropertyChanged("StockStatus");
            }
        }

        // *************
        // * Overloads *
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
            return Equals(obj as ChildProduct);
        }

        public bool Equals(ChildProduct other)
        {
            if (other == default(ChildProduct))
                return false;
            return Equals(other.ID);
        }

            // Operators
        public static bool operator ==(ChildProduct a, ChildProduct b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(ChildProduct a, ChildProduct b)
        {
            return !(a == b);
        }

        public static bool operator ==(ChildProduct a, string b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ChildProduct a, string b)
        {
            return !(a == b);
        }

        public static bool operator ==(string a, ChildProduct b)
        {
            return b.Equals(a);
        }

        public static bool operator !=(string a, ChildProduct b)
        {
            return !(a == b);
        }

        // ********************
        // * Member Functions *
        // ********************

        // Update Function
        public bool UpdateData(ChildProduct update)
        {
            if(this == update)
            {
                UpdateData(update as Product);

                StockStatus = update.StockStatus;

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
