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
    public class CompanyService : ICompanyService
    {
        private readonly IAppDbContext appDbContext;
        private readonly IUnitofWork unitofWork;
        protected IAppDbContext AppDbContext => appDbContext;
        protected IUnitofWork UnitofWork => unitofWork;

        public CompanyService(IAppDbContext appDbContext, IUnitofWork unitofWork) 
        {
            this.appDbContext = appDbContext;
            this.unitofWork = unitofWork;
        }
        protected void CreateCompany(CompanyDto companyDto, Company company)
        {
            company.Surname = companyDto.Surname;
            company.Name = companyDto.Name;
            company.BirthDate = companyDto.BirthDate.Value;
            company.PhoneNumber = companyDto.PhoneNumber;
        }

        protected Result Validate(CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    ErrorCode = 100,
                    ErrorMessage = "Vehicle owner data is null"
                };
            }

            if (!companyDto.BirthDate.HasValue)
            {
                return new Result
                {
                    IsSuccess = false,
                    ErrorCode = 101,
                    ErrorMessage = "Birth date is required"
                };
            }

            if (string.IsNullOrEmpty(companyDto.Name))
            {
                return new Result
                {
                    IsSuccess = false,
                    ErrorCode = 102,
                    ErrorMessage = "Name is required"
                };
            }

            if (string.IsNullOrEmpty(companyDto.Surname))
            {
                return new Result
                {
                    IsSuccess = false,
                    ErrorCode = 103,
                    ErrorMessage = "Surname is required"
                };
            }

            if (string.IsNullOrEmpty(companyDto.PhoneNumber))
            {
                return new Result
                {
                    IsSuccess = false,
                    ErrorCode = 104,
                    ErrorMessage = "Phone number is required"
                };
            }
            return new Result { IsSuccess = true };
        }

    }
}
