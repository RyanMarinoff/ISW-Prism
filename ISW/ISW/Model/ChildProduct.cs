namespace ISW.Model
{
    class ChildProduct : Product
    {
        public ChildProduct(string ProductCode) : base(ProductCode) { }

        // Number of shoes in stock [int] stockstatus
        private int _stockStatus;
        public int StockStatus
        {
            get { return _stockStatus; }
            set { _stockStatus = value; }
        }


    }
}
