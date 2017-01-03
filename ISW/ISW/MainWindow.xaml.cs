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
