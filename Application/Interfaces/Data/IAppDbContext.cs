using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Data
{
    public interface IAppDbContext
    {
        DbSet<VehicleOwner> VehicleOwners { get; set; }
        DbSet<ServiceCompany> ServiceCompanies { get; set; }
        DbSet<FuelStation> FuelStations { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
