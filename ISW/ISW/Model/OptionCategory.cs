using System;

namespace ISW.Model
{
    class OptionCategory : IEquatable<OptionCategory>
    {
        public OptionCategory(int id)
        {
            _id = id;
        }

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
            return Equals(obj as OptionCategory);
        }

        public bool Equals(OptionCategory other)
        {
            if (other == default(OptionCategory))
                return false;
            return _id.Equals(other.ID);
        }

        public bool Equals(int other)
        {
            return _id.Equals(other);
        }

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
    }
}
