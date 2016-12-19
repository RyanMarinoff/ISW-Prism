using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISW.Model
{
    class Product
    {
        private string _productCode;                //Product Code
        private List<Category> _categoryIDs;        //List of Category IDs assigned to the shoe 
        private List<Option> _optionIDs;            //List of Option IDs assigned to the shoe

        public Product(string ProductCode)
        {
            _categoryIDs = new List<Category>();
            _optionIDs = new List<Option>();

            _productCode = ProductCode;
        }

        private string _productName;                //Product Name
        private DateTime? _displayBeginDate;        //Date product first displayed
        private bool? _taxableProduct;              //Is the product taxable
        private bool? _hideProduct;                 //Is the product hidden
        private string _productNameShort;           //Shortened version of the product name
        private string _productDescriptionShort;    //Short statement of product(mens/womens/accessories) 
        private string _metaTag_Title;              //SEO Title
        private string _metaTag_Description;        //SEO Description
        private string _photo_AltText;              //SEO Photo alternative text
        private string _saleText;                   //Is the product designated as a sale product(shouldn’t be used) 
        private Vendor _itemVendor;                 //Manufacturer of the product

        private float? _productPrice;               //Price of product - Apply to both due to errors in database on the internet
    }
}
