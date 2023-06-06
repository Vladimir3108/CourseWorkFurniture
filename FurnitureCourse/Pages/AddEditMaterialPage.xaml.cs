using FurnitureCourse.Entities;
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
    /// Логика взаимодействия для AddEditMaterialPage.xaml
    /// </summary>
    public partial class AddEditMaterialPage : Page
    {
        private Entities.Material currentingMaterial = null;
        public AddEditMaterialPage()
        {
            InitializeComponent();
        }

        public AddEditMaterialPage(Entities.Material material)
        {
            InitializeComponent();
            Title = "Редактирование материалов";
            currentingMaterial = material;
            TxtName.Text = currentingMaterial.Name;
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
                NavigationService.Navigate(new MaterialPage());
            }
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            var materialFromBD = App.Context.Materials.ToList()
                .FirstOrDefault(p => p.Name.ToLower() == TxtName.Text.ToLower());
            if (string.IsNullOrWhiteSpace(TxtName.Text))
                errorBuilder.AppendLine("Имя материала обязателено для заполнения;");
            else if (materialFromBD != null && materialFromBD != currentingMaterial)
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
                if (currentingMaterial == null)
                {
                    var material = new Entities.Material
                    {
                        Name = TxtName.Text
                    };

                    App.Context.Materials.Add(material);
                    App.Context.SaveChanges();
                    MessageBox.Show("Материал успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new CategoryPage());
                }
                else
                {
                    currentingMaterial.Name = TxtName.Text;

                    App.Context.SaveChanges();
                    MessageBox.Show("Материал успешно обновлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new CategoryPage());
                }
            }
        }
    }
}
