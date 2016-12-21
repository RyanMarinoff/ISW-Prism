namespace ISW.Model
{
    class ChildProduct : Product
    {
        private int _stockStatus; //Number of shoes in stock

        public ChildProduct(string ProductCode) : base(ProductCode)
        {
        }
    }
}
