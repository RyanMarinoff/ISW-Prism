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
