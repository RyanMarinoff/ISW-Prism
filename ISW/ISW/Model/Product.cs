using System;
using System.Collections.Generic;

namespace ISW.Model
{
    class Product
    {

        public Product(string productCode)
        {
            _id = productCode;

            // initialize the lists
            _categories = new List<Category>();
            _options = new List<Option>();
        }


        // Product Code [string] productcode
        private string _id;
        public string ID
        {
            get { return _id; }
        }

        // List of Category IDs assigned to the shoe [List<Category>] categoryids
        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        // List of Option IDs assigned to the shoe [List<Option>] optionids
        private List<Option> _options;
        public List<Option> Options
        {
            get { return _options; }
            set { _options = value; }
        }

        // Product Name [string] productname
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Shortened version of the product name [string] productnameshort
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        // Short statement of product(mens/womens/accessories) [string] productdescriptionshort
        private string _shortDescription;
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { _shortDescription = value; }
        }

        // Date product first displayed [DateTime] displaybegindate
        private DateTime? _displayBeginDate;
        public DateTime? DisplayBeginDate
        {
            get { return _displayBeginDate; }
            set { _displayBeginDate = value; }
        }

        // Is the product taxable [bool] taxableproduct
        private bool? _taxable;
        public bool? Taxable
        {
            get { return _taxable; }
            set { _taxable = value; }
        }

        // Is the product hidden [bool] hideproduct
        private bool? _hidden;
        public bool? Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }

        // SEO Title [string] metatag_title
        private string _metaTagTitle;
        public string MetaTagTitle
        {
            get { return _metaTagTitle; }
            set { _metaTagTitle = value; }
        }

        // SEO Description [string] metatag_description
        private string _metaTagDescription;
        public string MetaTagDescription
        {
            get { return _metaTagDescription; }
            set { _metaTagDescription = value; }
        }

        // SEO Photo alternative text [string] photo_alttext
        private string _photoAltText;
        public string PhotoAltText
        {
            get { return _photoAltText; }
            set { _photoAltText = value; }
        }

        // Is the product designated as a sale product [string] customfield1
        private string _saleText;
        public string SaleText
        {
            get { return _saleText; }
            set { _saleText = value; }
        }

        // Manufacturer of the product [Vendor] productmanufacturer
        private Vendor _itemVendor;
        public Vendor ItemVendor
        {
            get { return _itemVendor; }
            set { _itemVendor = value; }
        }


        // Price of product [float] productprice
        //   ** Issues with Internet database requires this field
        private float? _productPrice;
        public float? ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }
    }
}
