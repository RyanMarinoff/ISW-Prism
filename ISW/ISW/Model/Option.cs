using System;

namespace ISW.Model
{
    class Option : IEquatable<Option>
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
            if (other == null)
                return false;
            return _id.Equals(other.ID);
        }

        public bool Equals(int otherID)
        {
            return _id.Equals(otherID);
        }

        public static bool operator ==(Option a, Option b)
        {
            if (object.ReferenceEquals(a, b))
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
    }
}
