using KiemTraCuoiModule2.DBContext;
using KiemTraCuoiModule2.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.Services
{
    public class Work_SchedulesServices
    {
        ESewingCompanyDbContext _eSewingCompanyDbContext = new ESewingCompanyDbContext();
        public async Task<List<Work_Schedules>> GetWork_Schedules()
        {
            return _eSewingCompanyDbContext.work_schedules.ToList();
        }
    }
}
