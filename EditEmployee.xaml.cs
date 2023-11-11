using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static TourAgentCreatour.client;

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        employee _tempEmployee = new employee();
        public EditEmployee(employee employee)
        {
            InitializeComponent();
            positionView.ItemsSource = DatabaseControl.GetPositionsForView();

            _tempEmployee = employee;
            nameView.Text = employee.name;
            surnameView.Text = employee.surname;
            patronymicView.Text = employee.patronymic;
            phone_numberView.Text = employee.phone_number;
            positionView.SelectedValue = employee.PositionEntity.id_position;
            date_birthView.Text = employee.date_of_birth.ToString();
            passwordView.Text = employee.password;
            statusView.Text = employee.status;
            loginView.Text = employee.login;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            Regex regOne = new Regex(@"^[А-Я][а-я]{1,20}$");
            Regex regTwo = new Regex(@"8\d{10}");
            Regex regFour = new Regex(@"(19|20)\d\d-((0[1-9]|1[012])-(0[1-9]|[12]\d)|(0[13-9]|1[012])-30|(0[13578]|1[02])-31)");
            Regex regPass = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");

            if ((nameView.Text != "") && (surnameView.Text != "") && (phone_numberView.Text != "") && (date_birthView.Text != "") && (passwordView.Text != "") && (positionView.Text != ""))
            {
                if ((regOne.IsMatch(nameView.Text)) && (regOne.IsMatch(surnameView.Text)))
                {
                    if ((regTwo.IsMatch(phone_numberView.Text)) && (phone_numberView.Text.Length == 11))
                    {
                        if (regFour.IsMatch(date_birthView.Text))
                        {
                            if (regPass.IsMatch(passwordView.Text))
                            {
                                if (patronymicView.Text != "")
                                {
                                    if (regOne.IsMatch(patronymicView.Text))
                                    {
                                        try
                                        {

                                            _tempEmployee.name = nameView.Text;
                                            _tempEmployee.surname = surnameView.Text;
                                            _tempEmployee.patronymic = patronymicView.Text;
                                            _tempEmployee.phone_number = phone_numberView.Text;
                                            _tempEmployee.position = (positionView.SelectedItem as position).id_position;
                                            _tempEmployee.date_of_birth = DateTime.SpecifyKind(Convert.ToDateTime(date_birthView.Text), DateTimeKind.Utc);
                                            _tempEmployee.password = passwordView.Text;
                                            _tempEmployee.status = statusView.Text;
                                            _tempEmployee.login = loginView.Text;
                                            DatabaseControl.UpdateEmployee(_tempEmployee);

                                            gridRefSix.grid.ItemsSource = null;
                                            gridRefSix.grid.ItemsSource = DatabaseControl.GetEmployeesForView();

                                            //(this.Parent as vtransport).RefreshTable();
                                            this.Close();
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Номер телефона/логин уже используется", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("В имени/фамилии/отчестве должны быть только буквы", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        _tempEmployee.name = nameView.Text;
                                        _tempEmployee.surname = surnameView.Text;
                                        _tempEmployee.patronymic = " ";
                                        _tempEmployee.phone_number = phone_numberView.Text;
                                        _tempEmployee.position = (positionView.SelectedItem as position).id_position;
                                        _tempEmployee.date_of_birth = DateTime.SpecifyKind(Convert.ToDateTime(date_birthView.Text), DateTimeKind.Utc);
                                        _tempEmployee.password = passwordView.Text;
                                        _tempEmployee.status = statusView.Text;
                                        _tempEmployee.login = loginView.Text;
                                        DatabaseControl.UpdateEmployee(_tempEmployee);

                                        gridRefSix.grid.ItemsSource = null;
                                        gridRefSix.grid.ItemsSource = DatabaseControl.GetEmployeesForView();

                                        //(this.Parent as vtransport).RefreshTable();
                                        this.Close();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Номер телефона/логин уже используется", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пароль должен содержать строчные и прописные латинские буквы, цифры, спецсимволы. Минимум 8 символов", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Дата записана неверно. Формат даты гггг-мм-дд", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона записан неверно. Формат номера телефона 8**********", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("В имени/фамилии/отчестве должны быть только буквы", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Строки не должны быть пустыми", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
