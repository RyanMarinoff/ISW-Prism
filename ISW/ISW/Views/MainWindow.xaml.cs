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

using System.Windows;

namespace ISW.Views
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WarningBox wb = new WarningBox();
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Select where you want to save the files to:";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool success;
                wb.Show();
                //IoC.IDataLoader.ProductOverCount(5, dialog.SelectedPath);
                success = IoC.IDataLoader.ProductWithinCategory(50, 260, 541, dialog.SelectedPath);
                if (success)
                    MessageBox.Show("Mens Sandals Output within " + dialog.SelectedPath);
                else
                    MessageBox.Show("Problem with mens sandals");
                success = IoC.IDataLoader.ProductWithinCategory(29, 299, 541, dialog.SelectedPath);
                if (success)
                    MessageBox.Show("Womens Sandals Output within " + dialog.SelectedPath);
                else
                    MessageBox.Show("Problem with womens sandals");
                wb.Close();

                MessageBox.Show("All Product sandals Output to " + dialog.SelectedPath);
            }
        }
    }
}
