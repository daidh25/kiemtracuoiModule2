using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public string Report {  get; set; }
    }
    public class WorkersReturnData : ReturnData
    {
        public Workers workers { get; set; }
    }

}
