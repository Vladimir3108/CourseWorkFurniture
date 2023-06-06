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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void CategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            FurnitureWindow furniture = new FurnitureWindow();
            furniture.FrameMain.Navigate(new CategoryPage());
            furniture.Show();
            Window.GetWindow(this).Close();
        }

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            FurnitureWindow furniture = new FurnitureWindow();
            furniture.FrameMain.Navigate(new MaterialPage());
            furniture.Show();
            Window.GetWindow(this).Close();
        }

        private void FurnitureBtn_Click(object sender, RoutedEventArgs e)
        {
            FurnitureWindow furniture = new FurnitureWindow();
            furniture.FrameMain.Navigate(new FurniturePage());
            furniture.Show();
            Window.GetWindow(this).Close();
        }

        private void ManufacturerBtn_Click(object sender, RoutedEventArgs e)
        {
            FurnitureWindow furniture = new FurnitureWindow();
            furniture.FrameMain.Navigate(new ManufacturerPage());
            furniture.Show();
            Window.GetWindow(this).Close();
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            FurnitureWindow furniture = new FurnitureWindow();
            furniture.FrameMain.Navigate(new UserPage());
            furniture.Show();
            Window.GetWindow(this).Close();
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите выйти?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new LoginPage());
            }
        }
    }
}
