namespace ISW.Model
{
    class ChildProduct : Product
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
    }
}
