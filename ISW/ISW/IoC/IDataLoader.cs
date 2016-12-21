using System.Collections.Generic;
using System.Linq;
using System.IO;

using ISW.Model;

namespace ISW.IoC
{
    static class IDataLoader
    {
        public static void LoadOptions(string optionFile, ref List<Option> options)
        {
            List<Dictionary<string, string>> theList = ProcessCSV(optionFile);

            Option optionItem;
            foreach(var item in theList)
            {
                int id = -1; // error check, all id's must be positive
                string value;
                if(item.TryGetValue("id", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))

                        id = n;
                }
                if(id != -1)
                {
                    optionItem = new Option(id);
                    if(item.TryGetValue("optioncatid", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            optionItem.CatID = n;
                    }
                    if(item.TryGetValue("optionsdesc", out value))
                    {
                        optionItem.Description = value;
                    }
                    if(item.TryGetValue("arrangeoptionsby", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            optionItem.ArrangeOptionsBy = n;
                    }
                    var optionIndex = options.FindIndex(x => x.ID == optionItem.ID);
                    if (optionIndex == -1)
                        options.Add(optionItem);
                    else
                        options[optionIndex] = optionItem;
                }
            }
        }

        public static void LoadCategories(string categoryFile, ref List<Category> categories)
        {
            List<Dictionary<string, string>> theList = ProcessCSV(categoryFile);
            Dictionary<Category, int> CategoryWithParent = new Dictionary<Category, int>();
            Category categoryItem;
            foreach (var item in theList)
            {
                int id = -1;//error check, all id's must be positive
                string value;
                if (item.TryGetValue("categoryid", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))
                        id = n;
                }
                if (id != -1)
                {
                    categoryItem = new Category(id);
                    if (item.TryGetValue("categoryname", out value))
                    {
                        categoryItem.Name = value;
                    }
                    if (item.TryGetValue("parentid", out value))
                    {
                        if (value != "")
                        {
                            int n;
                            if (int.TryParse(value, out n))
                                CategoryWithParent.Add(categoryItem, n);
                        }
                    }
                    if (item.TryGetValue("categoryorder", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            categoryItem.DisplayOrder = n;
                    }
                    if (item.TryGetValue("categoryvisibile", out value))
                    {
                        if (value != "")
                            categoryItem.Visibility = value.Equals("Y");
                    }
                    if (item.TryGetValue("alternateurl", out value))
                    {
                        categoryItem.AlternateURL = value;
                    }
                    if (item.TryGetValue("subcategory_displaymode1", out value))
                    {
                        categoryItem.SubCategoryDisplayMode = value;
                    }
                    if (item.TryGetValue("display_rows", out value))
                    {
                        int n;
                        if (int.TryParse(value, out n))
                            categoryItem.DisplayRows = n;
                    }
                    if (item.TryGetValue("display_showlistprice", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayListPrice = value.Equals("Y");
                    }
                    if (item.TryGetValue("display_showyousave", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayYouSave = value.Equals("Y");
                    }
                    if (item.TryGetValue("display_showdescriptionshort", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayDescriptionShort = value.Equals("Y");
                    }
                    if (item.TryGetValue("display_showavailability", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayAvailablility = value.Equals("Y");
                    }
                    if (item.TryGetValue("display_featuredproductsonly", out value))
                    {
                        if (value != "")
                            categoryItem.DisplayFeaturedProductsOnly = value.Equals("Y");
                    }
                    if (item.TryGetValue("metatag_title", out value))
                    {
                        categoryItem.MetaTagTitle = value;
                    }
                    if (item.TryGetValue("metatag_description", out value))
                    {
                        categoryItem.MetaTagDescription = value;
                    }
                    if (item.TryGetValue("default_sortby", out value))
                    {
                        categoryItem.DefaultSortBy = value;
                    }
                    if (item.TryGetValue("link_title_tag", out value))
                    {
                        categoryItem.LinkTitleTag = value;
                    }
                    if (item.TryGetValue("category_graphic_placement", out value))
                    {
                        categoryItem.GraphicPlacement = value;
                    }
                    if (item.TryGetValue("filtercategory", out value))
                    {
                        if (value != "")
                            categoryItem.FilterCategory = value.Equals("Y");
                    }
                    if (item.TryGetValue("categorydescriptionshort", out value))
                    {
                        categoryItem.DescriptionShort = value;
                    }
                    if (item.TryGetValue("categorydescription", out value))
                    {
                        categoryItem.Description = value;
                    }
                    if (item.TryGetValue("metatag_keywords", out value))
                    {
                        categoryItem.MetaTagKeywords = value;
                    }
                    if (item.TryGetValue("categorydescription_belowproducts", out value))
                    {
                        categoryItem.DescriptionBelowProducts = value;
                    }
                    if (item.TryGetValue("custom_where_clause", out value))
                    {
                        categoryItem.CustomWhereClause = value;
                    }
                    if (item.TryGetValue("hidden", out value))
                    {
                        if (value != "")
                            categoryItem.Hidden = value.Equals("Y");
                    }
                    if(item.TryGetValue("subcategory_displaycolumns_responsive", out value))
                    {
                        if(value != "")
                        {
                            int n;
                            if (int.TryParse(value, out n))
                                categoryItem.SubCategoryDisplayColums = n;
                        }
                    }

                    var categoryIndex = categories.FindIndex(x => x.ID == categoryItem.ID);
                    if (categoryIndex == -1)
                        categories.Add(categoryItem);
                    else
                        categories[categoryIndex] = categoryItem;
                }
            }
            foreach(var item in CategoryWithParent)
            {
                var index = categories.FindIndex(x => x.ID == item.Value);
                if(index != -1)
                    item.Key.Parent = categories[index];
            }
        }
        
        public static void LoadVendors(string vendorFile, ref List<Vendor> vendors)
        {
            List<Dictionary<string, string>> theList = ProcessCSV(vendorFile);

            Vendor vendorItem;
            foreach(var item in theList)
            {
                int id = -1; // error check, all id's must be positive
                string value;
                if(item.TryGetValue("vendor_id", out value))
                {
                    int n;
                    if (int.TryParse(value, out n))
                        id = n;
                }
                if(id!= -1)
                {
                    vendorItem = new Vendor(id);
                    if(item.TryGetValue("vendor_title", out value))
                    {
                        vendorItem.Title = value;
                    }
                    if(item.TryGetValue("vendor_po_template", out value))
                    {
                        vendorItem.PoTemplate = value;
                    }

                    var vendorIndex = vendors.FindIndex(x => x.ID == vendorItem.ID);
                    if (vendorIndex == -1)
                        vendors.Add(vendorItem);
                    else
                        vendors[vendorIndex] = vendorItem;
                }
            }
        }

        private static List<Dictionary<string,string>> ProcessCSV(string fileLocation)
        {
            Dictionary<string, string> item;
            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();

            if(fileLocation == "")
                return items;

            var streamReader = new StreamReader(fileLocation);
            var header = streamReader.ReadLine();
            var headings = header.Split(',');

            while (!streamReader.EndOfStream)
            {
                item = new Dictionary<string, string>();
                var line = streamReader.ReadLine();
                var values = line.Split(',');

                // Within the volusion files, the HTML of the description is seperated into different lines.
                // We do this so to consolidate the string into a single array index. strings are surrounded by "
                bool consolidateString;
                do
                {
                    consolidateString = true;
                    var newArray = new List<string>(values);

                    int length = values.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (newArray[i] != "" && (newArray[i][0] == '\"' && newArray[i][newArray[i].Count() - 1] != '\"') && i != length - 1)
                        {
                            newArray[i] = newArray[i] + ',' + newArray[i + 1];
                            newArray.RemoveAt(i + 1);
                            length--;
                            if (i != length)
                                consolidateString = false;
                        }
                    }

                    values = null;
                    values = newArray.ToArray();
                } while (!consolidateString);

                // the values / headings length may not be the same due to the above manipulation of the data
                // when there are more headings than values, need to combine the values of the next line to the
                // values of this line
                if(headings.Length > values.Length)
                {
                    var nextLine = streamReader.ReadLine();
                    var leftOverValues = nextLine.Split(',');
                    values[values.Length - 1] += '\n' + leftOverValues[0];
                    values = values.Concat(leftOverValues.Skip(1)).ToArray();
                }

                // if the headings and values have equal members, all is good to process them into the dictionary
                else if(headings.Length == values.Length)
                {
                    for(int i = 0; i < values.Length; i++)
                    {
                        if (values[i].StartsWith("\"") && values[i].EndsWith("\""))
                            values[i].Trim('\"');
                        item.Add(headings[i], values[i]);
                    }
                }

                // if there are more values than there are headings, 
                else
                {
                    string output = "";
                    foreach(string value in values)
                    {
                        output += value + ',';
                    }
                    throw new IOException("There are more values than there are headings. Find out why...\n\n" + output);
                }

                items.Add(item);
            }
            streamReader.Close();

            return items;
        }
    }
}
