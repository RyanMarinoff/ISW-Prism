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

namespace ISW.Models
{
    class ChildProduct : Product
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
        public override string Name
        {
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

        // Number of shoes in stock [int] stockstatus
        private int _stockStatus;
        public int StockStatus
        {
            get { return _stockStatus; }
            set
            {
                SetProperty(ref _stockStatus, value);
                OnPropertyChanged(() => ID);
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
        //public static bool operator ==(ChildProduct a, ChildProduct b)
        //{
        //    if (ReferenceEquals(a, b))
        //        return true;
        //    return a.Equals(b);
        //}

        //public static bool operator !=(ChildProduct a, ChildProduct b)
        //{
        //    return !(a == b);
        //}

        //public static bool operator ==(ChildProduct a, string b)
        //{
        //    return a.Equals(b);
        //}

        //public static bool operator !=(ChildProduct a, string b)
        //{
        //    return !(a == b);
        //}

        //public static bool operator ==(string a, ChildProduct b)
        //{
        //    return b.Equals(a);
        //}

        //public static bool operator !=(string a, ChildProduct b)
        //{
        //    return !(a == b);
        //}

        // ********************
        // * Member Functions *
        // ********************

        // Update Function
        public bool UpdateData(ChildProduct update)
        {
            if(Equals(update))
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
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void RaisePropertyChanged(string property)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        //}
    }
}
