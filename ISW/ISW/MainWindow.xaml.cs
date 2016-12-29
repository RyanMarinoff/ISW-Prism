using ISW.IoC;
using ISW.Model;
using Microsoft.Win32;
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
            
            if (IData.Categories == null)
            {
                MessageBox.Show("Load Categories");
                _file = getFileName(_ext, _filter);
                IDataLoader.LoadCategories(_file);
                MessageBox.Show(IData.Categories.Count() + " categories loaded.");
            }
            
            _filter = _filter.Replace("Categories", "Options");
            if(IData.Options == null)
            {
                MessageBox.Show("Load OptionCategories");
                _filter = _filter.Replace("Options", "OptionCategories");
                _file = getFileName(_ext, _filter);
                IDataLoader.LoadOptionCategories(_file);
                MessageBox.Show(IData.OptCategories.Count() + " option categories loaded.");

                MessageBox.Show("Load Options");
                _filter = _filter.Replace("OptionCategories", "Options");
                _file = getFileName(_ext, _filter);
                IDataLoader.LoadOptions(_file);
                MessageBox.Show(IData.Options.Count() + " options loaded.");
            }
            
            _filter = _filter.Replace("Options", "Vendors");
            if(IData.Vendors == null)
            {
                MessageBox.Show("Load Vendors");
                _file = getFileName(_ext, _filter);
                IDataLoader.LoadVendors(_file);
                MessageBox.Show(IData.Vendors.Count() + " vendors loaded.");
            }

            MessageBox.Show("Load Products");
            _filter.Replace("Vendors", "Categories");
            _file = getFileName(_ext, _filter);

            IDataLoader.LoadProducts(_file);
            MessageBox.Show(IData.Products.Count() + " products loaded.");
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
