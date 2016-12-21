namespace ISW.Model
{
    class Category
    {
        public Category(int id)
        {
            _id = id;
        }

        private int _id;                            
        // Category ID
        public int ID
        {
            get { return _id; }
        }
        private Category _parent;                     
        // category id of parent category
        public Category Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        private string _name;                       
        // Name of Category
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int? _displayOrder;                 
        // Display order prevalence
        public int? DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }
        private bool? _visibility;                  
        // Is the category visible
        public bool? Visibility
        {
            get { return _visibility; }
            set { _visibility = value; }
        }
        private string _alternateURL;               
        // Alternate URL for Category
        public string AlternateURL
        {
            get { return _alternateURL; }
            set { _alternateURL = value; }
        }
        private bool? _filterCategory;              
        // Is this a filter category
        public bool? FilterCategory
        {
            get { return _filterCategory; }
            set { _filterCategory = value; }
        }
        private string _descriptionShort;           
        // Short description of the Category
        public string DescriptionShort
        {
            get { return _descriptionShort; }
            set { _descriptionShort = value; }
        }
        private string _description;                
        // Category Description 
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _descriptionBelowProducts;   
        // The secondary description located below the product 
        public string DescriptionBelowProducts
        {
            get { return _descriptionBelowProducts; }
            set { _descriptionBelowProducts = value; }
        }
        private string _customWhereClause;          
        // Custom SQL Filter 
        public string CustomWhereClause
        {
            get { return _customWhereClause; }
            set { _customWhereClause = value; }
        }
        private bool? _hidden;                      
        // Is the category hidden 
        public bool? Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        private string _metaTagKeywords;            
        // SEO Keywords (should be blank) 
        public string MetaTagKeywords
        {
            get { return _metaTagKeywords; }
            set { _metaTagKeywords = value; }
        }
        private string _metaTagTitle;               
        // SEO title
        public string MetaTagTitle
        {
            get { return _metaTagTitle; }
            set { _metaTagTitle = value; }
        }
        private string _metaTagDescription;         
        // SEO Description
        public string MetaTagDescription
        {
            get { return _metaTagDescription; }
            set { _metaTagDescription = value; }
        }
        private int? _displayRows;                 
        // ?? Display rows 
        public int? DisplayRows
        {
            get { return _displayRows; }
            set { _displayRows = value; }
        }
        private string _defaultSortBy;              
        // ?? Default sort by 
        public string DefaultSortBy
        {
            get { return _defaultSortBy; }
            set { _defaultSortBy = value; }
        }
        private bool? _displayListPrice;            
        // Display “List Price” 
        public bool? DisplayListPrice
        {
            get { return _displayListPrice; }
            set { _displayListPrice = value; }
        }
        private bool? _displayYouSave;              
        // Display “You Save” 
        public bool? DisplayYouSave
        {
            get { return _displayYouSave; }
            set { _displayYouSave = value; }
        }
        private bool? _displayDescriptionShort;     
        // Display “Description Short” 
        public bool? DisplayDescriptionShort
        {
            get { return _displayDescriptionShort; }
            set { _displayDescriptionShort = value; }
        }
        private bool? _displayAvailability;         
        // Display “Availability 
        public bool? DisplayAvailablility
        {
            get { return _displayAvailability; }
            set { _displayAvailability = value; }
        }
        private bool? _displayFeaturedProductsOnly; 
        // Display the featured products only 
        public bool? DisplayFeaturedProductsOnly
        {
            get { return _displayFeaturedProductsOnly; }
            set { _displayFeaturedProductsOnly = value; }
        }
        private string _linkTitleTag;               
        // Category URL Text 
        public string LinkTitleTag
        {
            get { return _linkTitleTag; }
            set { _linkTitleTag = value; }
        }
        private string _graphicPlacement;           
        // Graphic Placement 
        public string GraphicPlacement
        {
            get { return _graphicPlacement; }
            set { _graphicPlacement = value; }
        }
        private string _subCategoryDisplayMode;     
        // SubCaqtegory Display Mode 
        public string SubCategoryDisplayMode
        {
            get { return _subCategoryDisplayMode; }
            set { _subCategoryDisplayMode = value; }
        }
        private int? _subCategoryDisplayColumns;    
        // Number of subcategory display columns
        public int? SubCategoryDisplayColums
        {
            get { return _subCategoryDisplayColumns; }
            set { _subCategoryDisplayColumns = value; }
        }
    }
}
