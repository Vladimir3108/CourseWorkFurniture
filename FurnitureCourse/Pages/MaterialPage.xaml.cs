﻿using System;
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
    /// Логика взаимодействия для MaterialPage.xaml
    /// </summary>
    public partial class MaterialPage : Page
    {
        public MaterialPage()
        {
            InitializeComponent();
        }

        private void UpdateMaterials()
        {
            var materials = App.Context.Materials.ToList();
            ListMaterials.ItemsSource = materials;
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
            NavigationService.Navigate(new AddEditMaterialPage());
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
            var currentMaterials = (sender as Button).DataContext as Entities.Material;
            NavigationService.Navigate(new AddEditMaterialPage(currentMaterials));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentCategories = (sender as Button).DataContext as Entities.Category;
            if (MessageBox.Show($"Вы уверены, что хотите удалить материал: {currentCategories.Category1}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Categories.Remove(currentCategories);
                App.Context.SaveChanges();
                UpdateMaterials();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMaterials();
        }
    }
}
