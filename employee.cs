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
    public class employee
    {
        [Key] public int id_employee { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string? patronymic { get; set; }
        public string phone_number { get; set; }
        public DateTime date_of_birth { get; set; }
        [ForeignKey("PositionEntity")] public int position { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public position PositionEntity { get; set; }
        public List<sale> SaleEntity { get; set; }
        public string login { get; set; }
    }
    static public class gridRefSix
    {
        static public DataGrid grid { get; set; }
    }
}
