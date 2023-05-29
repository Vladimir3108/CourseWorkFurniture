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
using System.Windows.Shapes;

namespace FurnitureCourse
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            FrameMain.Navigate(new Pages.RegistrationPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
