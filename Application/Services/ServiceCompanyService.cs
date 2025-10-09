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
    public class ServiceCompanyService : CompanyService, IServiceCompanyService
    {
        public ServiceCompanyService(IAppDbContext appDbContext, IUnitofWork unitofWork) : base(appDbContext, unitofWork)
        {
        }

        public async Task <Result> AcceptApplication(ServiceCompanyDto serviceCompany)
        {
            var result = Validate(serviceCompany);
            if (!result.IsSuccess)
            {
                return result;
            }

            var model = new ServiceCompany();
            base.CreateCompany(serviceCompany, model);
            model.Vkn = serviceCompany.Vkn;

            AppDbContext.ServiceCompanies.Add(model);
            await UnitofWork.SaveChangesAsync();

            return new Result { IsSuccess = true };
        }

        protected Result Validate(ServiceCompanyDto serviceCompany)
        {
            var baseResult = base.Validate(serviceCompany);

            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if(serviceCompany.Vkn <= 0)
            {
                return new Result
                {
                    IsSuccess = false,
                    ErrorCode = 300,
                    ErrorMessage = "Vkn is required and must be greater than zero"
                };
            }
            return new Result { IsSuccess = true };
        }


    }
}
