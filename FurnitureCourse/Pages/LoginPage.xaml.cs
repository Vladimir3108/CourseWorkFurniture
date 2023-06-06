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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currect_user = App.Context.Users.FirstOrDefault(u => u.Login == TBoxLogin.Text && u.Password == PBoxPassword.Password);
            if (currect_user != null)
            {
                App.CurrentUser = currect_user;
                if (currect_user.ID_R == 1)
                {
                    NavigationService.Navigate(new AdminPage());
                }
                else
                {
                    FurnitureWindow game = new FurnitureWindow();
                    game.Show();
                    Window.GetWindow(this).Close();
                }
            }
            else
            {
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow register = new RegistrationWindow();
            register.Show();
            Window.GetWindow(this).Close();
        }
    }
}
