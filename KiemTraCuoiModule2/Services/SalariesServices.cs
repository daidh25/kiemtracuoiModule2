using KiemTraCuoiModule2.DBContext;
using KiemTraCuoiModule2.DTO;
using KiemTraCuoiModule2.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.Services
{
    public class SalariesServices : ISalaries
    {
        ESewingCompanyDbContext _eSewingCompanyDbContext = new ESewingCompanyDbContext();
        public async Task<List<Salaries>> GetSalaries()
        {
            return _eSewingCompanyDbContext.salaries.ToList();
        }
    }
}
