using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Application.Interfaces.Data;

namespace Infra
{
    public class AppDbContext : DbContext, IAppDbContext, IUnitofWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<VehicleOwner> VehicleOwners { get; set; }
        public DbSet<Company> Companies { get; set; } //?
        public DbSet<ServiceCompany> ServiceCompanies { get; set; }
        public DbSet<FuelStation> FuelStations{ get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
