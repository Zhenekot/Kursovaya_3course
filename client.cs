using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace TourAgentCreatour
{
    public class client
    {
        [Key] public int id_client { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public DateTime date_of_birth { get; set; }
        public string passport_series_and_number { get; set; }

        public List<sale> SaleEntity { get; set; }

        static public class gridRefThree
        {
            static public DataGrid grid { get; set; }
        }
    }
}
