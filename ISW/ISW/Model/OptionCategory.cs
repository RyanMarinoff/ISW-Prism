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
    public class OptionCategory : IEquatable<OptionCategory>
    {
        // ***************
        // * Constructor *
        // ***************

        public OptionCategory(int id)
        {
            _id = id;
        }

        // **********
        // * Fields *
        // **********

            // Option Category ID [int] id
        private int _id;
        public int ID
        {
            get { return _id; }
        }

            // Option Category Description [string] optioncategoriesdesc
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // *************
        // * Overloads *
        // *************

            // ToString
        public override string ToString()
        {
            return "ID: " + _id + " - " + _description;
        }

            // GetHashCode
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

            // Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals(obj as OptionCategory);
        }

        public bool Equals(OptionCategory other)
        {
            if (other == default(OptionCategory))
                return false;
            return Equals(other.ID);
        }

        public bool Equals(int other)
        {
            return _id.Equals(other);
        }

            // Comparison Operator
        public static bool operator ==(OptionCategory a, OptionCategory b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(OptionCategory a, OptionCategory b)
        {
            return !(a == b);
        }

        public static bool operator ==(OptionCategory a, int b)
        {
            return a.ID == b;
        }

        public static bool operator !=(OptionCategory a, int b)
        {
            return !(a == b);
        }

        public static bool operator ==(int a, OptionCategory b)
        {
            return b == a;
        }

        public static bool operator !=(int a, OptionCategory b)
        {
            return !(a == b);
        }
    }
}
