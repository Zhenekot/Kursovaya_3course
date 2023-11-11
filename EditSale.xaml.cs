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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для EditSale.xaml
    /// </summary>
    public partial class EditSale : Window
    {
        sale _sale = new sale();
        public EditSale(sale sale)
        {
            InitializeComponent();
            _sale = sale;
            clientView.ItemsSource = DatabaseControl.GetClientsForView();
            employeeView.ItemsSource = DatabaseControl.GetEmployeesForView();
            hotelView.ItemsSource = DatabaseControl.GetHotelsForView();
            tourView.ItemsSource = DatabaseControl.GetTransportationsForView();

            clientView.SelectedValue = sale.ClientEntity.id_client;
            employeeView.SelectedValue = sale.EmployeeEntity.id_employee;
            hotelView.SelectedValue = sale.HotelEntity.id_hotel;
            tourView.SelectedValue = sale.TransportationEntity.id_transportation;
            StatusView.Text = sale.rejection;

        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            if ((clientView.Text != "") && (employeeView.Text != "") && (hotelView.Text != "") && (tourView.Text != "") && (StatusView.Text != ""))
            {
                if ((hotelView.SelectedItem as hotel).city == (tourView.SelectedItem as transportation).TourEntity.city)
                {

                    _sale.client = (clientView.SelectedItem as client).id_client;
                    _sale.employee = (employeeView.SelectedItem as employee).id_employee;
                    _sale.hotel = (hotelView.SelectedItem as hotel).id_hotel;
                    _sale.transportation = (tourView.SelectedItem as transportation).id_transportation;
                    _sale.rejection = StatusView.Text;
                    _sale.date_of_sale = DateTime.UtcNow;
                    DatabaseControl.UpdateSale(_sale);

                    gridRefFive.grid.ItemsSource = null;
                    gridRefFive.grid.ItemsSource = DatabaseControl.GetSalesForView();

                    //(this.Parent as vtransport).RefreshTable();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Город тура и город отеля должны совпадать", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Строки не должны быть пустыми", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
