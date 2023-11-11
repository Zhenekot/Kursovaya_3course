
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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для DatailTour.xaml
    /// </summary>
    public partial class DatailTour : Page
    {
        public DatailTour(transportation transportation)
        {
            InitializeComponent();
            //picture
            title.Text = transportation.title;
            city.Text = transportation.TourEntity.city;
            titleTour.Text = transportation.TourEntity.title;
            start_date.Text = transportation.start_date.ToString();
            end_date.Text = transportation.end_date.ToString();
            transport.Text = transportation.transportEntity.title;
            transportNum.Text = transportation.transportEntity.number;
            typeOfFood.Text = transportation.type_of_food;
            Cost.Text = transportation.cost.ToString();
            excursion.Text = transportation.TourEntity.excursion;
        }
        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }
    }
}
