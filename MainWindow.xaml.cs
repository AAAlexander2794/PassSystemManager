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

namespace PassSystemManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var recordsList = FileController.GetRecordInfosFromFile(FileNameTextBox.Text);
            RecordsDataGrid.ItemsSource = recordsList;
            RecordsDataGrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var recordsList = FileController.GetRecordsFromFile(FileNameTextBox.Text);
            RecordsDataGrid.ItemsSource = recordsList;
            RecordsDataGrid.Items.Refresh();
        }

        // Минус час
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileController.ChangeDateTime(FileController.Records, -1);
            RecordsDataGrid.ItemsSource = FileController.Records;
            RecordsDataGrid.Items.Refresh();
        }

        // Плюс час
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FileController.ChangeDateTime(FileController.Records, 1);
            RecordsDataGrid.ItemsSource = FileController.Records;
            RecordsDataGrid.Items.Refresh();
            //MessageBox.Show(FileController.Records.First().DateTime.ToString());
        }

        // Сохранить
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FileController.WriteFileAsync(FileController.Records, FileNameTextBox_Out.Text);
        }
    }
}
