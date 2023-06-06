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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FurnitureCourse.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditCategoryPage.xaml
    /// </summary>
    public partial class AddEditCategoryPage : Page
    {
        private Entities.Category currentingCategory = null;
        public AddEditCategoryPage()
        {
            InitializeComponent();
        }

        public AddEditCategoryPage(Entities.Category category)
        {
            InitializeComponent();
            Title = "Редактирование категории";
            currentingCategory = category;
            TxtName.Text = currentingCategory.Category1;
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
                NavigationService.Navigate(new CategoryPage());
            }
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            var categoryFromBD = App.Context.Categories.ToList()
                .FirstOrDefault(p => p.Category1.ToLower() == TxtName.Text.ToLower());
            if (string.IsNullOrWhiteSpace(TxtName.Text))
                errorBuilder.AppendLine("Имя категории обязателено для заполнения;");
            else if (categoryFromBD != null && categoryFromBD != currentingCategory)
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
                if (currentingCategory == null)
                {
                    var category = new Entities.Category
                    {
                        Category1 = TxtName.Text
                    };

                    App.Context.Categories.Add(category);
                    App.Context.SaveChanges();
                    MessageBox.Show("Категория успешно создана", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new CategoryPage());
                }
                else
                {
                    currentingCategory.Category1 = TxtName.Text;

                    App.Context.SaveChanges();
                    MessageBox.Show("Категория успешно обновлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new CategoryPage());
                }
            }
        }
    }
}
