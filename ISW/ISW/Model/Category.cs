using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISW.Model
{
    class Category
    {
        private int _id;                            // Category ID
        private int? _parentID;                     // category id of parent category
        private string _name;                       // Name of Category
        private int? _displayOrder;                 // Display order prevalence
        private bool? _visibility;                  // Is the category visible
        private string _alternateURL;               // Alternate URL for Category
        private bool? _filterCategory;              // Is this a filter category
        private string _descriptionShort;           // Short description of the Category
        private string _description;                // Category Description 
        private string _descriptionBelowProducts;   // The secondary description located below the product 
        private string _customWhereClause;          // Custom SQL Filter 
        private bool? _hidden;                      // Is the category hidden 

        private string _metaTagKeywords;            // SEO Keywords (should be blank) 
        private string _metaTagTitle;               // SEO title
        private string _metaTagDescription;         // SEO Description

        private int? _display_Rows;                 // ?? Display rows 
        private string _defaultSortBy;              // ?? Default sort by 

        private bool? _displayListprice;            // Display “List Price” 
        private bool? _displayYousave;              // Display “You Save” 
        private bool? _displayDescriptionShort;     // Display “Description Short” 
        private bool? _displayAvailability;         // Display “Availability 
        private bool? _displayFeaturedProductsOnly; // Display the featured products only 
        private string _linkTitleTag;               // Category URL Text 
        private string _graphicPlacement;           // Graphic Placement 
        private string _subCategoryDisplayMode;     // SubCaqtegory Display Mode 
        private int? _subCategoryDisplayColumns;    // Number of subcategory display columns
    }
}
