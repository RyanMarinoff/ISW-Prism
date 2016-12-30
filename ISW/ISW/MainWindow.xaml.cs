using Microsoft.Win32;
using System.Windows;

using ISW.IoC;

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
            if (IDataLoader.ProductsCount < 1)
            {
                string _ext = ".txt";
                string _filter = "Pipe Delimited Categories File|*.txt";
                string _file;

                if (IDataLoader.CategoriesCount < 1)
                {
                    MessageBox.Show("Load Categories");
                    _file = getFileName(_ext, _filter);
                    IDataLoader.LoadCategories(_file);
                    MessageBox.Show(IDataLoader.CategoriesCount + " categories loaded.");
                }

                _filter = _filter.Replace("Categories", "Options");
                if (IDataLoader.OptionsCount < 1)
                {
                    _filter = _filter.Replace("Options", "OptionCategories");
                    if (IDataLoader.OptionCategoriesCount < 1)
                    {
                        MessageBox.Show("Load OptionCategories");
                        _file = getFileName(_ext, _filter);
                        IDataLoader.LoadOptionCategories(_file);
                        MessageBox.Show(IDataLoader.OptionCategoriesCount + " option categories loaded.");
                    }

                    MessageBox.Show("Load Options");
                    _filter = _filter.Replace("OptionCategories", "Options");
                    _file = getFileName(_ext, _filter);
                    IDataLoader.LoadOptions(_file);
                    MessageBox.Show(IDataLoader.OptionsCount + " options loaded.");
                }

                _filter = _filter.Replace("Options", "Vendors");
                if (IDataLoader.VendorsCount < 1)
                {
                    MessageBox.Show("Load Vendors");
                    _file = getFileName(_ext, _filter);
                    IDataLoader.LoadVendors(_file);
                    MessageBox.Show(IDataLoader.VendorsCount + " vendors loaded.");
                }

                MessageBox.Show("Load Products");
                _filter.Replace("Vendors", "Categories");
                _file = getFileName(_ext, _filter);

                IDataLoader.LoadProducts(_file);
                MessageBox.Show(IDataLoader.ProductsCount + " products loaded.");
            }
            else
            {
                MessageBox.Show(IDataLoader.ProductsCount + " Products already loaded.");
            }
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
