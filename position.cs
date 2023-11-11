using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace TourAgentCreatour
{
    public class position
    {
        [Key] public int id_position { get; set; }
        public string title { get; set; }
        public double salary { get; set; }

        public List<employee> EmployeeEntity { get; set; }
    }

    static public class gridRefTwo
    {
        static public DataGrid grid { get; set; }
    }
}
