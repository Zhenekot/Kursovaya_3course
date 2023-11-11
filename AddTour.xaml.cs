using Microsoft.Win32;
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
    /// Логика взаимодействия для AddTour.xaml
    /// </summary>
    public partial class AddTour : Window
    {

        public AddTour()
        {
            InitializeComponent();

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {


            if ((titleView.Text != "") && (cityView.Text != "") && (description.Text != ""))
            {

                if (description.Text.Length < 501)
                {
                    try
                    {
                    tour _tempTour = new tour();
                    _tempTour.title = titleView.Text;
                    _tempTour.city = cityView.Text;
                    _tempTour.excursion = description.Text;
                    
                    DatabaseControl.AddTour(new tour
                    {
                        title = titleView.Text,
                        city = cityView.Text,
                       
                        excursion = description.Text,
                    
                    });

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
