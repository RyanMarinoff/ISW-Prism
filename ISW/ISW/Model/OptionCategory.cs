using System;

namespace ISW.Model
{
    class OptionCategory : IEquatable<OptionCategory>
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
