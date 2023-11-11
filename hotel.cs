using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace TourAgentCreatour
{
    public class hotel
    {
        [Key] public int id_hotel { get; set; }
        public string title { get; set; }
        public int hotel_class { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public List<sale> SaleEntity { get; set; }

        static public class gridRefFour
        {
            static public DataGrid grid { get; set; }
        }
    }
}
