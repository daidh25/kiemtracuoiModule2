using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.DTO
{
    public class Work_Schedules
    {
       public int schedule_id {get;set;}
       public int worker_id {get;set;}
       public DateTime work_date {get;set;}
       public string shifts {get;set;}
       public Decimal hours_worked { get; set; }
    }
}
