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
    /// Логика взаимодействия для FurniturePage.xaml
    /// </summary>
    public partial class FurniturePage : Page
    {
        public FurniturePage()
        {
            InitializeComponent();
            if (App.CurrentUser == null || App.CurrentUser.ID_R == 3)
            {
                AddBtn.Visibility = Visibility.Collapsed;
                BackBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateFurniture()
        {
            var furnitures = App.Context.Furnitures.ToList();
            ListFurnitures.ItemsSource = furnitures;
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditFurniturePage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.FrameMain.Navigate(new AdminPage());
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentFurnitures = (sender as Button).DataContext as Entities.Furniture;
            NavigationService.Navigate(new AddEditFurniturePage(currentFurnitures));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentFurnitures = (sender as Button).DataContext as Entities.Furniture;
            if (MessageBox.Show($"Вы уверены, что хотите удалить мебель: {currentFurnitures.CategoryName}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Furnitures.Remove(currentFurnitures);
                App.Context.SaveChanges();
                UpdateFurniture();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateFurniture();
        }
    }
}
