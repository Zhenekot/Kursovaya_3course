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
    /// Логика взаимодействия для vposition.xaml
    /// </summary>
    public partial class vposition : Page
    {
        public vposition()
        {
            InitializeComponent();
            positionDataGridView.ItemsSource = DatabaseControl.GetPositionsForView();
            startPrice.Text = "0";
            endPrice.Text = "999999999";
            
        }


        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            gridRefTwo.grid = positionDataGridView;
            addPosition.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            position p = positionDataGridView.SelectedItem as position;
            gridRefTwo.grid = positionDataGridView;
            if (p != null)
            {
                EditPosition eddPosition = new EditPosition(p);
                eddPosition.Show();
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
                position p = positionDataGridView.SelectedItem as position;
                if (p != null)
                {
                    if (p.title != "Администратор")
                    {
                        DatabaseControl.DelPosition(p);
                        positionDataGridView.ItemsSource = null;
                        positionDataGridView.ItemsSource = DatabaseControl.GetPositionsForView();
                    }
                    else
                    {
                        MessageBox.Show("Нельзя удалить администратора");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Выберите элемент для удаления");
                }
            }
            catch
            {
                MessageBox.Show("Эта запись не может быть удалена, т.к эта запись используется в сотрудниках");
            }
            

        }


        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(startPrice.Text) < Convert.ToInt32(endPrice.Text))
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && (Convert.ToInt32(startPrice.Text) < c.salary) && (Convert.ToInt32(endPrice.Text) > c.salary)).ToList();
                    }
                }
                else
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                }
               
            }
            catch
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
            }

        }

        private void startPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(startPrice.Text) < Convert.ToInt32(endPrice.Text))
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && (Convert.ToInt32(startPrice.Text) < c.salary) && (Convert.ToInt32(endPrice.Text) > c.salary)).ToList();
                    }
                }
                else
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                }

            }
            catch
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
            }

        }

        private void endPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(startPrice.Text) < Convert.ToInt32(endPrice.Text))
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower()) && (Convert.ToInt32(startPrice.Text) < c.salary) && (Convert.ToInt32(endPrice.Text) > c.salary)).ToList();
                    }
                }
                else
                {
                    using (DbAppContext ctx = new DbAppContext())
                    {
                        positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    }
                }

            }
            catch
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    positionDataGridView.ItemsSource = ctx.position.Where(c => c.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
            }

        }
    }
}
