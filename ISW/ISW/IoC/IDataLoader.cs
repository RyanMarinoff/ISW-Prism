using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ISW.Model;

namespace ISW.IoC
{
    static class IDataLoader
    {
        const string _vendorFile = "N:\\Small Programs\\Exports\\Vendors.csv";

        public static void LoadVendors(ref List<Vendor> vendors)
        {
            List<Dictionary<string, string>> theList = ProcessCSV(_vendorFile);

            Vendor vendorItem;
            foreach(var item in theList)
            {
                int id = -1; // error check, all id's must be positive
                string value;
                if(item.TryGetValue("vendor_id", out value))
                {
                    value = value.Replace("\"", "");
                    int n;
                    if (int.TryParse(value, out n)) id = n;
                }
                if(id!= -1)
                {
                    vendorItem = new Vendor(id);
                }
            }
        }

        private static List<Dictionary<string,string>> ProcessCSV(string fileLocation)
        {
            Dictionary<string, string> item;
            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();

            if(fileLocation == "") return items;

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
                            if (i != length) consolidateString = false;
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
