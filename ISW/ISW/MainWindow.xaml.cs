using ISW.IoC;
using ISW.Model;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ISW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Testing Code
        /************************************************/
        /* Nearly everything within this section will   */
        /* not be implemented into the final code. This */
        /* will be removed after testing is completed.  */
        /* **********************************************/
        
        private void _btnTestProduct_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Sorry, not ready yet.");
            
            string _ext = ".txt";
            string _filter = "Pipe Delimited Categories File|*.txt";
            string _file;

            List<Category> _categories;
            if (IData.Categories == null)
            {
                MessageBox.Show("Load Categories");
                _file = getFileName(_ext, _filter);
                _categories = new List<Category>();
                IDataLoader.LoadCategories(_file, ref _categories);
                IData.Categories = _categories;
            }
            else
            {
                _categories = IData.Categories;
            }

            List<Option> _options;
            _filter = _filter.Replace("Categories", "Options");
            if(IData.Options == null)
            {
                MessageBox.Show("Load OptionCategories");
                _filter = _filter.Replace("Options", "OptionCategories");
                _file = getFileName(_ext, _filter);
                List<OptionCategory> _optCat = new List<OptionCategory>();
                IDataLoader.LoadOptionCategories(_file, ref _optCat);
                IData.OptCategories = _optCat;

                MessageBox.Show("Load Options");
                _filter = _filter.Replace("OptionCategories", "Options");
                _file = getFileName(_ext, _filter);
                _options = new List<Option>();
                IDataLoader.LoadOptions(_file, ref _options, ref _optCat);
                IData.Options = _options;
            }
            else
            {
                _options = IData.Options;
            }

            List<Vendor> _vendors;
            _filter = _filter.Replace("Options", "Vendors");
            if(IData.Vendors == null)
            {
                MessageBox.Show("Load Vendors");
                _file = getFileName(_ext, _filter);
                _vendors = new List<Vendor>();
                IDataLoader.LoadVendors(_file, ref _vendors);
                IData.Vendors = _vendors;
            }
            else
            {
                _vendors = IData.Vendors;
            }

            MessageBox.Show("Load Products");
            _filter.Replace("Vendors", "Categories");
            _file = getFileName(_ext, _filter);
            List<ParentProduct> _products = new List<ParentProduct>();

            IDataLoader.LoadProducts(_file, ref _products, ref _categories, ref _options, ref _vendors);
            IData.Products = _products;

            MessageBox.Show(_products.Count() + " products loaded.");
        }

        private void _btnTestVendor_Click(object sender, RoutedEventArgs e)
        {
            string _ext = ".txt";
            string _filter = "Pipe Delimited Vendor File|*.txt";
            string _file = getFileName(_ext, _filter);
            List<Vendor> _vendors = new List<Vendor>();
            IDataLoader.LoadVendors(_file, ref _vendors);
            IData.Vendors = _vendors;
            MessageBox.Show(_vendors.Count() + " vendors loaded.");
        }

        private void _btnTestOption_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Make sure to choose both Option Categories and Options.");
            string _ext = ".txt";
            string _filter = "Pipe Delimited OptionCategory File|*.txt";
            string _file = getFileName(_ext, _filter);
            List<OptionCategory> _optCat = new List<OptionCategory>();
            IDataLoader.LoadOptionCategories(_file, ref _optCat);
            IData.OptCategories = _optCat;

            _filter = _filter.Replace("OptionCategory", "Option");
            _file = getFileName(_ext, _filter);
            List<Option> _options = new List<Option>();
            IDataLoader.LoadOptions(_file, ref _options, ref _optCat);
            IData.Options = _options;

            MessageBox.Show(_options.Count() + " options loaded.");
        }

        private void _btnTestCategory_Click(object sender, RoutedEventArgs e)
        {
            string _ext = ".txt";
            string _filter = "Pipe Delimited Category File|*.txt";
            string _file = getFileName(_ext, _filter);
            List<Category> _categories = new List<Category>();
            IDataLoader.LoadCategories(_file, ref _categories);
            IData.Categories = _categories;
            MessageBox.Show(_categories.Count() + " categories loaded.");

            string CatData = "";
            foreach(Category category in _categories)
            {
                CatData += category.ToString() + "\n";
            }
            MessageBox.Show(CatData);
        }

        private string getFileName(string fileExt, string fileFilter)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = fileExt;
            dlg.Filter = fileFilter;

            bool? result = dlg.ShowDialog();

            string fileName = "";
            if (result == true)
            {
                fileName = dlg.FileName;
            }
            return fileName;
        }
        #endregion
    }
}
