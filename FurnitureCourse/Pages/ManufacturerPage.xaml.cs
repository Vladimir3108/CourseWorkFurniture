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

namespace FurnitureCourse.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManufacturerPage.xaml
    /// </summary>
    public partial class ManufacturerPage : Page
    {
        public ManufacturerPage()
        {
            InitializeComponent();
        }

        private void UpdateManufacturers()
        {
            var manufacturers = App.Context.Manufacturers.ToList();
            ListManufacturers.ItemsSource = manufacturers;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите выйти?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.FrameMain.Navigate(new AdminPage());
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProduct());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentManufacturers = (sender as Button).DataContext as Entities.Manufacturer;
            if (MessageBox.Show($"Вы уверены, что хотите удалить производителя: {currentManufacturers.Manufacturer1}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Manufacturers.Remove(currentManufacturers);
                App.Context.SaveChanges();
                UpdateManufacturers();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentManufacturers = (sender as Button).DataContext as Entities.Manufacturer;
            NavigationService.Navigate(new AddEditProduct(currentManufacturers));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateManufacturers();
        }
    }
}
