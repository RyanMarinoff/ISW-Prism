/**************************************************************************
 *                                                                        *
 *  ISW - Internet Sales Work    Internet task assistance application.    *
 *  Copyright (C) 2016  Ryan Marinoff                                     *
 *                                                                        *
 *  This program is free software: you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation, either version 3 of the License, or     *
 *  (at your option) any later version.                                   *
 *                                                                        *
 *  This program is distributed in the hope that it will be useful,       *
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *  GNU General Public License for more details.                          *
 *                                                                        *
 *  You should have received a copy of the GNU General Public License     *
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *                                                                        *
 **************************************************************************/
using System;

namespace ISW.Model
{
    public class Category : IEquatable<Category>
    {
        public Category(int id)
        {
            _id = id;
        }

        // Category ID [int] categoryid
        private int _id;
        public int ID
        {
            get { return _id; }
        }

        // Category ID of Parent Category [int] parentid
        private Category _parent;
        public Category Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        // Name of the Category [string] categoryname
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Display Order Prevalence [string] categoryorder
        private int? _displayOrder;
        public int? DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        // Alternate URL for Category [string] alternateurl
        private string _alternateURL;
        public string AlternateURL
        {
            get { return _alternateURL; }
            set { _alternateURL = value; }
        }

        // Is this a filter category [bool] filtercategory
        private bool? _filterCategory;
        public bool? FilterCategory
        {
            get { return _filterCategory; }
            set { _filterCategory = value; }
        }

        // Short description of the Category [string] categorydescriptionshort
        private string _descriptionShort;
        public string DescriptionShort
        {
            get { return _descriptionShort; }
            set { _descriptionShort = value; }
        }

        // Category Description [string] categorydescription
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // The secondary description located below the product [string] categorydescription_belowproducts
        private string _descriptionBelowProducts;
        public string DescriptionBelowProducts
        {
            get { return _descriptionBelowProducts; }
            set { _descriptionBelowProducts = value; }
        }

        // Custom SQL Filter [string] custom_where_clause
        private string _customWhereClause;
        public string CustomWhereClause
        {
            get { return _customWhereClause; }
            set { _customWhereClause = value; }
        }

        // Is the category hidden [bool] hidden
        private bool? _hidden;
        public bool? Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }

        // SEO Keywords [string] metatag_keywords
        private string _metaTagKeywords;
        public string MetaTagKeywords
        {
            get { return _metaTagKeywords; }
            set { _metaTagKeywords = value; }
        }

        // SEO title [string] metatag_title
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

        // ?? How many rows to be displayed [int] display_rows
        private int? _displayRows;
        public int? DisplayRows
        {
            get { return _displayRows; }
            set { _displayRows = value; }
        }

        // ?? Default sort by [string] DefaultSortBy
        private string _defaultSortBy;
        public string DefaultSortBy
        {
            get { return _defaultSortBy; }
            set { _defaultSortBy = value; }
        }

        // Display "List Price" [bool] display_showlistprice
        private bool? _displayListPrice;
        public bool? DisplayListPrice
        {
            get { return _displayListPrice; }
            set { _displayListPrice = value; }
        }

        // Display "You Save" [bool] display_showyousave
        private bool? _displayYouSave;
        public bool? DisplayYouSave
        {
            get { return _displayYouSave; }
            set { _displayYouSave = value; }
        }

        // Display "Description Short" [bool] DisplayDescriptionShort
        private bool? _displayDescriptionShort;
        public bool? DisplayDescriptionShort
        {
            get { return _displayDescriptionShort; }
            set { _displayDescriptionShort = value; }
        }

        // Display "Availability" [bool] DisplayAvailablility
        private bool? _displayAvailability;
        public bool? DisplayAvailablility
        {
            get { return _displayAvailability; }
            set { _displayAvailability = value; }
        }

        // Display the featured products only [bool] DisplayFeaturedProductsOnly
        private bool? _displayFeaturedProductsOnly;
        public bool? DisplayFeaturedProductsOnly
        {
            get { return _displayFeaturedProductsOnly; }
            set { _displayFeaturedProductsOnly = value; }
        }

        // Category URL Text [string] LinkTitleTag
        private string _linkTitleTag;
        public string LinkTitleTag
        {
            get { return _linkTitleTag; }
            set { _linkTitleTag = value; }
        }

        // Graphic Placement [string] GraphicPlacement
        private string _graphicPlacement;
        public string GraphicPlacement
        {
            get { return _graphicPlacement; }
            set { _graphicPlacement = value; }
        }

        // SubCategory Display Mode [int] SubCategoryDisplayMode
        private string _subCategoryDisplayMode;
        public string SubCategoryDisplayMode
        {
            get { return _subCategoryDisplayMode; }
            set { _subCategoryDisplayMode = value; }
        }

        // Number of subcategory display columns [string] SubCategoryDisplayColums
        private int? _subCategoryDisplayColumns;
        public int? SubCategoryDisplayColums
        {
            get { return _subCategoryDisplayColumns; }
            set { _subCategoryDisplayColumns = value; }
        }

        // Overloads
        public override string ToString()
        {
            return "ID: " + _id + " - " + GetNameString();
        }

        private string GetNameString()
        {
            if(_parent == null)
                return _name;

            return _parent.GetNameString() + ">" + _name;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals(obj as Category);
        }

        public bool Equals(Category other)
        {
            if (other == default(Category))
                return false;
            return _id.Equals(other.ID);
        }

        public bool Equals(int otherID)
        {
            return _id.Equals(otherID);
        }

        public static bool operator ==(Category a, Category b)
        {
            if (ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }

        public static bool operator !=(Category a, Category b)
        {
            return !(a == b);
        }

        public static bool operator ==(Category a, int b)
        {
            return a.ID == b;
        }

        public static bool operator !=(Category a, int b)
        {
            return !(a == b);
        }

        // ********************
        // * Member Functions *
        // ********************

        // Update Function
        public bool UpdateData(Category update)
        {
            throw new NotImplementedException();
        }
    }
}
