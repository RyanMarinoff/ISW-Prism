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

using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

using ISW.Model;

namespace ISW.IoC
{
    static class IDataLoader
    {
        // **************
        // * Data Store *
        // **************
        private static class IData
        {
            internal static List<Category> Categories { get; set; }
            internal static List<OptionCategory> OptionCategories { get; set; }
            internal static List<Option> Options { get; set; }
            internal static List<Vendor> Vendors { get; set; }
            internal static List<ParentProduct> Products { get; set; }
        }

        // *************
        // * Accessors *
        // *************

        // allow access to ParentProduct list
        public static List<ParentProduct> Products
        {
            get { return IData.Products; }
        }

        // Count Properties
        public static int CategoriesCount
        {
            get
            {
                if (IData.Categories != null)
                    return IData.Categories.Count;
                else
                    return -1;
            }
        }
        public static int OptionCategoriesCount
        {
            get
            {
                if (IData.OptionCategories != null)
                    return IData.OptionCategories.Count;
                else
                    return -1;
            }
        }
        public static int OptionsCount
        {
            get
            {
                if (IData.Options != null)
                    return IData.Options.Count;
                else
                    return -1;
            }
        }
        public static int VendorsCount
        {
            get
            {
                if (IData.Vendors != null)
                    return IData.Vendors.Count;
                else
                    return -1;
            }
        }
        public static int ProductsCount
        {
            get
            {
                if (IData.Products != null)
                    return IData.Products.Count;
                else
                    return -1;
            }
        }

        // *************
        // * Functions *
        // *************

