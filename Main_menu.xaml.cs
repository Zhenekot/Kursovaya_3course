using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для Main_menu.xaml
    /// </summary>
    public partial class Main_menu : Window
    {

        public List<position> positions;

        string access;
        public Main_menu(string userSurname, string userPosition)
        {

            InitializeComponent();
            
            surnameUser.Text = userSurname;
            access = userPosition;

            positionUser.Text = userPosition;
            transportationDataGridView.ItemsSource = DatabaseControl.GetTransportationsForView();



            if (access != "Администратор")
            {
                Employee.Visibility = Visibility.Collapsed;
                Position.Visibility = Visibility.Collapsed;
                Statistic.Visibility = Visibility.Collapsed;
                AddTransportation.Visibility = Visibility.Collapsed;
                DataGridBut.Visibility = Visibility.Collapsed;
                MenuER.Visibility = Visibility.Collapsed;
                MenuER2.Visibility = Visibility.Collapsed;
            }

            //(this.Owner as MainWindow).
            //FrameContex.Main_menuFrame = Frame;
        }

        private void Button_AddTransportation(object sender, RoutedEventArgs e)
        {
            AddTransportation addTransportation = new AddTransportation();
            //gridRefEight.grid = transportationDataGridView;
            addTransportation.Owner = this;
            addTransportation.Show();

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            transportation t = transportationDataGridView.SelectedItem as transportation;
            //gridRefEight.grid = transportationDataGridView;
            if (t != null)
            {
                EditTransportation eddTransportation = new EditTransportation(t);
                eddTransportation.Owner = this;
                eddTransportation.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }


        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            transportation t = transportationDataGridView.SelectedItem as transportation;
            if (t != null)
            {
                try
                {
                    DatabaseControl.DelTransportation(t);
                    transportationDataGridView.ItemsSource = null;
                    transportationDataGridView.ItemsSource = DatabaseControl.GetTransportationsForView();
                }
                catch
                {
                    MessageBox.Show("Эта запись не может быть удалена, т.к эта запись используется в продажах");
                }

            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }


        }

        public void RefreshTable()
        {
            transportationDataGridView.ItemsSource = null;
            transportationDataGridView.ItemsSource = DatabaseControl.GetTransportationsForView();
        }

        private void GoOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow autoriz = new MainWindow();
            autoriz.Show();
            this.Close();
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            transportationDataGridView.ItemsSource = DatabaseControl.GetTransportationsForView();
        }

        private void Hotel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vhotel(access);
        }

        private void Position_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vposition();
        }

        private void Transport_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vtransport(access);
        }

        private void Sale_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vsale();
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vemployee();
        }

        private void Transportation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vtransportation(access);
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vclient(access);
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.Content = new vstatistic(access);
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Content = new DatailTour();
            transportation transportation = transportationDataGridView.SelectedItem as transportation;
            if (transportation != null)
            {

                Frame.Navigate(new DatailTour(transportation));
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            //Frame.Content = new DatailTour();


            transportation transportation = transportationDataGridView.SelectedItem as transportation;
            if (transportation != null)
            {

                Frame.Navigate(new DatailTour(transportation));
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RadButNo.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "NO").ToList();
                }
            }
            else if (RadButHb.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "HB").ToList();
                }
            }
            else if (RadButBb.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "BB").ToList();
                }
            }
            else if (RadButAi.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "AI").ToList();
                }
            }
            else
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || (c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower())) || (c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower())) || (c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())))).ToList();
                }
            }

        }





        private void butNo(object sender, RoutedEventArgs e)
        {
            switch (RadButNo.IsChecked)
            {
                case true:
                    RadButHb.IsChecked = false;
                    RadButBb.IsChecked = false;
                    RadButAi.IsChecked = false;

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "NO").ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower()))).ToList();
                    }
                    break;
            }
        }

        private void butHb(object sender, RoutedEventArgs e)
        {
            switch (RadButHb.IsChecked)
            {
                case true:

                    RadButNo.IsChecked = false;
                    RadButBb.IsChecked = false;
                    RadButAi.IsChecked = false;

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "HB").ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower()))).ToList();
                    }
                    break;
            }
        }

        private void butBb(object sender, RoutedEventArgs e)
        {
            switch (RadButBb.IsChecked)
            {
                case true:

                    RadButHb.IsChecked = false;
                    RadButNo.IsChecked = false;
                    RadButAi.IsChecked = false;

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "BB").ToList();
                    }

                    break;
                case false:


                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower()))).ToList();
                    }

                    break;
            }
        }

        private void butAi(object sender, RoutedEventArgs e)
        {

            switch (RadButAi.IsChecked)
            {
                case true:

                    RadButHb.IsChecked = false;
                    RadButBb.IsChecked = false;
                    RadButNo.IsChecked = false;

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower())) && c.type_of_food == "AI").ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        transportationDataGridView.ItemsSource = ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).Where(c => (c.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.city.ToLower().Contains(searchTextBox.Text.ToLower()) || c.TourEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.transportEntity.number.ToLower().Contains(searchTextBox.Text.ToLower()))).ToList();
                    }
                    break;
            }
        }
    }
}
