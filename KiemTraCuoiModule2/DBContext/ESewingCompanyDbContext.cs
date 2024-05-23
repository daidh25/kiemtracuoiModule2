using KiemTraCuoiModule2.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KiemTraCuoiModule2.DBContext
{
    public class ESewingCompanyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GS7QPAK3\\SQLEXPRESS;Initial Catalog=QuanLyCongNhan");
        }
        public virtual DbSet<Departments> departments { get; set; }
        public virtual DbSet<Workers> workers { get; set; }
        public virtual DbSet<Worker_Department> work_department { get; set; }
        public virtual DbSet<Work_Schedules> work_schedules { get; set; }
        public virtual DbSet<Salaries> salaries { get; set; }


    }
}