            // Load Data
        public static void LoadOptionCategories(string categoryFile)
        {
            // Initialize OptionCategories
            if (IData.OptionCategories == null)
                IData.OptionCategories = new List<OptionCategory>();

            // The raw data from the CSV file
            List<Dictionary<string, string>> theList = ProcessData(categoryFile);

            OptionCategory optionCategoryItem;

            // Process the list
            foreach (var item in theList)
            {
                int id = -1; // error check, all id's must be positive
                string value;

                // Option Category ID [int] id
                if(item.TryGetValue("id", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))
                        id = n;
                }
                if (id != -1)
                {
                    optionCategoryItem = new OptionCategory(id);

                    // Option Category Description [string] optioncategoriesdesc
                    if(item.TryGetValue("optioncategoriesdesc", out value))
                    {
                        optionCategoryItem.Description = value;
                    }

                    // each item must be unique
                    var index = IData.OptionCategories.FindIndex(x => x.ID == optionCategoryItem.ID);
                    if (index == -1)
                        IData.OptionCategories.Add(optionCategoryItem);
                    else
                        IData.OptionCategories[index] = optionCategoryItem;
                }
            }
        }
        public static void LoadOptions(string optionFile)
        {
            // Check for required data
            if (IData.OptionCategories == null)
                throw new Exception("OptionCatagories not ready for Options");

            // Initialize Options
            if (IData.Options == null)
                IData.Options = new List<Option>();

            // The raw data from the CSV file
            List<Dictionary<string, string>> theList = ProcessData(optionFile);

            Option optionItem;

            // Process the list
            foreach(var item in theList)
            {
                int id = -1; // error check, all id's must be positive
                string value;

                // Option ID [int] id
                if (item.TryGetValue("id", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))
                        id = n;
                }
                if(id != -1)
                {
                    optionItem = new Option(id);

                    // Option Description [string] optionsdesc
                    if (item.TryGetValue("optionsdesc", out value))
                    {
                        optionItem.Description = value;
                    }

                    // Display Order [int] arrangeoptionsby
                    if (item.TryGetValue("arrangeoptionsby", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            optionItem.ArrangeOptionsBy = n;
                    }

                    // Option Category ID [OptionCategory] optioncatid
                    if (item.TryGetValue("optioncatid", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            optionItem.Category = IData.OptionCategories.Find(x => x.ID == n);
                    }

                    // each item must be unique
                    var optionIndex = IData.Options.FindIndex(x => x.ID == optionItem.ID);
                    if (optionIndex == -1)
                        IData.Options.Add(optionItem);
                    else
                        IData.Options[optionIndex] = optionItem;
                }
            }
        }
        public static void LoadCategories(string categoryFile)
        {
            // Initialize Categories
            if (IData.Categories == null)
                IData.Categories = new List<Category>();

            // The raw data from the CSV file
            List<Dictionary<string, string>> theList = ProcessData(categoryFile);

            Category categoryItem;

            // Some categories have parent categories, this will keep track of them.
            //   Key: Category with a parent
            //   Value: ID of the parent category
            Dictionary<Category, int> CategoryWithParent = new Dictionary<Category, int>();

            // process the list
            foreach (var item in theList)
            {
                int id = -1;//error check, all id's must be positive
                string value;

                // Category ID [int] categoryid
                if (item.TryGetValue("categoryid", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))
                        id = n;
                }
                if (id != -1)
                {
                    categoryItem = new Category(id);

                    // Name of the Category [string] categoryname
                    if (item.TryGetValue("categoryname", out value))
                    {
                        categoryItem.Name = value;
                    }

                    // Display Order Prevalence [string] categoryorder
                    if (item.TryGetValue("categoryorder", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            categoryItem.DisplayOrder = n;
                    }

                    // Alternate URL for Category [string] alternateurl
                    if (item.TryGetValue("alternateurl", out value))
                    {
                        categoryItem.AlternateURL = value;
                    }

                    // SEO title [string] metatag_title
                    if (item.TryGetValue("metatag_title", out value))
                    {
                        categoryItem.MetaTagTitle = value;
                    }

                    // SEO Description [string] metatag_description
                    if (item.TryGetValue("metatag_description", out value))
                    {
                        categoryItem.MetaTagDescription = value;
                    }

                    // Is this a filter category [bool] filtercategory
                    if (item.TryGetValue("filtercategory", out value))
                    {
                        if (value != "")
                            categoryItem.FilterCategory = value.Equals("Y");
                    }

                    // Short description of the Category [string] categorydescriptionshort
                    if (item.TryGetValue("categorydescriptionshort", out value))
                    {
                        categoryItem.DescriptionShort = value;
                    }

                    // Category Description [string] categorydescription
                    if (item.TryGetValue("categorydescription", out value))
                    {
                        categoryItem.Description = value;
                    }

                    // SEO Keywords [string] metatag_keywords
                    //   ** should be blank
                    if (item.TryGetValue("metatag_keywords", out value))
                    {
                        categoryItem.MetaTagKeywords = value;
                    }

                    // The secondary description located below the product [string] categorydescription_belowproducts
                    if (item.TryGetValue("categorydescription_belowproducts", out value))
                    {
                        categoryItem.DescriptionBelowProducts = value;
                    }

                    // Custom SQL Filter [string] custom_where_clause
                    if (item.TryGetValue("custom_where_clause", out value))
                    {
                        categoryItem.CustomWhereClause = value;
                    }

                    // Is the category hidden [bool] hidden
                    if (item.TryGetValue("hidden", out value))
                    {
                        if (value != "")
                            categoryItem.Hidden = value.Equals("Y");
                    }

                    /***********************/
                    /* May or may not stay */
                    /***********************/

                    // ?? How many rows to be displayed [int] display_rows
                    if (item.TryGetValue("display_rows", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            categoryItem.DisplayRows = n;
                    }

                    // Display "List Price" [bool] display_showlistprice
                    if (item.TryGetValue("display_showlistprice", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayListPrice = value.Equals("Y");
                    }

                    // Display "You Save" [bool] display_showyousave
                    if (item.TryGetValue("display_showyousave", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayYouSave = value.Equals("Y");
                    }

                    // Display "Description Short" [bool] DisplayDescriptionShort
                    if (item.TryGetValue("display_showdescriptionshort", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayDescriptionShort = value.Equals("Y");
                    }

                    // Display "Availability" [bool] DisplayAvailablility
                    if (item.TryGetValue("display_showavailability", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayAvailablility = value.Equals("Y");
                    }

                    // Display the featured products only [bool] DisplayFeaturedProductsOnly
                    if (item.TryGetValue("display_featuredproductsonly", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayFeaturedProductsOnly = value.Equals("Y");
                    }

                    // ?? Default sort by [string] DefaultSortBy
                    if (item.TryGetValue("default_sortby", out value))
                    {
                        categoryItem.DefaultSortBy = value;
                    }

                    // Category URL Text [string] LinkTitleTag
                    if (item.TryGetValue("link_title_tag", out value))
                    {
                        categoryItem.LinkTitleTag = value;
                    }

                    // Graphic Placement [string] GraphicPlacement
                    if (item.TryGetValue("category_graphic_placement", out value))
                    {
                        categoryItem.GraphicPlacement = value;
                    }

                    // Number of subcategory display columns [string] SubCategoryDisplayColums
                    if (item.TryGetValue("subcategory_displaycolumns_responsive", out value))
                    {
                        if(value != "")
                        {
                            int n;
                            if (int.TryParse(value, out n))
                                categoryItem.SubCategoryDisplayColums = n;
                        }
                    }

                    // SubCategory Display Mode [int] SubCategoryDisplayMode
                    if (item.TryGetValue("subcategory_displaymode1", out value))
                    {
                        categoryItem.SubCategoryDisplayMode = value;
                    }

                    // Category ID of Parent Category [int] parentid
                    //   ** to be processed out of loop
                    if (item.TryGetValue("parentid", out value))
                    {
                        if (value != "")
                        {
                            int n;
                            if (int.TryParse(value, out n) && n != 0)
                                CategoryWithParent.Add(categoryItem, n);
                        }
                    }

                    // each item must be unique
                    var categoryIndex = IData.Categories.FindIndex(x => x.ID == categoryItem.ID);
                    if (categoryIndex == -1)
                        IData.Categories.Add(categoryItem);
                    else
                        IData.Categories[categoryIndex] = categoryItem;
                }
            }

            // Process the Parent Categories [Category] Item within CategoryWithParent
            foreach(var item in CategoryWithParent)
            {
                var index = IData.Categories.FindIndex(x => x.ID == item.Value);
                if (index != -1)
                    item.Key.Parent = IData.Categories[index];
                else
                    throw new InvalidDataException("Category ID " + item.Value + " not found.");
            }
        }
        public static void LoadVendors(string vendorFile)
        {
            // Initialize Vendors
            if (IData.Vendors == null)
                IData.Vendors = new List<Vendor>();

            // The raw data from the CSV file
            List<Dictionary<string, string>> theList = ProcessData(vendorFile);
            Vendor vendorItem;

            // process the list
            foreach(var item in theList)
            {
                int id = -1; // error check, all id's must be positive
                string value;

                // Vendor ID [int] ID
                if (item.TryGetValue("vendor_id", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))
                        id = n;
                }
                if(id!= -1)
                {
                    vendorItem = new Vendor(id);

                    // Name of Vendor [string] Title
                    if (item.TryGetValue("vendor_title", out value))
                    {
                        vendorItem.Title = value;
                    }

                    // PO Template [string] PoTemplate
                    if (item.TryGetValue("vendor_po_template", out value))
                    {
                        vendorItem.PoTemplate = value;
                    }

                    // each item must be unique
                    var vendorIndex = IData.Vendors.FindIndex(x => x.ID == vendorItem.ID);
                    if (vendorIndex == -1)
                        IData.Vendors.Add(vendorItem);
                    else
                        IData.Vendors[vendorIndex] = vendorItem;
                }
            }
        }
        public static void LoadProducts(string productFile)
        {
            // Check for required loaded data
            if (IData.Categories == null)
                throw new Exception("Categories Not Ready for Products");
            if (IData.Options == null)
                throw new Exception("Options Not Ready for Products");
            if (IData.Vendors == null)
                throw new Exception("Vendors Not Ready for Products");

            // Initialize Products
            if (IData.Products == null)
                IData.Products = new List<ParentProduct>();

            // The raw data from the CSV file
            List<Dictionary<string, string>> theList = ProcessData(productFile);
            ParentProduct productItem;

            // process the list
            foreach(var item in theList)
            {
                string id = "";
                string value;

                // Product Code [string] productcode
                if(item.TryGetValue("productcode", out value))
                {
                    id = value;
                }
                if(id != "")
                {
                    productItem = new ParentProduct(value);

                    // List of Category IDs assigned to the shoe [List<Category>] categoryids
                    if(item.TryGetValue("categoryids", out value))
                    {
                        var catids = value.Split(',');
                        List<Category> itemCategories = new List<Category>();
                        foreach(var catid in catids)
                        {
                            int cid;
                            if(int.TryParse(catid, out cid))
                            {
                                var cat = IData.Categories.Find(x => x.ID == cid);
                                if(cat != null)
                                    itemCategories.Add(cat);
                            }
                        }
                        productItem.Categories = itemCategories;
                    }
                    
                    // List of Option IDs assigned to the shoe [List<Option>] optionids
                    if(item.TryGetValue("optionids", out value))
                    {
                        var optids = value.Split(',');
                        List<Option> itemOptions = new List<Option>();
                        foreach(var optid in optids)
                        {
                            int oid;
                            if(int.TryParse(optid, out oid))
                            {
                                var opt = IData.Options.Find(x => x.ID == oid);
                                if (opt != null)
                                    itemOptions.Add(opt);
                            }
                        }
                        productItem.Options = itemOptions;
                    }

                    // Product Name [string] productname
                    if(item.TryGetValue("productname", out value))
                    {
                        productItem.Name = value;
                    }

                    // Date product first displayed [DateTime] displaybegindate
                    if(item.TryGetValue("displaybegindate", out value))
                    {
                        DateTime beginDate;
                        if(DateTime.TryParse(value, out beginDate))
                            productItem.DisplayBeginDate = beginDate;
                    }

                    // Is the product taxable [bool] taxableproduct
                    if (item.TryGetValue("taxableproduct", out value))
                    {
                        if (value != "")
                            productItem.Taxable = value.Equals("Y");
                    }

                    // Is the product hidden [bool] hideproduct
                    if(item.TryGetValue("hideproduct", out value))
                    {
                        if (value != "")
                            productItem.Hidden = value.Equals("Y");
                    }

                    // Shortened version of the product name [string] productnameshort
                    if(item.TryGetValue("productnameshort", out value))
                    {
                        productItem.ShortName = value;
                    }

                    // Short statement of product (mens / womens / accessories) [string] productdescriptionshort
                    if(item.TryGetValue("productdescriptionshort", out value))
                    {
                        productItem.ShortDescription = value;
                    }

                    // SEO Title [string] metatag_title
                    if(item.TryGetValue("metatag_title", out value))
                    {
                        productItem.MetaTagTitle = value;
                    }

                    // SEO Description [string] metatag_description
                    if(item.TryGetValue("metatag_description", out value))
                    {
                        productItem.MetaTagDescription = value;
                    }

                    // SEO Photo alternative text [string] photo_alttext
                    if(item.TryGetValue("photo_alttext", out value))
                    {
                        productItem.PhotoAltText = value;
                    }

                    // Is the product designated as a sale product [string] customfield1
                    if(item.TryGetValue("customfield1", out value))
                    {
                        productItem.SaleText = value;
                    }

                    // Manufacturer of the product [Vendor] productmanufacturer
                    if(item.TryGetValue("productmanufacturer", out value))
                    {
                        productItem.ItemVendor = value;
                        //productItem.ItemVendor = IData.Vendors.Find(x => x.Title == value);
                    }

                    // Price of product [float] ProductPrice productprice
                    if(item.TryGetValue("productprice", out value))
                    {
                        float price;
                        if(float.TryParse(value, out price))
                        {
                            productItem.ProductPrice = price;
                        }
                    }

                    // Determine if this item is a parent or a child product

                    // List of Child Products assigned to the shoe [List] ChildProducts ischildofproductcode
                    //   ---   Number of shoes in stock [int] stockstatus
                    if (item.TryGetValue("ischildofproductcode", out value)) 
                    {
                        if (value != "") // if there is a value within here
                        {
                            // copy the current item as a child item
                            ChildProduct childItem = new ChildProduct(productItem);

                            // Number of shoes in stock [int] stockstatus
                            string stockstatus;
                            if (item.TryGetValue("stockstatus", out stockstatus))
                            {
                                int status;
                                if(int.TryParse(stockstatus, out status))
                                {
                                    childItem.StockStatus = status;
                                }
                            }
                            var parentIndex = IData.Products.FindIndex(x => x.ID == value);
                            if(parentIndex != -1)
                            {
                                IData.Products[parentIndex].ChildProducts.Add(childItem);
                                continue;
                            }
                        }
                    }

                    // HTML of product description [string] productdescription
                    if (item.TryGetValue("productdescription", out value))
                    {
                        productItem.Description = value;
                    }
                    // Determine if seen on home page [bool?] homepage_section
                    if(item.TryGetValue("homepage_section", out value))
                    {
                        if (value != "")
                            productItem.OnHomePage = value.Equals("Y");
                    }
                    // Keywords for SEO [string] metatag_keywords
                    if(item.TryGetValue("metatag_keywords", out value))
                    {
                        productItem.MetaTagKeywords = value;
                    }

                    // each item must be unique
                    var productIndex = IData.Products.FindIndex(x => x.ID == productItem.ID);
                    if (productIndex == -1)
                        IData.Products.Add(productItem);
                    else
                        IData.Products[productIndex] = productItem;
                }
            }
        }

        // **********
        // * Helper *
        // **********

            // Process Files
        private static List<Dictionary<string,string>> ProcessData(string fileLocation)
        {
            Dictionary<string, string> item;
            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();

            if(fileLocation == "")
                return items;

            var streamReader = new StreamReader(fileLocation);
            var header = streamReader.ReadLine();
            var headings = header.Split('|');

            while (!streamReader.EndOfStream)
            {
                item = new Dictionary<string, string>();
                var line = streamReader.ReadLine();
                var values = line.Split('|');

                if (values.Length != headings.Length)
                {
                    // Within the volusion files, the HTML of the description is seperated into different lines.
                    // We do this so to consolidate the string into a single array index. strings are surrounded by "
                    bool consolidateString;
                    do
                    {
                        consolidateString = true;
                        var newArray = new List<string>(values);

                        for (int i = 0; i < newArray.Count; i++)
                        {
                            if (newArray[i] != "" && (newArray[i][0] == '\"' && newArray[i][newArray[i].Count() - 1] != '\"') && i != newArray.Count - 1)
                            {
                                newArray[i] = newArray[i] + ',' + newArray[i + 1];
                                newArray.RemoveAt(i + 1);
                                //i--;
                            }
                        }

                        values = newArray.ToArray();
                        // the values / headings length may not be the same due to the above manipulation of the data
                        // when there are more headings than values, need to combine the values of the next line to the
                        // values of this line
                        if (headings.Length > values.Length)
                        {
                            var nextLine = streamReader.ReadLine();
                            var leftOverValues = nextLine.Split('|');

                            values[values.Length - 1] += '\n' + leftOverValues[0];
                            values = values.Concat(leftOverValues.Skip(1)).ToArray();
                            consolidateString = false;
                        }
                        if (headings.Length != values.Length)
                        {
                            consolidateString = false;
                        }
                    } while (!consolidateString);
                }


                // if the headings and values have equal members, all is good to process them into the dictionary
                for(int i = 0; i < values.Length; i++)
                {
                    if (values[i].StartsWith("\"") && values[i].EndsWith("\""))
                        values[i] = values[i].Trim('\"');
                    item.Add(headings[i], values[i]);
                }

                items.Add(item);
            }
            streamReader.Close();

            return items;
        }
    }
}
