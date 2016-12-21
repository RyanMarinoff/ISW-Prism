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

        private void _btnTestProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, not ready yet.");
        }

        private void _btnTestVendor_Click(object sender, RoutedEventArgs e)
        {
            string _ext = ".csv";
            string _filter = "CSV Based Vendor File|*.csv";
            string _file = getFileName(_ext, _filter);
            List<Vendor> _vendors = new List<Vendor>();
            IDataLoader.LoadVendors(_file, ref _vendors);
            MessageBox.Show(_vendors.Count() + " vendors loaded.");
        }

        private void _btnTestOption_Click(object sender, RoutedEventArgs e)
        {
            string _ext = ".csv";
            string _filter = "CSV Based Option File|*.csv";
            string _file = getFileName(_ext, _filter);
            List<Option> _options = new List<Option>();
            IDataLoader.LoadOptions(_file, ref _options);
            MessageBox.Show(_options.Count() + " options loaded.");
        }

        private void _btnTestCategory_Click(object sender, RoutedEventArgs e)
        {
            string _ext = ".csv";
            string _filter = "CSV Based Category File|*.csv";
            string _file = getFileName(_ext, _filter);
            List<Category> _categories = new List<Category>();
            IDataLoader.LoadCategories(_file, ref _categories);
            MessageBox.Show(_categories.Count() + " categories loaded.");
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
    }
}
