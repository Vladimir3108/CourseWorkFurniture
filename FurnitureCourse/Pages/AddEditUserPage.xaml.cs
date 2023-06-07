using FurnitureCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        Regex pass = new Regex(@"^\w{4,50}$");
        Regex name = new Regex(@"^[А-ЯЁ][а-яё]+$");
        MatchCollection match;
        private Entities.User currentuser = null;
        public AddEditUserPage()
        {
            InitializeComponent();
        }

        public AddEditUserPage(Entities.User user)
        {
            InitializeComponent();
            Title = "Редактирование пользователей";
            currentuser = user;
            TxtSurname.Text = currentuser.Surname;
            TxtName.Text = currentuser.Name;
            if (user.Patronymic == "NULL")
                TxtPatronymic.Text = "";
            else TxtPatronymic.Text = currentuser.Patronymic;
            TxtLogin.Text = currentuser.Login;
            TxtPass.Text = currentuser.Password;
            ComboRole.SelectedIndex = currentuser.ID_R - 1;
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите выйти?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите вернуться?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new UserPage());
            }
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            var userFromBD = App.Context.Users.ToList()
                .FirstOrDefault(p => p.Login.ToLower() == TxtLogin.Text.ToLower());
            if (string.IsNullOrWhiteSpace(TxtSurname.Text))
                errorBuilder.AppendLine("Фамилия обязательна для заполнения;");
            match = name.Matches(TxtSurname.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введена фамилия");
            if (string.IsNullOrWhiteSpace(TxtName.Text))
                errorBuilder.AppendLine("Имя обязательно для заполнения;");
            match = name.Matches(TxtName.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено имя");
            if (TxtPatronymic.Text != "")
            {
                match = name.Matches(TxtPatronymic.Text);
                if (match.Count == 0)
                    errorBuilder.AppendLine("Некорректно введено отчество");
            }
            if (string.IsNullOrWhiteSpace(TxtLogin.Text))
                errorBuilder.AppendLine("Логин обязателен для заполнения;");
            else if (userFromBD != null && userFromBD != currentuser)
                errorBuilder.AppendLine("Такой логин уже используется;");
            match = pass.Matches(TxtPass.Text);
            if (match.Count == 0)
                if (string.IsNullOrWhiteSpace(TxtPass.Text))
                    errorBuilder.AppendLine("Пароль обязателен для заполнения;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string patronymic;
            if (TxtPatronymic.Text == null)
                patronymic = "NULL";
            else patronymic = TxtPatronymic.Text;
            var errorMessage = CheckErrors();

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (currentuser == null)
                {
                    var user = new Entities.User
                    {
                        Surname = TxtSurname.Text,
                        Name = TxtName.Text,
                        Patronymic = patronymic,
                        Login = TxtLogin.Text,
                        Password = TxtPass.Text,
                        ID_R = App.Context.Roles.Where(p => p.Role1 == ComboRole.SelectedItem.ToString())
                        .Select(p => p.ID_R).FirstOrDefault()
                    };

                    App.Context.Users.Add(user);
                    App.Context.SaveChanges();
                    MessageBox.Show("Пользователь успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new UserPage());
                }
                else
                {
                    currentuser.Surname = TxtSurname.Text;
                    currentuser.Name = TxtName.Text;
                    currentuser.Patronymic = patronymic;
                    currentuser.Login = TxtLogin.Text;
                    currentuser.Password = TxtPass.Text;
                    currentuser.ID_R = App.Context.Roles.Where(p => p.Role1 == ComboRole.SelectedItem.ToString())
                        .Select(p => p.ID_R).FirstOrDefault();

                    App.Context.SaveChanges();
                    MessageBox.Show("Пользователь успешно обновлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new UserPage());
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var roles = App.Context.Roles.OrderBy(p => p.ID_R).Select(p => p.Role1).ToArray();
            for (int i = 0; i < roles.Length; i++)
                ComboRole.Items.Add(roles[i]);
        }
    }
}
