using DemoKystova.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoKystova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<Partner> _parnersList; //создаем поле списка партнеров
        private Partner _partner;
        public MainWindow()
        {
            InitializeComponent();

            // Заполнение ListView данными.
            UpdateListView(PartnerListView);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_partner == null)
            {
                MessageBox.Show("Не выбран партнер");
                return;
            }
            AddEditPartnerView EditWindow = new AddEditPartnerView(_partner);
            EditWindow.ShowDialog();
            UpdateListView(PartnerListView);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditPartnerView AddWindow = new AddEditPartnerView();
            AddWindow.ShowDialog();
            UpdateListView(PartnerListView);
        }

        private void UpdateListView(ListView lst)
        {
            _parnersList = App.GetContext().Partner.ToList();
            lst.ItemsSource = _parnersList;
        }

        private void PartnerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PartnerListView.SelectedItems.Count > 0)
            {
                EditBtn.Visibility = Visibility.Visible;
                _partner = PartnerListView.SelectedItem as Partner;
            }
        }
    }
}
