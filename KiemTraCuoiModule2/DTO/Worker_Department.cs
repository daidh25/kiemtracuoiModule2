using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.DTO
{
    public class Worker_Department
    {
        public int worker_id {  get; set; }
        public int department_id { get; set; }
        public DateTime assigned_date { get; set; }
    }    
}
