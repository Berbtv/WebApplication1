using Application.Dto.Requests;
using Application.Dto.Responses;
using Application.Interfaces.Data;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Application.Services
{
    public class VehicleOwnerService : CompanyService, IVehicleOwnerService
    {
        public VehicleOwnerService(IAppDbContext appDbContext, IUnitofWork unitofWork) : base(appDbContext, unitofWork)
        {
        }

        public async Task<Result> AcceptApplication(VehicleOwnerDto vehicleOwner)
        {
            var result = Validate(vehicleOwner);
            if (!result.IsSuccess)
            {
                return result;
            }

            var model = new VehicleOwner();
            base.CreateCompany(vehicleOwner, model);
            
            AppDbContext.VehicleOwners.Add(model);
            await UnitofWork.SaveChangesAsync();

            return new Result { IsSuccess = true };

        }

        protected Result Validate(VehicleOwnerDto vehicleOwner)
        { 
            var result= base.Validate(vehicleOwner);
            return result;
        }

    }
}
