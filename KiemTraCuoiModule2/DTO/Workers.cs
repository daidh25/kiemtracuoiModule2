using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.DTO
{
    public class Workers
    {
       public int worker_id {  get; set; }
       public string worker_name { get; set; }
       public DateTime date_of_birth { get; set; }
       public string gender { get; set; }   
       public string address { get; set; }
       public int phone_number { get; set; }
       public string position { get; set; }
       public DateTime hire_date { get; set; }
    }
}
