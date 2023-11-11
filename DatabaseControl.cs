using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace TourAgentCreatour
{
    internal class DatabaseControl
    {
        //public static List<tour> GetToursDate()
        //{
        //    using (DbAppContext ctx = new DbAppContext())
        //    {
        //        return ctx.tour.Include(p => p.transportEntity).Where(t => (t.start_date > DateTime.UtcNow) && (t.end_date > DateTime.UtcNow)).ToList();
        //    }
        //}

        public static List<sale> GetSalesNoRejectForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.rejection == "Продано").ToList();
            }
        }

        public static List<sale> GetSalesRejectForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).Where(t => t.rejection == "Отказ").ToList();
            }
        }

        public static List<employee> GetWorkEmployee()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.employee.Include(p => p.PositionEntity).Where(t => t.status == "Работает").ToList();
            }
        }

        public static employee GetUser(string login, string password)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.employee.Where(p => p.login == login && p.password == password).Include(p => p.PositionEntity).FirstOrDefault();
            }
                
        }
        public static List<tour> GetToursForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.tour.ToList();
            }
        }

        public static List<employee> GetEmployeesForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.employee.Include(p => p.PositionEntity).ToList();
            }
        }

        public static List<sale> GetSalesForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.sale.Include(p => p.ClientEntity).Include(p => p.TransportationEntity).Include(p => p.HotelEntity).Include(p => p.EmployeeEntity).ToList();
            }
        }



        public static List<transport> GetTransportsForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.transport.ToList();
            }
        }

        public static List<hotel> GetHotelsForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.hotel.ToList();
            }
        }

        public static List<position> GetPositionsForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.position.ToList();
            }
        }

        public static List<client> GetClientsForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.client.ToList();
            }
        }

        public static List<transportation> GetTransportationsForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.transportation.Include(p => p.transportEntity).Include(p => p.TourEntity).ToList();
            }
        }

        //Транспорт
        public static void AddTransport(transport transport)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.transport.Add(transport);
                ctx.SaveChanges();
            }
        }

        public static void DelTransport(transport transport)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.transport.Remove(transport);
                ctx.SaveChanges();
            }
        }

        public static void UpdateTransport(transport transport)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                transport _transport = ctx.transport.FirstOrDefault(p => p.id_transport == transport.id_transport);
                if (_transport == null)
                {
                    return;
                }
                _transport.title = transport.title;
                _transport.number = transport.number;
                _transport.count_seat = transport.count_seat;
                ctx.SaveChanges();
            }
        }

        //Position

        public static void DelPosition(position position)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.position.Remove(position);
                ctx.SaveChanges();
            }
        }

        public static void AddPosition(position position)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.position.Add(position);
                ctx.SaveChanges();
            }
        }

        public static void UpdatePosition(position position)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                position _position = ctx.position.FirstOrDefault(p => p.id_position == position.id_position);
                if (_position == null)
                {
                    return;
                }
                _position.title = position.title;
                _position.salary = position.salary;
                ctx.SaveChanges();
            }
        }

        //client 

        public static void DelClient(client client)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.client.Remove(client);
                ctx.SaveChanges();
            }
        }

        public static void AddClient(client client)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.client.Add(client);
                ctx.SaveChanges();
            }
        }

        public static void UpdateClient(client client)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                client _client = ctx.client.FirstOrDefault(p => p.id_client == client.id_client);
                if (_client == null)
                {
                    return;
                }
                _client.name = client.name;
                _client.surname = client.surname;
                _client.patronymic = client.patronymic;
                _client.phone_number = client.phone_number;
                _client.email = client.email;
                _client.date_of_birth = client.date_of_birth;
                _client.passport_series_and_number = client.passport_series_and_number;

                ctx.SaveChanges();
            }
        }

        //hotel

        public static void DelHotel(hotel hotel)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.hotel.Remove(hotel);
                ctx.SaveChanges();
            }
        }

        public static void AddHotel(hotel hotel)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.hotel.Add(hotel);
                ctx.SaveChanges();
            }
        }

        public static void UpdateHotel(hotel hotel)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                hotel _hotel = ctx.hotel.FirstOrDefault(p => p.id_hotel == hotel.id_hotel);
                if (_hotel == null)
                {
                    return;
                }
                _hotel.title = hotel.title;
                _hotel.hotel_class = hotel.hotel_class;
                _hotel.city = hotel.city;
                _hotel.address = hotel.address;
                _hotel.phone_number = hotel.phone_number;
             
                ctx.SaveChanges();
            }
        }

        //sale

        public static void DelSale(sale sale)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.sale.Remove(sale);
                ctx.SaveChanges();
            }
        }

        public static void AddSale(sale sale)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.sale.Add(sale);
                ctx.SaveChanges();
            }
        }

        public static void UpdateSale(sale sale)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                sale _sale = ctx.sale.FirstOrDefault(p => p.id_sale == sale.id_sale);
                if (_sale == null)
                {
                    return;
                }
                _sale.full_cost = sale.full_cost;
                _sale.date_of_sale = sale.date_of_sale;
                _sale.rejection = sale.rejection;
                _sale.client = sale.client;
                _sale.hotel = sale.hotel;
                _sale.transportation = sale.transportation;
                _sale.employee = sale.employee;

                ctx.SaveChanges();
            }
        }


        //employee

        public static void DelEmployee(employee employee)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.employee.Remove(employee);
                ctx.SaveChanges();
            }
        }

        public static void AddEmployee(employee employee)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.employee.Add(employee);
                ctx.SaveChanges();
            }
        }

        public static void UpdateEmployee(employee employee)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                employee _employee = ctx.employee.FirstOrDefault(p => p.id_employee == employee.id_employee);
                if (_employee == null)
                {
                    return;
                }
                _employee.name = employee.name;
                _employee.surname = employee.surname;
                _employee.patronymic = employee.patronymic;
                _employee.phone_number = employee.phone_number;
                _employee.date_of_birth = employee.date_of_birth;
                _employee.position = employee.position;
                _employee.password = employee.password;
                _employee.status = employee.status;
                _employee.login = employee.login;
                ctx.SaveChanges();
            }
        }

        //tour

        public static void DelTour(tour tour)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.tour.Remove(tour);
                ctx.SaveChanges();
            }
        }

        public static void AddTour(tour tour)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.tour.Add(tour);
                ctx.SaveChanges();
            }
        }

        public static void UpdateTour(tour tour)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                tour _tour = ctx.tour.FirstOrDefault(p => p.id_tour == tour.id_tour);
                if (_tour == null)
                {
                    return;
                }
                _tour.title = tour.title;
                _tour.city = tour.city;
                
                _tour.excursion = tour.excursion;
                
                //_tour.picture = tour.picture;
                

                ctx.SaveChanges();
            }
        }

        //transportation

        public static void DelTransportation(transportation transportation)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.transportation.Remove(transportation);
                ctx.SaveChanges();
            }
        }

        public static void AddTransportation(transportation transportation)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.transportation.Add(transportation);
                ctx.SaveChanges();
            }
        }

        public static void UpdateTransportation(transportation transportation)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                transportation _transportation = ctx.transportation.FirstOrDefault(p => p.id_transportation == transportation.id_transportation);
                if (_transportation == null)
                {
                    return;
                }
                _transportation.title = transportation.title;
                _transportation.tour = transportation.tour;
                _transportation.start_date = transportation.start_date;
                _transportation.end_date = transportation.end_date;
                _transportation.transport = transportation.transport;
                _transportation.type_of_food = transportation.type_of_food;
                _transportation.cost = transportation.cost;
                ctx.SaveChanges();
            }
        }
    }
}
