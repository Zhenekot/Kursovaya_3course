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
    /// Логика взаимодействия для EditPosition.xaml
    /// </summary>
    public partial class EditPosition : Window
    {
        position _tempPosition = new position();
        public EditPosition(position position)
        {
            InitializeComponent();
            _tempPosition = position;
            titleView.Text = position.title;
            salaryView.Text = position.salary.ToString();
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
                    if (Convert.ToDouble(salaryView.Text) > 0)
                    {

                        _tempPosition.title = titleView.Text;
                        _tempPosition.salary = Convert.ToDouble(salaryView.Text);

                        DatabaseControl.UpdatePosition(_tempPosition);

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
