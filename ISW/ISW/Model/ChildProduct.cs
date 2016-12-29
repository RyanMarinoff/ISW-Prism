using System;

namespace ISW.Model
{
    class ChildProduct : Product, IEquatable<ChildProduct>
    {
        public ChildProduct(ParentProduct Parent) : base(Parent.ID)
        {
            Categories = Parent.Categories;
            Options = Parent.Options;
            Name = Parent.Name;
            ShortName = Parent.ShortName;
            ShortDescription = Parent.ShortDescription;
            DisplayBeginDate = Parent.DisplayBeginDate;
            Taxable = Parent.Taxable;
            Hidden = Parent.Hidden;
            MetaTagTitle = Parent.MetaTagTitle;
            MetaTagDescription = Parent.MetaTagDescription;
            PhotoAltText = Parent.PhotoAltText;
            SaleText = Parent.SaleText;
            ItemVendor = Parent.ItemVendor;
            ProductPrice = Parent.ProductPrice;
        }

        public ChildProduct(string id) : base(id) { }

        // Number of shoes in stock [int] stockstatus
        private int _stockStatus;
        public int StockStatus
        {
            get { return _stockStatus; }
            set { _stockStatus = value; }
        }

        // Overloads
        public override string ToString()
        {
            return "ID: " + ID + " - " + Name;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

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
            return ID.Equals(other.ID);
        }

        public bool Equals(string otherID)
        {
            return string.Equals(ID, otherID);
        }

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
            return string.Equals(a.ID, b);
        }

        public static bool operator !=(ChildProduct a, string b)
        {
            return !(a == b);
        }
    }
}
