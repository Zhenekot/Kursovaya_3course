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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для vsale.xaml
    /// </summary>
    public partial class vsale : Page
    {
        public vsale()
        {
            InitializeComponent();
            saleDataGridView.ItemsSource = DatabaseControl.GetSalesForView();
            startPrice.Text = "0";
            endPrice.Text = "999999999";
            startDate.Text = "2000-01-01";
            endDate.Text = "2100-01-01";
        }

        private void Button_AddSale(object sender, RoutedEventArgs e)
        {
            AddSale addSale = new AddSale();
            gridRefFive.grid = saleDataGridView;
            addSale.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

            sale s = saleDataGridView.SelectedItem as sale;
            gridRefFive.grid = saleDataGridView;
            if (s != null)
            {
                EditSale eddSale = new EditSale(s);
                eddSale.Show();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }


        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            sale s = saleDataGridView.SelectedItem as sale;
            gridRefFive.grid = saleDataGridView;
            if (s != null)
            {
                DatabaseControl.DelSale(s);
                saleDataGridView.ItemsSource = null;
                saleDataGridView.ItemsSource = DatabaseControl.GetSalesForView();
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            sale sale = saleDataGridView.SelectedItem as sale;
            if (sale != null)
            {
                DatailSale detailSale = new DatailSale(sale);
                detailSale.Show();
            }
            else
            {
                MessageBox.Show("Выберите элемент для просмотра подробной информации");
            }

        }

        private void DataGridRow_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            sale sale = saleDataGridView.SelectedItem as sale;
            if (sale != null)
            {
                DatailSale detailSale = new DatailSale(sale);
                detailSale.Show();
            }
            else
            {
                MessageBox.Show("Выберите элемент для просмотра подробной информации");
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkDatePrice();
        }

        private void startPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkDatePrice();

        }

        private void endPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkDatePrice();
        }

        private void startDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkDatePrice();
        }

        private void endDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkDatePrice();
        }
        private void stringText()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                saleDataGridView.ItemsSource = ctx.sale.Include(p => p.TransportationEntity).Include(p => p.ClientEntity).Include(p => p.EmployeeEntity).Include(p => p.HotelEntity).Where(c => c.TransportationEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) ||
                c.HotelEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())
                || c.EmployeeEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.EmployeeEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
        }

        private void checkDatePrice()
        {
            if (startPrice.Text == string.Empty)
            {
                startPrice.Text = "0";
            }
            if (endPrice.Text == string.Empty)
            {
                endPrice.Text = "999999999";
            }
            if (startDate.Text == string.Empty)
            {
                startDate.Text = "2000-01-01";
            }
            if (endDate.Text == string.Empty)
            {
                endDate.Text = "2100-01-01";
            }

            try
            {
                if (Convert.ToInt32(startPrice.Text) < Convert.ToInt32(endPrice.Text) && Convert.ToDateTime(startDate.Text) < Convert.ToDateTime(endDate.Text))
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        saleDataGridView.ItemsSource = ctx.sale.Include(p => p.TransportationEntity).Include(p => p.ClientEntity).Include(p => p.EmployeeEntity).Include(p => p.HotelEntity).Where(c => (c.TransportationEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) ||
                        c.HotelEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())
                        || c.EmployeeEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.EmployeeEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())) && ((Convert.ToInt32(startPrice.Text) < c.TransportationEntity.cost) && (Convert.ToInt32(endPrice.Text) > c.TransportationEntity.cost)) && ((Convert.ToDateTime(startDate.Text) < c.date_of_sale) && (Convert.ToDateTime(endDate.Text) > c.date_of_sale))).ToList();
                    }
                }
                else if (Convert.ToInt32(startPrice.Text) < Convert.ToInt32(endPrice.Text))
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        saleDataGridView.ItemsSource = ctx.sale.Include(p => p.TransportationEntity).Include(p => p.ClientEntity).Include(p => p.EmployeeEntity).Include(p => p.HotelEntity).Where(c => (c.TransportationEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) ||
                        c.HotelEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())
                        || c.EmployeeEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.EmployeeEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())) && ((Convert.ToInt32(startPrice.Text) < c.TransportationEntity.cost) && (Convert.ToInt32(endPrice.Text) > c.TransportationEntity.cost))).ToList();
                    }
                }
                else if (Convert.ToDateTime(startDate.Text) < Convert.ToDateTime(endDate.Text))
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        saleDataGridView.ItemsSource = ctx.sale.Include(p => p.TransportationEntity).Include(p => p.ClientEntity).Include(p => p.EmployeeEntity).Include(p => p.HotelEntity).Where(c => (c.TransportationEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) ||
                        c.HotelEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())
                        || c.EmployeeEntity.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.EmployeeEntity.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.ClientEntity.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())) && ((Convert.ToDateTime(startDate.Text) < c.date_of_sale) && (Convert.ToDateTime(endDate.Text) > c.date_of_sale))).ToList();
                    }
                }
                else
                {
                    stringText();
                }

            }
            catch
            {
                stringText();
            }
        }
    }
}
