using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для vstatistic.xaml
    /// </summary>
    public partial class vstatistic : Page
    {
        //public List<transport> transports;
        //public List<client> clients;
        //public List<employee> employees;
        //public List<sale> sales;
        //public List<tour> tours;
        //public List<sale> salesRej;
        //public List<sale> salesNoRej;
        //public List<sale> salesTourPop;

        public vstatistic(string access)
        {
            InitializeComponent();
            

                MainStatistic.Visibility = Visibility.Collapsed;
        }

        private void ButStatic_Click(object sender, RoutedEventArgs e)
        {
            
            TotalTransport.Text = (DatabaseControl.GetTransportsForView().Count).ToString();
            TotalTour.Text = (DatabaseControl.GetToursForView().Count).ToString();
            TotalClient.Text = (DatabaseControl.GetClientsForView().Count).ToString();
            TotalEmpl.Text = (DatabaseControl.GetEmployeesForView().Count).ToString();
            if (timeInfo.SelectedIndex == 0)
            {
                timeView.Text = timeInfo.Text;
                MainStatistic.Visibility = Visibility.Visible;

                TotalSale.Text = (DatabaseControl.GetSalesForView().Count).ToString();
                TotalSaleNoReject.Text = (DatabaseControl.GetSalesNoRejectForView().Count).ToString();
                TotalSaleReject.Text = (DatabaseControl.GetSalesRejectForView().Count).ToString();

            } else if (timeInfo.SelectedIndex == 1)
            {
                timeView.Text = timeInfo.Text;
                MainStatistic.Visibility = Visibility.Visible;
                DateTime thirtyDay = DateTime.Today.AddDays(-30);
                using (DbAppContext ctx = new DbAppContext())
                {
                    TotalSale.Text = ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.date_of_sale >= thirtyDay).Count().ToString();
                    TotalSaleNoReject.Text = ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.date_of_sale >= thirtyDay && t.rejection == "Продано").Count().ToString();
                    TotalSaleReject.Text = ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.date_of_sale >= thirtyDay && t.rejection == "Отказ").Count().ToString();
                }
            }else if (timeInfo.SelectedIndex == 2)
            {
                timeView.Text = timeInfo.Text;
                MainStatistic.Visibility = Visibility.Visible;
                DateTime year = DateTime.Today.AddYears(-1);
                using (DbAppContext ctx = new DbAppContext())
                {
                    TotalSale.Text = ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.date_of_sale >= year).Count().ToString();
                    TotalSaleNoReject.Text = ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.date_of_sale >= year && t.rejection == "Продано").Count().ToString();
                    TotalSaleReject.Text = ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.date_of_sale >= year && t.rejection == "Отказ").Count().ToString();
                }
            }
            
        }
    }
}
