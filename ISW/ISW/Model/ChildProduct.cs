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

namespace ISW.Model
{
    class ChildProduct : Product, IEquatable<ChildProduct>
    {
        // ***************
        // * Constructor *
        // ***************

        public ChildProduct(ParentProduct Parent) : base(Parent.ID)
        {
            UpdateData(Parent as Product);
        }

        // public ChildProduct(string id) : base(id) { }

        // **********
        // * Fields *
        // **********

            // Number of shoes in stock [int] stockstatus
        private int _stockStatus;
        public int StockStatus
        {
            get { return _stockStatus; }
            set { _stockStatus = value; }
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
            return ID.GetHashCode();
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
    }
}
