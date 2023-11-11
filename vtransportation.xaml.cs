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
    /// Логика взаимодействия для vtransportation.xaml
    /// </summary>
    public partial class vtransportation : Page
    {
        public vtransportation(string access)
        {
            InitializeComponent();
            tourDataGridView.ItemsSource = DatabaseControl.GetToursForView();
            if (access != "Администратор")
            {
                addTour.Visibility = Visibility.Collapsed;
                DataGridBut.Visibility = Visibility.Collapsed;
                
                MenuER.Visibility = Visibility.Collapsed;
                
            }
        }

        private void Button_AddTour(object sender, RoutedEventArgs e)
        {
            AddTour addTour = new AddTour();
         
            gridRefSeven.grid = tourDataGridView;
            addTour.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

            tour t = tourDataGridView.SelectedItem as tour;
            gridRefSeven.grid = tourDataGridView;
            if (t != null)
            {
                EditTour eddTour = new EditTour(t);
                
                eddTour.Show();
            }
            else
            {
                MessageBox.Show("Выберите элемент для измения");
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                tour t = tourDataGridView.SelectedItem as tour;
                if (t != null)
                {
                    DatabaseControl.DelTour(t);
                    tourDataGridView.ItemsSource = null;
                    tourDataGridView.ItemsSource = DatabaseControl.GetToursForView();
                }
                else
                {
                    MessageBox.Show("Выберите элемент для удаления");
                }
            }
            catch
            {
                MessageBox.Show("Эта запись не может быть удалена, т.к эта запись используется в продажах");
            }


        }


        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                tourDataGridView.ItemsSource = ctx.tour.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.city.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
        }
    }
}
