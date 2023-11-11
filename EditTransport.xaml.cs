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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для EditTransport.xaml
    /// </summary>
    public partial class EditTransport : Window
    {
        transport _tempTransport = new transport();
        public EditTransport(transport transport)
        {
            InitializeComponent();
            _tempTransport = transport;
            titleView.Text = transport.title;
            numberView.Text = transport.number;
            countSeatView.Text = transport.count_seat.ToString();
        }

        private void Button_ok(object sender, RoutedEventArgs e)
        {

            Regex regex = new Regex(@"\d{3}[АВЕКМНОРСТУХ]{2}");
            if ((titleView.Text != "") && (numberView.Text != "") && (countSeatView.Text != ""))
            {
                try
                {
                    Convert.ToInt32(countSeatView.Text);
                    if ((Convert.ToInt32(countSeatView.Text) > 0) && (Convert.ToInt32(countSeatView.Text) < 100))
                    {
                        if (regex.IsMatch(numberView.Text) && (numberView.Text.Length == 5))
                        {
                            try
                            {
                            _tempTransport.title = titleView.Text;
                            _tempTransport.number = numberView.Text;
                            _tempTransport.count_seat = Convert.ToInt32(countSeatView.Text);
                            DatabaseControl.UpdateTransport(_tempTransport);

                            gridRef.grid.ItemsSource = null;
                            gridRef.grid.ItemsSource = DatabaseControl.GetTransportsForView();

                            //(this.Parent as vtransport).RefreshTable();
                            this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Государственный номер транспорта уже используется", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Государственный номер транспорта записан неправильно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Число мест в транспорте записано неправильно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Число мест в транспорте записано неправильно1", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Строки не должны быть пустыми", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
