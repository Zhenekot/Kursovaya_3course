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
using System.Text.RegularExpressions;

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для AddTransportation.xaml
    /// </summary>
    public partial class AddTransportation : Window
    {
        public AddTransportation()
        {
            InitializeComponent();
            transportView.ItemsSource = DatabaseControl.GetTransportsForView();
            tourView.ItemsSource = DatabaseControl.GetToursForView();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Regex regFour = new Regex(@"(19|20)\d\d-((0[1-9]|1[012])-(0[1-9]|[12]\d)|(0[13-9]|1[012])-30|(0[13578]|1[02])-31)\s([0-1]\d|2[0-3])(:[0-5]\d){2}$");

            if ((tourView.Text != "") && (dateStart.Text != "") && (dateEnd.Text != "") && (transportView.Text != "") && (eat.Text != "") && (priceView.Text != ""))
            {
                if (regFour.IsMatch(dateStart.Text) && regFour.IsMatch(dateEnd.Text))
                {
                    try
                    {
                        Convert.ToDouble(priceView.Text);
                        if (DateTime.SpecifyKind(Convert.ToDateTime(dateStart.Text), DateTimeKind.Utc) < DateTime.SpecifyKind(Convert.ToDateTime(dateEnd.Text), DateTimeKind.Utc) && (DateTime.SpecifyKind(Convert.ToDateTime(dateStart.Text), DateTimeKind.Utc) > DateTime.UtcNow) && (DateTime.SpecifyKind(Convert.ToDateTime(dateEnd.Text), DateTimeKind.Utc) > DateTime.UtcNow))
                        {
                            if (Convert.ToDouble(priceView.Text) > 0 && (priceView.Text).Length < 13)
                            {
                                
                                    transportation _tempTransportation = new transportation();
                                    _tempTransportation.title = (tourView.SelectedItem as tour).title;
                                    _tempTransportation.start_date = DateTime.SpecifyKind(Convert.ToDateTime(dateStart.Text), DateTimeKind.Utc);
                                    _tempTransportation.end_date = DateTime.SpecifyKind(Convert.ToDateTime(dateEnd.Text), DateTimeKind.Utc);
                                    _tempTransportation.transport = (transportView.SelectedItem as transport).id_transport;
                                    _tempTransportation.tour = (tourView.SelectedItem as tour).id_tour;
                                    _tempTransportation.type_of_food = eat.Text;
                                    _tempTransportation.cost = Convert.ToDouble(priceView.Text);
                                    DatabaseControl.AddTransportation(new transportation
                                    {
                                        title = (tourView.SelectedItem as tour).title,    
                                        start_date = DateTime.SpecifyKind(Convert.ToDateTime(dateStart.Text), DateTimeKind.Utc),
                                        end_date = DateTime.SpecifyKind(Convert.ToDateTime(dateEnd.Text), DateTimeKind.Utc),
                                        transport = (transportView.SelectedItem as transport).id_transport,
                                        tour = (tourView.SelectedItem as tour).id_tour,
                                        type_of_food = eat.Text,
                                        cost = Convert.ToDouble(priceView.Text),
                                    });

                                //gridRefEight.grid.ItemsSource = null;
                                //gridRefEight.grid.ItemsSource = DatabaseControl.GetTransportationsForView();
                                (this.Owner as Main_menu).RefreshTable();

                                this.Close();
                               

                            }
                            else
                            {
                                MessageBox.Show("Цена введена неверно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Даты введены неверно!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Цена введена неверно!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Дата записана неверно. Формат даты гггг-мм-дд чч-мм-сс", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
