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
using static TourAgentCreatour.client;

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для AddSale.xaml
    /// </summary>
    public partial class AddSale : Window
    {
       
        public AddSale()
        {
            InitializeComponent();
            clientView.ItemsSource = DatabaseControl.GetClientsForView();
            employeeView.ItemsSource = DatabaseControl.GetWorkEmployee();
            hotelView.ItemsSource = DatabaseControl.GetHotelsForView();
            tourView.ItemsSource = DatabaseControl.GetTransportationsForView();
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
                    if((employeeView.SelectedItem as employee).status != "Уволен")
                    {
                        if ((employeeView.SelectedItem as employee).PositionEntity.title == "Гид")
                        {
                            DatabaseControl.AddSale(new sale
                            {
                                client = (clientView.SelectedItem as client).id_client,
                                employee = (employeeView.SelectedItem as employee).id_employee,
                                hotel = (hotelView.SelectedItem as hotel).id_hotel,
                                transportation = (tourView.SelectedItem as transportation).id_transportation,
                                date_of_sale = DateTime.UtcNow,
                                rejection = StatusView.Text,
                            });

                            gridRefFive.grid.ItemsSource = null;
                            gridRefFive.grid.ItemsSource = DatabaseControl.GetSalesForView();

                            //(this.Parent as vtransport).RefreshTable();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Выберита гида", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник уже уволен", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    
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
