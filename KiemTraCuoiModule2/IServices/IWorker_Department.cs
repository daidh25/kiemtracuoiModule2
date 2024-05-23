using KiemTraCuoiModule2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.IServices
{
    public interface IWorker_Department
    {
        Task<List<Worker_Department>> GetWorker_Departments();
    }
}
