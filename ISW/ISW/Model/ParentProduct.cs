using System.Collections.Generic;

namespace ISW.Model
{
    class ParentProduct : Product
    {
        public ParentProduct(string ProductCode) : base(ProductCode)
        {
            // initialize list
            _childProducts = new List<ChildProduct>();
        }

        //List of Child Products assigned to the shoe [List] ischildofproductcode
        private List<ChildProduct> _childProducts;
        public List<ChildProduct> ChildProducts
        {
            get { return _childProducts; }
            set { _childProducts = value; }
        }

        // Determine if seen on home page [int? or bool] homepage_section
        //   ** Note: Unsure if this should be an int or bool. 
        //   ** This will be determined during testing of data from the downloaded database.
        private bool? _onHomePage;
        public bool? OnHomePage
        {
            get { return _onHomePage; }
            set { _onHomePage = value; }
        }

        // HTML of product description [string] productdescription
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Keyword for SEO (no longer to be used, blank it out) [string] metatag_keywords
        private string _metaTagKeywords;
        public string MetaTagKeywords
        {
            get { return _metaTagKeywords; }
            set { _metaTagKeywords = value; }
        }
    }
}
