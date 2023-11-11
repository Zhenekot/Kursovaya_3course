using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для AddTransport.xaml
    /// </summary>
    public partial class AddTransport : Window
    {

        public AddTransport()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
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
                                transport _tempTransport = new transport();
                                _tempTransport.title = titleView.Text;
                                _tempTransport.number = numberView.Text;
                                _tempTransport.count_seat = Convert.ToInt32(countSeatView.Text);
                                DatabaseControl.AddTransport(new transport
                                {
                                    title = titleView.Text,
                                    number = numberView.Text,
                                    count_seat = Convert.ToInt32(countSeatView.Text),
                                });

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
                    MessageBox.Show("Число мест в транспорте записано неправильно!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
