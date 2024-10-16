using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace Models
{
    public class Emplooyeeses
    {
        [Key]
        public int EID { get; set; }
        public string Name { get; set; }
        public int DID { get; set; }
    }

    public class EmplooyeesesLeave
    {
        [Key]
        public int LeaveID { get; set; }
        public int EmployeeeId { get; set; }
        public int NumOfDate { get; set; }
    }

    public class EmplooyeesesContext : DbContext
    {
        public DbSet<Emplooyeeses> Emplooyeeses { get; set; }
        public DbSet<EmplooyeesesLeave> EmplooyeesesLeaves { get; set; }
        public string Dbpath { get; }

        public EmplooyeesesContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Dbpath = System.IO.Path.Join(path, "LeaveManagement1.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={Dbpath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Emplooyeeses>().HasKey(k => k.EID);

            modelBuilder.Entity<EmplooyeesesLeave>().HasKey(k => k.LeaveID);

        }
    }
}