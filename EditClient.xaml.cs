using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static TourAgentCreatour.client;
using TourAgentCreatour;

namespace TourAgentCreatour
{
    /// <summary>
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        client _tempClient = new client();
        public EditClient(client client)
        {
            InitializeComponent();
            _tempClient = client;
            nameView.Text = client.name;
            surnameView.Text = client.surname;
            patronymicView.Text = client.patronymic;
            phone_numberView.Text = client.phone_number;
            emailView.Text = client.email;
            date_birthView.Text = client.date_of_birth.ToString();
            sernumView.Text = client.passport_series_and_number;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            Regex regOne = new Regex(@"^[А-Я][а-я]{1,20}$");
            Regex regTwo = new Regex(@"8\d{10}");
            Regex regThree = new Regex(@"[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+");
            Regex regFour = new Regex(@"(19|20)\d\d-((0[1-9]|1[012])-(0[1-9]|[12]\d)|(0[13-9]|1[012])-30|(0[13578]|1[02])-31)");
            Regex regFive = new Regex(@"\d{10}");

            if ((nameView.Text != "") && (surnameView.Text != "") && (phone_numberView.Text != "") && (emailView.Text != "") && (date_birthView.Text != "") && (sernumView.Text != ""))
            {
                if ((regOne.IsMatch(nameView.Text)) && (regOne.IsMatch(surnameView.Text)))
                {
                    if ((regTwo.IsMatch(phone_numberView.Text)) && (phone_numberView.Text.Length == 11))
                    {
                        if (regThree.IsMatch(emailView.Text))
                        {
                            if (regFour.IsMatch(date_birthView.Text))
                            {
                                if ((regFive.IsMatch(sernumView.Text)) && (sernumView.Text.Length == 10))

                                {
                                    try
                                    {


                                        if (patronymicView.Text != "")
                                        {
                                            if (regOne.IsMatch(patronymicView.Text))
                                            {

                                                _tempClient.name = nameView.Text;
                                                _tempClient.surname = surnameView.Text;
                                                _tempClient.patronymic = patronymicView.Text;
                                                _tempClient.phone_number = phone_numberView.Text;
                                                _tempClient.email = emailView.Text;
                                                _tempClient.date_of_birth = DateTime.SpecifyKind(Convert.ToDateTime(date_birthView.Text), DateTimeKind.Utc);
                                                _tempClient.passport_series_and_number = sernumView.Text;

                                                DatabaseControl.UpdateClient(_tempClient);

                                                gridRefThree.grid.ItemsSource = null;
                                                gridRefThree.grid.ItemsSource = DatabaseControl.GetClientsForView();

                                                //(this.Parent as vtransport).RefreshTable();
                                                this.Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("В имени/фамилии/отчестве должны быть только буквы", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                            }
                                        }
                                        else
                                        {

                                            _tempClient.name = nameView.Text;
                                            _tempClient.surname = surnameView.Text;
                                            _tempClient.patronymic = "";
                                            _tempClient.phone_number = phone_numberView.Text;
                                            _tempClient.email = emailView.Text;
                                            _tempClient.date_of_birth = DateTime.SpecifyKind(Convert.ToDateTime(date_birthView.Text), DateTimeKind.Utc);
                                            _tempClient.passport_series_and_number = sernumView.Text;
                                            DatabaseControl.UpdateClient(_tempClient);

                                            gridRefThree.grid.ItemsSource = null;
                                            gridRefThree.grid.ItemsSource = DatabaseControl.GetClientsForView();

                                            //(this.Parent as vtransport).RefreshTable();
                                            this.Close();

                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Номер телефона/почта/серия и номер паспорта уже используются", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Серия и номер паспорта записаны неверно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Дата записана неверно. Формат даты гггг-мм-дд", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Почта записана неверно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
