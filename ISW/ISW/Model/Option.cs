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
    public class Option : IEquatable<Option>
    {
        public Option(int id)
        {
            _id = id;
        }

        // Option ID [int] id
        private int _id;
        public int ID
        {
            get { return _id; }
        }

        // Option Description [string] optionsdesc
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Display Order [int] arrangeoptionsby
        private int? _arrangeOptionsBy;
        public int? ArrangeOptionsBy
        {
            get { return _arrangeOptionsBy; }
            set { _arrangeOptionsBy = value; }
        }

        // Option Category ID [OptionCategory] optioncatid
        private OptionCategory _optionCategory;
        public OptionCategory Category
        {
            get { return _optionCategory; }
            set { _optionCategory = value; }
        }

        // Overloads
        public override string ToString()
        {
            return "ID: " + _id + " - " + _description;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals(obj as Option);
        }

        public bool Equals(Option other)
        {
            if (other == default(Option))
                return false;
            return Equals(other.ID);
        }

        public bool Equals(int otherID)
        {
            return _id.Equals(otherID);
        }

        public static bool operator ==(Option a, Option b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(Option a, Option b)
        {
            return !(a == b);
        }

        public static bool operator ==(Option a, int b)
        {
            return a.ID == b;
        }

        public static bool operator !=(Option a, int b)
        {
            return !(a == b);
        }

        public static bool operator ==(int a, Option b)
        {
            return b == a;
        }
        public static bool operator !=(int a, Option b)
        {
            return !(a == b);
        }

        internal bool UpdateData(Option option)
        {
            throw new NotImplementedException();
        }
    }
}
