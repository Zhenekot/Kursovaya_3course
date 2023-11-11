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
    /// Логика взаимодействия для vemployee.xaml
    /// </summary>
    public partial class vemployee : Page
    {
        public vemployee()
        {
            InitializeComponent();
            employeeDataGridView.ItemsSource = DatabaseControl.GetEmployeesForView();
        }

        private void Button_AddEmployee(object sender, RoutedEventArgs e)
        {
            gridRefSix.grid = employeeDataGridView;
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
            
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            
            gridRefSix.grid = employeeDataGridView;

            employee em = employeeDataGridView.SelectedItem as employee;
           
            if (em != null)
            {
                EditEmployee eddEmployee = new EditEmployee(em);
                eddEmployee.Show();
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
                employee em = employeeDataGridView.SelectedItem as employee;
                gridRefSix.grid = employeeDataGridView;
                if (em != null)
                {
                    if(em.PositionEntity.title != "Администратор")
                    {
                        DatabaseControl.DelEmployee(em);
                        employeeDataGridView.ItemsSource = null;
                        employeeDataGridView.ItemsSource = DatabaseControl.GetEmployeesForView();
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
                MessageBox.Show("Эта запись не может быть удалена, т.к эта запись используется в продажах");
            }
            
        }
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dismissedNo.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => (c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower())) && c.status == "Работает").ToList();
                }
            }
            else if (dismissed.IsChecked == true)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => (c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower())) && c.status == "Уволен").ToList();
                }
            }
            else
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
            }
            
        }

        private void dismissedNo_Click(object sender, RoutedEventArgs e)
        {
            switch (dismissedNo.IsChecked)
            {
                case true:
                    dismissed.IsChecked = false;

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => (c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower())) && c.status == "Работает").ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => (c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()))).ToList();
                    }
                    break;
            }
        }

        private void dismissed_Click(object sender, RoutedEventArgs e)
        {
            switch (dismissed.IsChecked)
            {
                case true:
                    dismissedNo.IsChecked = false;

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => (c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower())) && c.status == "Уволен").ToList();
                    }

                    break;
                case false:

                    using (DbAppContext ctx = new DbAppContext())
                    {
                        employeeDataGridView.ItemsSource = ctx.employee.Include(p => p.PositionEntity).Where(c => (c.name.ToLower().Contains(searchTextBox.Text.ToLower()) || c.surname.ToLower().Contains(searchTextBox.Text.ToLower()) || c.patronymic.ToLower().Contains(searchTextBox.Text.ToLower()) || c.PositionEntity.title.ToLower().Contains(searchTextBox.Text.ToLower()))).ToList();
                    }
                    break;
            }
        }
    }
}
