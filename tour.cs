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
    public class tour
    {
        [Key] public int id_tour { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string excursion { get; set; }
        //public string picture { get; set; }
       
        
        public List<transportation> TransportationEntity { get; set; }
    }
    static public class gridRefSeven
    {
        static public DataGrid grid { get; set; }
    }
}
