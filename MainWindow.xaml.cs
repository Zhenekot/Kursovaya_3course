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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public bool tempAdmin;

        public List<employee> employees;
        public MainWindow()
        {
            InitializeComponent();
            employees = DatabaseControl.GetEmployeesForView();
        }
        private void Main_menu_Click(object sender, RoutedEventArgs e)
        {
                  
           employee user = DatabaseControl.GetUser(login.Text, password.Password);
            if (user != null && user.status != "Уволен")
            {

                Main_menu mainMenu = new Main_menu(user.surname, user.PositionEntity.title);
                this.Close();
                mainMenu.Show();

            }
            else
            {
                MessageBox.Show("Неверно введен логин или пароль", "Error", MessageBoxButton.OK);
            }

        }
    }
}
