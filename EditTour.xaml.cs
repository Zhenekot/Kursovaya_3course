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
    /// Логика взаимодействия для EditTour.xaml
    /// </summary>
    public partial class EditTour : Window
    {
        tour _tempTour = new tour();
        public EditTour(tour tour)
        {
            InitializeComponent();
            _tempTour = tour;


            titleView.Text = tour.title;
            cityView.Text = tour.city;
            description.Text = tour.excursion;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {


            if ((titleView.Text != "") && (cityView.Text != "") && (description.Text != ""))
            {

                if (description.Text.Length < 501)
                {
                    try
                    {
                    _tempTour.title = titleView.Text;
                    _tempTour.city = cityView.Text;
                  
                    _tempTour.excursion = description.Text;
                    
                    DatabaseControl.UpdateTour(_tempTour);

                    gridRefSeven.grid.ItemsSource = null;
                    gridRefSeven.grid.ItemsSource = DatabaseControl.GetToursForView();

                    //(this.Owner as Main_menu).RefreshTable();
                    //(this.Parent as vtransport).RefreshTable();
                    this.Close();

                    } catch {
                        MessageBox.Show("Название слишком длинное", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Описание слишком длинное", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
