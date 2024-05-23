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
    public class WorkersServices : IWorkers
    {
        ESewingCompanyDbContext _eSewingCompanyDbContext = new ESewingCompanyDbContext();
        public async Task<List<Workers>> GetWorkers()
        {
            return _eSewingCompanyDbContext.workers.ToList();
        }
        public async Task<WorkersReturnData> Add_Workers(Workers workers)
        {
            var returnData = new WorkersReturnData();
            try
            {
                if (workers == null || string.IsNullOrEmpty(workers.worker_name))
                {
                    returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.DataInValid;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }
                var currentWorkers = _eSewingCompanyDbContext.workers.ToList().Where(s => s.worker_name == workers.worker_name).FirstOrDefault();
                if (currentWorkers.worker_name == workers.worker_name
                    && currentWorkers.date_of_birth.ToString("yyyy/MM/dd") == workers.date_of_birth.ToString("yyyy/MM/dd")
                    && currentWorkers.phone_number == workers.phone_number)
                {
                    returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.Duplicate;
                    returnData.ReturnMsg = "Công nhân này đã tồn tại ";
                    return returnData;

                }
                await _eSewingCompanyDbContext.workers.AddAsync(workers);
                var result = await _eSewingCompanyDbContext.SaveChangesAsync();
                returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Thêm dữ liệu thành công";
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.DataInValid;
                returnData.ReturnMsg = "Đã xảy ra lỗi khi xử lý yêu cầu của bạn";
               
            }

            return returnData;
        }
        public async Task<WorkersReturnData> Edit_Workers( Workers workers)
        {
            var returnData = new WorkersReturnData();
            try
            {
                var existingWorkers = await _eSewingCompanyDbContext.workers.FindAsync(workers.worker_name);

                if (existingWorkers == null)
                {
                    returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.NotFound;
                    returnData.ReturnMsg = "Không tìm thấy thông tin của công nhân";
                    return returnData;
                }
                existingWorkers.worker_id = workers.worker_id;
                existingWorkers.worker_name = workers.worker_name;
                existingWorkers.date_of_birth = workers.date_of_birth;
                existingWorkers.gender = workers.gender;
                existingWorkers.address = workers.address;
                existingWorkers.phone_number = workers.phone_number;
                existingWorkers.position = workers.position;
                existingWorkers.hire_date = workers.hire_date;
                _eSewingCompanyDbContext.workers.Update(existingWorkers);
                await _eSewingCompanyDbContext.SaveChangesAsync();

                returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Chỉnh sửa thông tin thành công";
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = "Đã xảy ra lỗi khi xử lý yêu cầu của bạn";
            }

            return returnData;
        }
        public async Task<WorkersReturnData> Delete_Workers( Workers workers)
        {
            var returnData = new WorkersReturnData();
            try
            {
                var existingWorkers = await _eSewingCompanyDbContext.workers.FindAsync(workers.worker_name);

                if (existingWorkers == null)
                {
                    returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.NotFound;
                    returnData.ReturnMsg = "Không tìm thấy thông tin của công nhân";
                    return returnData;
                }

                _eSewingCompanyDbContext.workers.Remove(existingWorkers);
                await _eSewingCompanyDbContext.SaveChangesAsync();

                returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Xóa công nhân thành công";
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)Enum.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = "Đã xảy ra lỗi khi xử lý yêu cầu của bạn";
               
            }

            return returnData;
        }
        public async Task<WorkersReturnData> GenerateSalary(Workers workers, Worker_Department worker_Department, Salaries salaries)
        {
            var returnData = new WorkersReturnData();
            try
            {
                var reportData = await (from worker in _eSewingCompanyDbContext.workers
                                        join wd in _eSewingCompanyDbContext.work_department on worker.worker_id equals wd.worker_id
                                        join salary in _eSewingCompanyDbContext.salaries on worker.worker_id equals salary.worker_id
                                        group new { worker, salary } by new { worker.worker_name } into g
                                        select new List<WorkersReturnData>GenerateSalary()
                                        {
                                            WorkerName = g.Key.worker_name,
                                            TotalSalary = g.Sum(x => x.salary.total_salary)
                                        }).ToListAsync();

                return new ReportData
                {
                    ReturnCode = (int)Enum.Common.Enum_ReturnCode.Success,
                    ReturnMsg = "Report generated successfully",
                    Report = reportData
                };
            }
            catch (Exception ex)
            {
                // Log the exception for further analysis
                Console.WriteLine($"An error occurred: {ex.Message}");

                return new ReportData
                {
                    ReturnCode = (int)Enum.Common.Enum_ReturnCode.Error,
                    ReturnMsg = "An error occurred while generating the report"
                };
            }
        }

    }
}
}
}

