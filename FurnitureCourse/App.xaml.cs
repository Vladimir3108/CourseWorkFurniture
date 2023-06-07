using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FurnitureCourse
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.FurnitureSQLEntities1 Context { get; } = new Entities.FurnitureSQLEntities1(); 
        public static Entities.User CurrentUser = null;
    }
}
 