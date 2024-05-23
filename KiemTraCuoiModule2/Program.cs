using KiemTraCuoiModule2.DBContext;
using KiemTraCuoiModule2.DTO;
using KiemTraCuoiModule2.IServices;
using KiemTraCuoiModule2.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KiemTraCuoiModule2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var workersServices = new WorkersServices();

            Console.WriteLine("Nhập tên công nhân: ");
            string workerName = Console.ReadLine();

            if (string.IsNullOrEmpty(workerName))
            {
                Console.WriteLine("Tên công nhân không được bỏ trống");
                return;
            }

            Console.WriteLine("Nhập ngày sinh (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                Console.WriteLine("Ngày sinh không hợp lệ. Vui lòng nhập lại (yyyy-MM-dd): ");
                return;
            }

            Console.WriteLine("Nhập giới tính: ");
            string gender = Console.ReadLine();

            Console.WriteLine("Nhập địa chỉ: ");
            string address = Console.ReadLine();

            Console.WriteLine("Nhập số điện thoại: ");
            if (!int.TryParse(Console.ReadLine(), out int phoneNumber))
            {
                Console.WriteLine("Số điện thoại không hợp lệ. Vui lòng nhập lại: ");
                return;
            }

            Console.WriteLine("Nhập vị trí công việc: ");
            string position = Console.ReadLine();

            Console.WriteLine("Nhập ngày vào làm (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime hireDate))
            {
                Console.WriteLine("Ngày vào làm không hợp lệ. Vui lòng nhập lại (yyyy-MM-dd): ");
                return;
            }

            var worker = new Workers
            {
                worker_name = workerName,
                date_of_birth = dateOfBirth,
                gender = gender,
                address = address,
                phone_number = phoneNumber,
                position = position,
                hire_date = hireDate
            };

            var addResult = await workersServices.Add_Workers(worker);

            if (addResult.ReturnCode < 0)
            {
                Console.WriteLine("Thêm lỗi với lý do: {0}", addResult.ReturnMsg);
                return;
            }

            var workerServicesReturn = addResult.workers;

            Console.WriteLine("Thông tin công nhân:");
            Console.WriteLine("Tên: {0}", workerServicesReturn.worker_name);
            Console.WriteLine("Ngày sinh: {0}", workerServicesReturn.date_of_birth.ToString("yyyy-MM-dd"));
            Console.WriteLine("Giới tính: {0}", workerServicesReturn.gender);
            Console.WriteLine("Địa chỉ: {0}", workerServicesReturn.address);
            Console.WriteLine("Số điện thoại: {0}", workerServicesReturn.phone_number);
            Console.WriteLine("Vị trí: {0}", workerServicesReturn.position);
            Console.WriteLine("Ngày vào làm: {0}", workerServicesReturn.hire_date.ToString("yyyy-MM-dd"));

            Console.WriteLine("Bạn có muốn chỉnh sửa thông tin công nhân không? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Nhập tên mới cho công nhân: ");
                workerName = Console.ReadLine();

                Console.WriteLine("Nhập ngày sinh mới (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    Console.WriteLine("Ngày sinh không hợp lệ. Vui lòng nhập lại (yyyy-MM-dd): ");
                    return;
                }

                Console.WriteLine("Nhập giới tính mới: ");
                gender = Console.ReadLine();

                Console.WriteLine("Nhập địa chỉ mới: ");
                address = Console.ReadLine();

                Console.WriteLine("Nhập số điện thoại mới: ");
                if (!int.TryParse(Console.ReadLine(), out phoneNumber))
                {
                    Console.WriteLine("Số điện thoại không hợp lệ. Vui lòng nhập lại: ");
                    return;
                }

                Console.WriteLine("Nhập vị trí công việc mới: ");
                position = Console.ReadLine();

                Console.WriteLine("Nhập ngày vào làm mới (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out hireDate))
                {
                    Console.WriteLine("Ngày vào làm không hợp lệ. Vui lòng nhập lại (yyyy-MM-dd): ");
                    return;
                }

                worker = new Workers
                {
                    worker_name = workerName,
                    date_of_birth = dateOfBirth,
                    gender = gender,
                    address = address,
                    phone_number = phoneNumber,
                    position = position,
                    hire_date = hireDate
                };

                var editResult = await workersServices.Edit_Workers(worker);

                if (editResult.ReturnCode < 0)
                {
                    Console.WriteLine("Chỉnh sửa lỗi với lý do: {0}", editResult.ReturnMsg);
                    return;
                }

                Console.WriteLine("Chỉnh sửa thành công!");
            }

            Console.WriteLine("Bạn có muốn xóa công nhân này không? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                var deleteResult = await workersServices.Delete_Workers(worker);
                if (deleteResult.ReturnCode < 0)
                {
                    Console.WriteLine("Xóa lỗi với lý do: {0}", deleteResult.ReturnMsg);
                    return;
                }

                Console.WriteLine("Xóa công nhân thành công!");
            }
            
            Console.WriteLine("Bạn có muốn tính tổng lương cho từng công nhân này không? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                var salariesServices = new SalariesServices();
                var salaries = new Salaries
                {
                    worker_id = 10,
                    salary_date = DateTime.Now,
                    basic_salary = 4500000,
                    overtime_hours = 5,
                    overtime_pay = 50000,
                    total_salary = 5000000,
                };

                var generateSalary = await salariesServices.GenerateSalary(salaries);
                if (generateSalary.ReturnCode < 0)
                {
                    Console.WriteLine("Báo cáo  lỗi với lý do: {0}", generateSalary.ReturnMsg);
                    return;
                }
                
                Console.WriteLine("Tổng lương của nhân viên {0}: ",salaries.total_salary);
            }
        }

    }

}