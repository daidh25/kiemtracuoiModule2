using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.DTO
{
    public class Salaries
    {
       public int worker_id {  get; set; }
       public DateTime salary_date { get; set; }
       public Decimal basic_salary { get; set; }
       public Decimal overtime_hours { get; set; }
       public Decimal overtime_pay { get; set; }
       public Decimal total_salary { get; set; }
    }
}
