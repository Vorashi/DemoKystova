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
        private Partner _selectedPartner;
        private readonly DemoEntities _context;
        public AddEditPartnerView(Partner partner = null)
        {
            InitializeComponent();
            _context = App.GetContext();
            TypeComboBox.ItemsSource = new List<string>{"ЗАО", "ООО", "ПАО", "ОАО", "ЭУЭ"};
            if (partner != null)
            {
                DataContext = partner;
                _selectedPartner = partner;
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
                {
                    if (!IsCorrectPartner(_newPartner))
                        throw new Exception();
                    _context.Partner.Add(_newPartner);
                }
                else
                {
                    if (!IsCorrectPartner(_selectedPartner))
                        throw new Exception();
                }
                _context.SaveChanges();
                MessageBox.Show("Успешно сохранено");
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить");
            }
        }

        private bool IsCorrectPartner(Partner partner)
        {
            if ( partner == null )
                return false;
            if (partner.type.Length > 10)
                return false;
            if (partner.name.Length > 50)
                return false;
            if (partner.director.Length > 50) 
                return false;
            if (partner.mail.Length > 50 || !partner.mail.Contains('@'))
                return false;

            return true;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Name.Clear();
            Rating.Clear();
            Address.Clear();
            Director.Clear();
            Phone.Clear();
            Mail.Clear();
            Inn.Clear();
        }
    }
}
