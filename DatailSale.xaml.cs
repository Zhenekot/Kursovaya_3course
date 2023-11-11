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
    /// Логика взаимодействия для DatailSale.xaml
    /// </summary>
    public partial class DatailSale : Window
    {
        public DatailSale(sale sale)
        {
            InitializeComponent();
            
            title.Text = sale.TransportationEntity.title;
            start_date.Text = sale.TransportationEntity.start_date.ToString();
            end_date.Text = sale.TransportationEntity.end_date.ToString();
            Hotel.Text = sale.HotelEntity.title;
            typeOfFood.Text = sale.TransportationEntity.type_of_food;
            Cost.Text = sale.TransportationEntity.cost.ToString();
            nameClient.Text = sale.ClientEntity.name;
            surnameClient.Text = sale.ClientEntity.surname;
            patronymicClient.Text = sale.ClientEntity.patronymic;
            nameEmployee.Text = sale.EmployeeEntity.name;
            surnameEmployee.Text = sale.EmployeeEntity.surname;
            patronymicEmployee.Text = sale.EmployeeEntity.patronymic;
            rejection.Text = sale.rejection;
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
