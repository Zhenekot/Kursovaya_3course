using Microsoft.EntityFrameworkCore;
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
using static TourAgentCreatour.client;
using static TourAgentCreatour.hotel;

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для vhotel.xaml
    /// </summary>
    public partial class vhotel : Page
    {
        public vhotel(string access)
        {
            InitializeComponent();
            hotelDataGridView.ItemsSource = DatabaseControl.GetHotelsForView();
            gridRefFour.grid = hotelDataGridView;
            if (access != "Администратор")
            {

                addHotel.Visibility = Visibility.Collapsed;
                DataGridBut.Visibility = Visibility.Collapsed;
                MenuER.Visibility = Visibility.Collapsed;

            }


        }

        private void Button_AddHotel(object sender, RoutedEventArgs e)
        {
            AddHotel addHotel = new AddHotel();
            addHotel.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

            hotel h = hotelDataGridView.SelectedItem as hotel;
            gridRefFour.grid = hotelDataGridView;
            if (h != null)
            {
                EditHotel eddHotel = new EditHotel(h);
                eddHotel.Show();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }

        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hotel h = hotelDataGridView.SelectedItem as hotel;
                gridRefFour.grid = hotelDataGridView;
                if (h != null)
                {
                    DatabaseControl.DelHotel(h);
                    hotelDataGridView.ItemsSource = null;
                    hotelDataGridView.ItemsSource = DatabaseControl.GetHotelsForView();
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
            

            if (CheckBut1.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 1).ToList();
                }
            }
            else if (CheckBut2.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 2).ToList();
                }
            }
            else if (CheckBut3.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 3).ToList();
                }
            }
            else if (CheckBut4.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 4).ToList();
                }
            }
            else if (CheckBut5.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 5).ToList();
                }
            }
            else
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
            }
        }

        private void CheckBut1_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckBut1.IsChecked)
            {
                case true:

                    CheckBut2.IsChecked = false;
                    CheckBut3.IsChecked = false;
                    CheckBut4.IsChecked = false;
                    CheckBut5.IsChecked = false;


                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 1).ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                    break;
            }
        }

        private void CheckBut2_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckBut2.IsChecked)
            {
                case true:

                    CheckBut1.IsChecked = false;
                    CheckBut3.IsChecked = false;
                    CheckBut4.IsChecked = false;
                    CheckBut5.IsChecked = false;


                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 2).ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                    break;
            }
        }

        private void CheckBut3_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckBut3.IsChecked)
            {
                case true:

                    CheckBut2.IsChecked = false;
                    CheckBut1.IsChecked = false;
                    CheckBut4.IsChecked = false;
                    CheckBut5.IsChecked = false;


                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 3).ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                    break;
            }
        }

        private void CheckBut4_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckBut4.IsChecked)
            {
                case true:

                    CheckBut2.IsChecked = false;
                    CheckBut3.IsChecked = false;
                    CheckBut1.IsChecked = false;
                    CheckBut5.IsChecked = false;


                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 4).ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                    break;
            }
        }

        private void CheckBut5_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckBut5.IsChecked)
            {
                case true:

                    CheckBut2.IsChecked = false;
                    CheckBut3.IsChecked = false;
                    CheckBut4.IsChecked = false;
                    CheckBut1.IsChecked = false;


                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && c.hotel_class == 5).ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        hotelDataGridView.ItemsSource = ctx.hotel.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                    break;
            }
        }
    }
}
