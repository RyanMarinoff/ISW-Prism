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
    class ParentProduct : Product, IEquatable<ParentProduct>
    {
        // ***************
        // * Constructor *
        // ***************

        public ParentProduct(string ProductCode) : base(ProductCode)
        {
            // initialize list
            _childProducts = new List<ChildProduct>();
        }

        // *************************
        // * Fields and Properties *
        // *************************

            //List of Child Products assigned to the shoe [List] ischildofproductcode
        private List<ChildProduct> _childProducts;
        public List<ChildProduct> ChildProducts
        {
            get { return _childProducts; }
            set { _childProducts = value; }
        }

            // Determine if seen on home page [int? or bool] homepage_section
            //   ** Note: Unsure if this should be an int or bool. 
            //   ** This will be determined during testing of data from the downloaded database.
        private bool? _onHomePage;
        public bool? OnHomePage
        {
            get { return _onHomePage; }
            set { _onHomePage = value; }
        }

            // HTML of product description [string] productdescription
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

            // Keyword for SEO (no longer to be used, blank it out) [string] metatag_keywords
        private string _metaTagKeywords;
        public string MetaTagKeywords
        {
            get { return _metaTagKeywords; }
            set { _metaTagKeywords = value; }
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
            return ID.GetHashCode();
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
            if(this == update)
            {
                UpdateData(update as Product);

                MetaTagKeywords = update.MetaTagKeywords;
                Description = update.Description;
                OnHomePage = update.OnHomePage;

                // Update Child Products with new data
                foreach (var child in update.ChildProducts)
                {
                    var index = ChildProducts.FindIndex(x => x == child);
                    if(index == -1)
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
    }
}
