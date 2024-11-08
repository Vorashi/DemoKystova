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
        private Partner _newPartner;
        private DemoEntities _context;
        public AddEditPartnerView(Partner partner=null)
        {
            InitializeComponent();
            _context = App.GetContext();
            if (partner != null)
            {
                DataContext = partner;
                return;
            }
            _newPartner = new Partner();
            DataContext = _newPartner;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if( _newPartner != null ) 
                    _context.Partner.Add(_newPartner);
                _context.SaveChanges();
                MessageBox.Show("Успешно сохранено");
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить");
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Name.Clear();
            Type.Clear();
            Rating.Clear();
            Address.Clear();
            Director.Clear();
            Phone.Clear();
            Mail.Clear();
            Inn.Clear();
        }
    }
}
