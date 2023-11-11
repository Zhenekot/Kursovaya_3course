using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace TourAgentCreatour
{
    public class transport
    {
        [Key] public int id_transport { get; set; }
        public string title { get; set; }
        public string number { get; set; }
        public int count_seat { get; set; }

        public List<transportation> TransportationEntity { get; set; }
    }
    static public class gridRef
    {
        static public DataGrid grid { get; set; }
    }
}
