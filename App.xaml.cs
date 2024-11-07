using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoKystova
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DemoEntities _context;

        public static DemoEntities GetContext()
        {
            if (_context == null)
                _context = new DemoEntities();
            return _context;
        }
    }
}
