using KiemTraCuoiModule2.DBContext;
using KiemTraCuoiModule2.DTO;
using KiemTraCuoiModule2.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.Services
{
    public  class DepartmentsServices : IDepartments
    {
       
        ESewingCompanyDbContext _eSewingCompanyDbContext = new ESewingCompanyDbContext();
        public async Task<List<Departments>> GetDepartments()
        {
               return  _eSewingCompanyDbContext.departments.ToList();
        }
    }
}
