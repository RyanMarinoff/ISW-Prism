using ISW.IoC;
using Microsoft.Win32;
using System.Windows;

namespace ISW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            // Disable shutdown when the dialog closes
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            if (LoadData())
            {
                var mainWindow = new MainWindow();
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = mainWindow;
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Unable to load data.", "Error", MessageBoxButton.OK);
                Current.Shutdown(-1);
            }
        }

        private bool LoadData()
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
                return false;
                //MessageBox.Show(IDataLoader.ProductsCount + " Products already loaded.");
            }
            return true;
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
