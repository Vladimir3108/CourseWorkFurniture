using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace FurnitureCourse.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditFurniturePage.xaml
    /// </summary>
    public partial class AddEditFurniturePage : Page
    {
        private Entities.Furniture currentfurniture = null;
        public AddEditFurniturePage()
        {
            InitializeComponent();
        }

        public AddEditFurniturePage(Entities.Furniture furniture)
        {
            InitializeComponent();
            Title = "Редактирование мебели";
            currentfurniture = furniture;
            ComboCategory.SelectedIndex = currentfurniture.ID_C - 1;
            ComboMaterial.SelectedIndex = currentfurniture.ID_MA - 1;
            ComboManufacturer.SelectedIndex = currentfurniture.ID_M - 1;
            TxtPrice.Text = currentfurniture.Price.ToString();
            TxtImage.Text = currentfurniture.Image;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var category = App.Context.Categories.OrderBy(p => p.ID_C).Select(p => p.Category1).ToArray();
            var material = App.Context.Materials.OrderBy(p => p.ID_MA).Select(p => p.Name).ToArray();
            var manufacturer = App.Context.Manufacturers.OrderBy(p => p.ID_M).Select(p => p.Manufacturer1).ToArray();
            for (int i = 0; i < category.Length; i++)
                ComboCategory.Items.Add(category[i]);
            for (int i = 0; i < material.Length; i++)
                ComboMaterial.Items.Add(material[i]);
            for (int i = 0; i < manufacturer.Length; i++)
                ComboManufacturer.Items.Add(manufacturer[i]);
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            if (ComboCategory.SelectedItem == null)
                errorBuilder.AppendLine("Выберите категорию;");
            if (ComboMaterial.SelectedItem == null)
                errorBuilder.AppendLine("Выберите материал;");
            if (ComboManufacturer.SelectedItem == null)
                errorBuilder.AppendLine("Выберите производителя;");
            if (string.IsNullOrWhiteSpace(TxtPrice.Text))
                errorBuilder.AppendLine("Цена обязателена для заполнения;");
            if (decimal.Parse(TxtPrice.Text) <= 0) 
                errorBuilder.AppendLine("Цена должна быть положительнойS;");
            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите вернуться?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new FurniturePage());
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Вы уверены, что хотите выйти?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckErrors();
            string img;
            if (TxtImage.Text != null)
                img = TxtImage.Text;
            else img = "NULL";

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (currentfurniture == null)
                {
                    var furniture = new Entities.Furniture
                    {
                        ID_C = App.Context.Categories.Where(p => p.Category1 == ComboCategory.SelectedItem.ToString())
                        .Select(p => p.ID_C).FirstOrDefault(),
                        ID_MA = App.Context.Materials.Where(p => p.Name == ComboMaterial.SelectedItem.ToString())
                        .Select(p => p.ID_MA).FirstOrDefault(),
                        ID_M = App.Context.Manufacturers.Where(p => p.Manufacturer1 == ComboManufacturer.SelectedItem.ToString())
                        .Select(p => p.ID_M).FirstOrDefault(),
                        Price = decimal.Parse(TxtPrice.Text),
                        Image = img
                    };

                    App.Context.Furnitures.Add(furniture);
                    App.Context.SaveChanges();
                    MessageBox.Show("Мебель успешно создана", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new FurniturePage());
                }
                else
                {
                    currentfurniture.ID_C = App.Context.Categories.Where(p => p.Category1 == ComboCategory.SelectedItem.ToString())
                        .Select(p => p.ID_C).FirstOrDefault();
                    currentfurniture.ID_MA = App.Context.Materials.Where(p => p.Name == ComboMaterial.SelectedItem.ToString())
                        .Select(p => p.ID_MA).FirstOrDefault();
                    currentfurniture.ID_M = App.Context.Manufacturers.Where(p => p.Manufacturer1 == ComboManufacturer.SelectedItem.ToString())
                        .Select(p => p.ID_M).FirstOrDefault();
                    currentfurniture.Price = decimal.Parse(TxtPrice.Text);
                    currentfurniture.Image = img;

                    App.Context.SaveChanges();
                    MessageBox.Show("Мебель успешно обновлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new FurniturePage());
                }
            }
        }
    }
}
