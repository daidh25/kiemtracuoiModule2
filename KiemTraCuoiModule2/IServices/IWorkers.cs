using KiemTraCuoiModule2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2.IServices
{
    public  interface IWorkers
    {
        Task<List<Workers>> GetWorkers();
        Task<WorkersReturnData> Add_Workers(Workers workers);
        Task<WorkersReturnData> Edit_Workers( Workers workers);
        Task<WorkersReturnData> Delete_Workers(Workers workers);
        Task<WorkersReturnData> GenerateSalary(Workers workers, Worker_Department worker_Department, Salaries salaries);

    }
}
