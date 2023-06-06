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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void UpdateUser()
        {
            var users = App.Context.Users.ToList();
            ListUsers.ItemsSource = users;
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
            NavigationService.Navigate(new AddEditUserPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.FrameMain.Navigate(new AdminPage());
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUsers = (sender as Button).DataContext as Entities.User;
            if (MessageBox.Show($"Вы уверены, что хотите удалить пользователя: {currentUsers.Surname} {currentUsers.Name}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Users.Remove(currentUsers);
                App.Context.SaveChanges();
                UpdateUser();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUsers = (sender as Button).DataContext as Entities.User;
            NavigationService.Navigate(new AddEditUserPage(currentUsers));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUser();
        }
    }
}
