using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISW.Model
{
    class ParentProduct : Product
    {
        private List<ChildProduct> _childProducts; //List of Child Products assigned to the shoe
        private bool _homePageSection; //Determine if seen on home page [int ? or bool]
        private string _productDescription; //HTML of product description
        private string _metaTagKeywords; //Keyword for SEO(no longer to be used, blank it out) 

        public ParentProduct(string ProductCode) : base(ProductCode)
        {
        }
    }
}
