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

namespace DemoKystova.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditPartner.xaml
    /// </summary>
    public partial class AddEditPartnerView : Window
    {
        Partner _newPartner;
        public AddEditPartnerView()
        {
            InitializeComponent();
            _newPartner = new Partner();
            DataContext = _newPartner;
        }

        public AddEditPartnerView(Partner partner)
        {
            InitializeComponent();
            DataContext = partner;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено");
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить");
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
