using KiemTraCuoiModule2.DBContext;
using KiemTraCuoiModule2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.Services
{
    public class Worker_DepartmentServices
    {
        ESewingCompanyDbContext _eSewingCompanyDbContext = new ESewingCompanyDbContext();
        public async Task<List<Worker_Department>> GetWorker_Departments(Worker_Department worker_Department)
        {
            return _eSewingCompanyDbContext.work_department.ToList();
        }
    }
}
