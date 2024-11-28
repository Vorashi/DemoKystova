using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для HistoryProductsSalesView.xaml
    /// </summary>
    public partial class HistoryProductsSalesView : Window
    {
        private readonly DemoEntities _context;
        private ObservableCollection<PartnerProduct> _partnerProducts;
        public ObservableCollection<PartnerProduct> PartnerProducts
        {
            get => _partnerProducts;
            set => _partnerProducts = value;
        }
        public HistoryProductsSalesView(Partner selectedPartner = null)
        {
            InitializeComponent();
            _context = App.GetContext();
            if (selectedPartner == null)
            {
                PartnerProducts = new ObservableCollection<PartnerProduct>(_context.PartnerProduct);
                UpdateListView(ListHistoryProductsSales);
                return;
            }
            PartnerProducts = new ObservableCollection<PartnerProduct> (_context.PartnerProduct.Where(p => p.id_partner == selectedPartner.id_partner));
            UpdateListView(ListHistoryProductsSales);
            if (PartnerProducts.Count == 0)
            {
                MessageBox.Show("У выбранного партнера пока нет реализованной продукции");
            }
        }

        private void UpdateListView(ListView lst)
        {
            lst.ItemsSource = PartnerProducts;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
