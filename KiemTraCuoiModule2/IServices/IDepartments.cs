using KiemTraCuoiModule2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.IServices
{
    public interface IDepartments
    {
        Task<List<Departments>> GetDepartments();

    }
}
