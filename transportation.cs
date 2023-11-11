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
    public class transportation
    {
        [Key] public int id_transportation { get; set; }
        public string title { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        [ForeignKey("transportEntity")] public int transport { get; set; }
        [ForeignKey("TourEntity")] public int tour { get; set; }
        public string type_of_food { get; set; }
        public double cost { get; set; }
        public transport transportEntity { get; set; }
        public tour TourEntity { get; set; }
        public List<sale> SaleEntity { get; set; }
    }
    static public class gridRefEight
    {
        static public DataGrid grid { get; set; }
    }
}
