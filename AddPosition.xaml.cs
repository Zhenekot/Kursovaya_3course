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

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Window
    {
        public AddPosition()
        {
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            if ((titleView.Text != "") && (salaryView.Text != ""))
            {
                try
                {
                    Convert.ToDouble(salaryView.Text);
                    if(Convert.ToDouble(salaryView.Text) > 0)
                    {
                        position _position = new position();
                        _position.title = titleView.Text;
                        _position.salary = Convert.ToDouble(salaryView.Text);
                        
                        DatabaseControl.AddPosition(new position
                        {
                            title = titleView.Text,
                            salary = Convert.ToDouble(salaryView.Text),
                            
                        });

                        gridRefTwo.grid.ItemsSource = null;
                        gridRefTwo.grid.ItemsSource = DatabaseControl.GetPositionsForView();

                        //(this.Parent as vtransport).RefreshTable();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Зарплата записана неверно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Зарплата записана неверно!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Строки не должны быть пустыми", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
