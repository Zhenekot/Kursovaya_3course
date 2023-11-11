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
    /// Логика взаимодействия для vtransport.xaml
    /// </summary>
    public partial class vtransport : Page
    {
        public vtransport(string access)
        {
            InitializeComponent();
            transportDataGridView.ItemsSource = DatabaseControl.GetTransportsForView();
            if (access != "Администратор")
            {

                AddTransport.Visibility = Visibility.Collapsed;
                DataGridBut.Visibility = Visibility.Collapsed;
                MenuER.Visibility = Visibility.Collapsed;
                
            }

        }

        private void Button_AddTransport(object sender, RoutedEventArgs e)
        {
            AddTransport addTransport = new AddTransport();
            gridRef.grid = transportDataGridView;
            addTransport.Show();
            //RefreshTable();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            transport t = transportDataGridView.SelectedItem as transport;
            gridRef.grid = transportDataGridView;
            if (t != null)
            {
                EditTransport eddTransport = new EditTransport(t);
                eddTransport.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }


        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            transport t = transportDataGridView.SelectedItem as transport;
            if (t != null)
            {
                try
                {
                    DatabaseControl.DelTransport(t);
                    transportDataGridView.ItemsSource = null;
                    transportDataGridView.ItemsSource = DatabaseControl.GetTransportsForView();
                }
                catch
                {
                    MessageBox.Show("Эта запись не может быть удалена, т.к эта запись используется в турах");
                }
                
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }

           
        }

        public void RefreshTable()
        {
            transportDataGridView.ItemsSource = null;
            transportDataGridView.ItemsSource = DatabaseControl.GetTransportsForView();
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                transportDataGridView.ItemsSource = ctx.transport.Where(c => c.number.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
        }
    }
}
