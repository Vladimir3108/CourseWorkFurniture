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
    /// Логика взаимодействия для AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Page
    {
        private Entities.Manufacturer currentingManufacturer = null;
        public AddEditProduct()
        {
            InitializeComponent();
        }

        public AddEditProduct(Entities.Manufacturer manufacturer)
        {
            InitializeComponent();
            Title = "Редактирование производителя";
            currentingManufacturer = manufacturer;
            TxtName.Text = currentingManufacturer.Manufacturer1;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите вернуться?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new CategoryPage());
            }
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

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            var manufacturerFromBD = App.Context.Manufacturers.ToList()
                .FirstOrDefault(p => p.Manufacturer1.ToLower() == TxtName.Text.ToLower());
            if (string.IsNullOrWhiteSpace(TxtName.Text))
                errorBuilder.AppendLine("Имя производителя обязателено для заполнения;");
            else if (manufacturerFromBD != null && manufacturerFromBD != currentingManufacturer)
                errorBuilder.AppendLine("Такое имя уже есть в базе данных;");
            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
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
                if (currentingManufacturer == null)
                {
                    var manufacturer = new Entities.Manufacturer
                    {
                        Manufacturer1 = TxtName.Text
                    };

                    App.Context.Manufacturers.Add(manufacturer);
                    App.Context.SaveChanges();
                    MessageBox.Show("Производитель успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new CategoryPage());
                }
                else
                {
                    currentingManufacturer.Manufacturer1 = TxtName.Text;

                    App.Context.SaveChanges();
                    MessageBox.Show("Производитель успешно обновлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new CategoryPage());
                }
            }
        }
    }
}
