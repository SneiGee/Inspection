using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  {}

        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionType> inspectionTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}