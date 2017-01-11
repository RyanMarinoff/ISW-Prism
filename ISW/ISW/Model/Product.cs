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

namespace ISW.Model
{
    public abstract class Product : IEquatable<Product>
    {
        // ***************
        // * Constructor *
        // ***************

        public Product(string productCode)
        {
            _id = productCode;

            // initialize the lists
            _categories = new List<Category>();
            _options = new List<Option>();
        }

        // **********
        // * Fields *
        // **********

        // Product Code [string] productcode
        protected string _id;
        public abstract string ID { get; }

        // List of Category IDs assigned to the shoe [List<Category>] categoryids
        protected List<Category> _categories;
        public abstract List<Category> Categories { get; set; }

        // List of Option IDs assigned to the shoe [List<Option>] optionids
        protected List<Option> _options;
        public abstract List<Option> Options { get; set; }

        // Product Name [string] productname
        protected string _name;
        public abstract string Name { get; set; }

        // Shortened version of the product name [string] productnameshort
        protected string _shortName;
        public abstract string ShortName { get; set; }

        // Short statement of product(mens/womens/accessories) [string] productdescriptionshort
        protected string _shortDescription;
        public abstract string ShortDescription { get; set; }

        // Date product first displayed [DateTime] displaybegindate
        protected DateTime? _displayBeginDate;
        public abstract DateTime? DisplayBeginDate { get; set; }

        // Is the product taxable [bool] taxableproduct
        protected bool? _taxable;
        public abstract bool? Taxable { get; set; }

        // Is the product hidden [bool] hideproduct
        protected bool? _hidden;
        public abstract bool? Hidden { get; set; }

        // SEO Title [string] metatag_title
        protected string _metaTagTitle;
        public abstract string MetaTagTitle { get; set; }

        // SEO Description [string] metatag_description
        protected string _metaTagDescription;
        public abstract string MetaTagDescription { get; set; }

        // SEO Photo alternative text [string] photo_alttext
        protected string _photoAltText;
        public abstract string PhotoAltText { get; set; }

        // Is the product designated as a sale product [string] customfield1
        protected string _saleText;
        public abstract string SaleText { get; set; }

        // Manufacturer of the product [Vendor] productmanufacturer
        //private Vendor _itemVendor;
        //public Vendor ItemVendor
        //{
        //    get { return _itemVendor; }
        //    set { _itemVendor = value; }
        //}

        // Manufacturer of the product [string] productmanufacturer
        protected string _itemVendor;
        public abstract string ItemVendor { get; set; }

        // Price of product [float] productprice
        //   ** Issues with Internet database requires this field
        protected float? _productPrice;
        public abstract float? ProductPrice { get; set; }

        // *************
        // * Overloads *
        // *************

        // GetHashCode
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals(obj as Product);
        }

        public bool Equals(Product other)
        {
            if (other == default(Product))
                return false;
            return Equals(other._id);
        }

        // *** Main Compairison Operator for Products! ***
        public bool Equals(string otherID)
        {
            return string.Equals(_id, otherID);
        }

        // Comparison Operators
        public static bool operator ==(Product a, Product b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }
        public static bool operator !=(Product a, Product b)
        {
            return !(a == b);
        }

        public static bool operator ==(Product a, string b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Product a, string b)
        {
            return !(a == b);
        }

        public static bool operator ==(string a, Product b)
        {
            return (b == a);
        }

        public static bool operator !=(string a, Product b)
        {
            return !(a == b);
        }
        // *******************
        // * Member Fuctions *
        // *******************

        public bool UpdateData(Product update)
        {
            if (this == update)
            {
                _name = update._name;
                _displayBeginDate = update._displayBeginDate;
                _taxable = update._taxable;
                _hidden = update._hidden;
                _shortName = update._shortName;
                _shortDescription = update._shortDescription;
                _metaTagDescription = update._metaTagDescription;
                _metaTagTitle = update._metaTagTitle;
                _photoAltText = update._photoAltText;
                _saleText = update._saleText;
                _itemVendor = update._itemVendor;
                _productPrice = update._productPrice;

                // Do not update changes within Categories within Products
                foreach (var category in update._categories)
                {
                    var index = _categories.FindIndex(x => x == category);
                    if (index == -1)
                    {
                        _categories.Add(category);
                    }
                }

                // Do not update changes within Options within Products
                foreach (var option in update._options)
                {
                    var index = _options.FindIndex(x => x == option);
                    if (index == -1)
                    {
                        _options.Add(option);
                    }
                }

                return true;
            }

            return false;
        }

    }
}
