using FileSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace File_Sort
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

        private void btn_beginSort_Click(object sender, RoutedEventArgs e)
        {
            if(txtBox_folderPath.Text.Length == 0 || cmbBox_sortingType.SelectedIndex == 0)
            {
                MessageBox.Show("Please make sure you have entered your Folder Path and selected a Sorting Method");
            }
            else
            {
                FileSorter.Sort(txtBox_folderPath.Text, cmbBox_sortingType.SelectedIndex);
            }
            MessageBox.Show("All files sorted", "Success", MessageBoxButton.OK);
        }

        public static string DirectoryNotFoundChoice(string fileName)
        {
            if (MessageBox.Show($"Not all required folders currently exist to sort {fileName}\nWould you like to create the required folders to sort this file?\nIf not this file will not be sorted."
                    , "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtBox_destinationFolder_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void cmbBox_sortingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
