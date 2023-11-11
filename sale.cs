using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace TourAgentCreatour
{
    public class sale
    {
        [Key] public int id_sale { get; set; }
        public decimal full_cost { get; set; }
        public DateTime date_of_sale { get; set; }
        public string rejection { get; set; }
        [ForeignKey("ClientEntity")] public int client { get; set; }
        [ForeignKey("HotelEntity")] public int hotel { get; set; }
        [ForeignKey("TransportationEntity")] public int transportation { get; set; }
        [ForeignKey("EmployeeEntity")] public int employee { get; set; }

        public client ClientEntity { get; set; }
        public hotel HotelEntity { get; set; }
        public transportation TransportationEntity { get; set; }
        public employee EmployeeEntity { get; set; }
        
    }

    static public class gridRefFive
    {
        static public DataGrid grid { get; set; }
    }
}
