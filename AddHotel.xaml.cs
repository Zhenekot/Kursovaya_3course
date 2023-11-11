using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static TourAgentCreatour.hotel;

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        public AddHotel()
        {
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            Regex regTwo = new Regex(@"8\d{10}");
            if ((titleView.Text != "") && (clHotelView.Text != "") && (cityView.Text != "") && (addressView.Text != "") && (phoneNumView.Text != ""))
            {
                if ((regTwo.IsMatch(phoneNumView.Text)) && (phoneNumView.Text.Length == 11))
                {
                    try
                    {


                        hotel _hotel = new hotel();
                        _hotel.title = titleView.Text;
                        _hotel.hotel_class = Convert.ToInt32(clHotelView.Text);
                        _hotel.phone_number = phoneNumView.Text;
                        _hotel.address = addressView.Text;
                        _hotel.city = cityView.Text;

                        DatabaseControl.AddHotel(new hotel
                        {
                            title = titleView.Text,
                            hotel_class = Convert.ToInt32(clHotelView.Text),
                            phone_number = phoneNumView.Text,
                            address = addressView.Text,
                            city = cityView.Text,
                        });

                        gridRefFour.grid.ItemsSource = null;
                        gridRefFour.grid.ItemsSource = DatabaseControl.GetHotelsForView();

                        //(this.Parent as vtransport).RefreshTable();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Номер телефона уже используется", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Номер телефона записан неверно. Формат номера телефона 8**********", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Строки не должны быть пустыми", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
