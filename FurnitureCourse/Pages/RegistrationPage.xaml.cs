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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Regex pass = new Regex(@"^\w{4,50}$"); 
        Regex name = new Regex(@"^[А-ЯЁ][а-яё]+$");
        MatchCollection match; 
        private Entities.User user = null;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var user = new Entities.User(); if (TxtPatronymic == null)
                {
                    user = new Entities.User
                    {
                        Surname = TxtSurname.Text,
                        Name = TxtName.Text,
                        Patronymic = "NULL",
                        Login = TxtLogin.Text,
                        Password = TxtPass.Password,
                        ID_R = 3
                    };
                }
                else
                {
                    user = new Entities.User
                    {
                        Surname = TxtSurname.Text,
                        Name = TxtName.Text,
                        Patronymic = TxtPatronymic.Text,
                        Login = TxtLogin.Text,
                        Password = TxtPass.Password,
                        ID_R = 3
                    };
                }
                App.Context.Users.Add(user);
                App.Context.SaveChanges(); MessageBox.Show("Вы успешно зарегистрировались", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder(); var materialFromBD = App.Context.Users.ToList()
                .FirstOrDefault(p => p.Login.ToLower() == TxtLogin.Text.ToLower()); if (string.IsNullOrWhiteSpace(TxtSurname.Text))
                errorBuilder.AppendLine("Фамилия обязательна для заполнения;"); match = name.Matches(TxtSurname.Text);
            if (match.Count == 0) errorBuilder.AppendLine("Некорректно введена фамилия");
            if (string.IsNullOrWhiteSpace(TxtName.Text)) errorBuilder.AppendLine("Имя обязательно для заполнения;");
            match = name.Matches(TxtName.Text); if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено имя"); if (TxtPatronymic.Text != "")
            {
                match = name.Matches(TxtPatronymic.Text);
                if (match.Count == 0) errorBuilder.AppendLine("Некорректно введено отчество");
            }
            if (string.IsNullOrWhiteSpace(TxtLogin.Text))
                errorBuilder.AppendLine("Логин обязателен для заполнения;");
            else if (materialFromBD != null && materialFromBD != user)
                errorBuilder.AppendLine("Такой логин уже используется;"); match = pass.Matches(TxtPass.Password);
            if (match.Count == 0) if (string.IsNullOrWhiteSpace(TxtPass.Password))
                    errorBuilder.AppendLine("Пароль обязателен для заполнения;"); if (TxtPass.Password != TxtPassRep.Password)
                errorBuilder.Append("Пароли не совпадают");
            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");
            return errorBuilder.ToString();
        }
    }
}
