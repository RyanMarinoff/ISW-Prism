using System;

namespace ISW.Model
{
    class Vendor : IEquatable<Vendor>
    {
        // all vendors must contain an id, which cannot change.
        public Vendor(int id)
        {
            _id = id;
        }

        // Vendor ID [int] vendor_id
        private int _id;
        public int ID
        {
            get { return _id; }
        }
        // Name of Vendor [string] vendor_title
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        // PO Template [string] vendor_po_template
        private string _poTemplate;
        public string PoTemplate
        {
            get { return _poTemplate; }
            set { _poTemplate = value; }
        }

        // Overloads
        public override string ToString()
        {
            return "ID: " + _id + " - " + _title;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals(obj as Vendor);
        }

        public bool Equals(Vendor other)
        {
            if (other == default(Vendor))
                return false;
            return Equals(other.ID);
        }

        public bool Equals(int otherID)
        {
            return _id.Equals(otherID);
        }

        public static bool operator ==(Vendor a, Vendor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(Vendor a, Vendor b)
        {
            return !(a == b);
        }

        public static bool operator ==(Vendor a, int b)
        {
            return a.ID == b;
        }

        public static bool operator !=(Vendor a, int b)
        {
            return !(a == b);
        }

        public static bool operator ==(int a, Vendor b)
        {
            return b == a;
        }

        public static bool operator !=(int a, Vendor b)
        {
            return !(a == b);
        }
    }
}
