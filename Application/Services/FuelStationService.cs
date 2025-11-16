using Application.Dto.Requests;
using Application.Dto.Responses;
using Application.Interfaces.Data;
using Application.Interfaces.Services;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FuelStationService : CompanyService<FuelStationDto, FuelStation> 
    {
        public FuelStationService(IAppDbContext appDbContext, IUnitofWork unitofWork) :base(appDbContext, unitofWork)
        {            
        }

        public override string CompanyType => nameof(FuelStationDto);

        protected override void MapCustomProperties(FuelStationDto companyDto, FuelStation entity)
        {
            entity.EpdkNo = companyDto.EpdkNo;
        }
        protected override Result Validate(FuelStationDto companyDto)
        {
            var baseResult = base.Validate(companyDto);
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if (companyDto.EpdkNo <= 0)
            {
                return Result.Failure(200, "EpdkNo is required and must be greater than zero");
            }

            return Result.Success();
        }
    }

    //public class FuelStationService : CompanyService, IFuelStationService 
    //{


    //    public FuelStationService(IAppDbContext appDbContext, IUnitofWork unitofWork) :base(appDbContext, unitofWork)
    //    {            

    //    }

    //    public async Task <Result> AcceptApplication(FuelStationDto fuelStation)
    //    {
    //        var result = Validate(fuelStation);
    //        if (!result.IsSuccess)
    //        {
    //            return result;
    //        }

    //        var model = new FuelStation();
    //        base.CreateCompany(fuelStation, model);
    //        model.EpdkNo = fuelStation.EpdkNo;

    //        AppDbContext.FuelStations.Add(model);
    //        await UnitofWork.SaveChangesAsync();


    //        return new Result { IsSuccess = true };
    //    }



    //    protected Result Validate(FuelStationDto fuelStation)
    //    {
    //        var baseResult = base.Validate(fuelStation);

    //        if (!baseResult.IsSuccess)
    //        {
    //            return baseResult;
    //        }

    //        if (fuelStation.EpdkNo <= 0)
    //        {
    //            return new Result
    //            {
    //                IsSuccess = false,
    //                ErrorCode = 200,
    //                ErrorMessage = "EpdkNo is required and must be greater than zero"
    //            };
    //        }
    //        return new Result { IsSuccess = true };
    //    }


    //}
}
