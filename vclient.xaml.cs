using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для vclient.xaml
    /// </summary>
    public partial class vclient : Page
    {
        public vclient(string access)
        {
            InitializeComponent();
            clientDataGridView.ItemsSource = DatabaseControl.GetClientsForView();
           
        }

        private void Button_AddClient(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            gridRefThree.grid = clientDataGridView;
            addClient.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
           
            client c = clientDataGridView.SelectedItem as client;
            gridRefThree.grid = clientDataGridView;
            if (c != null)
            {
                EditClient eddClient = new EditClient(c);
                eddClient.Show();
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
                client c = clientDataGridView.SelectedItem as client;
                if (c != null)
                {
                    DatabaseControl.DelClient(c);
                    clientDataGridView.ItemsSource = null;
                    clientDataGridView.ItemsSource = DatabaseControl.GetClientsForView();
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
                clientDataGridView.ItemsSource = ctx.client.Where(c => c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
        }
    }
}
