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
    public abstract class CompanyService<TDto,TEntity>: ICompanyService<TDto>
        where TDto : CompanyDto
        where TEntity : Company, new()
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IUnitofWork _unitofWork;
        public CompanyService(IAppDbContext appDbContext, IUnitofWork unitofWork)
        {
            _appDbContext = appDbContext;
            _unitofWork = unitofWork;
        }

        public abstract string CompanyType {  get; }

        public async Task<Result> HandleApplicationAsync(TDto companyDto)
        {
            var validationResult = Validate(companyDto);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var entity = MapToEntity(companyDto);
            _appDbContext.Set<TEntity>().Add(entity);
            await _unitofWork.SaveChangesAsync();
            return Result.Success();
        }

        public Task<Result> HandleApplicationAsync(CompanyDto companyDto)
        {
            return HandleApplicationAsync((TDto)companyDto);
        }

        protected virtual TEntity MapToEntity(TDto companyDto)
        {
            var entity = new TEntity
            {
                Name = companyDto.Name,
                Surname = companyDto.Surname,
                BirthDate = companyDto.BirthDate.Value,
                PhoneNumber = companyDto.PhoneNumber
            };

            MapCustomProperties(companyDto, entity);
            return entity;
        }

        protected virtual Result Validate (TDto companyDto)
        {
            if (companyDto == null)
            {
                return Result.Failure(100, "Company data is null");
            }

            if (!companyDto.BirthDate.HasValue)
            {
                return Result.Failure(101, "Birth date is required");
            }

            if (string.IsNullOrEmpty(companyDto.Name))
            {
                return Result.Failure(102, "Name is required");
            }

            if (string.IsNullOrEmpty(companyDto.Surname))
            {
                return Result.Failure(103, "Surname is required");
            }

            if (string.IsNullOrEmpty(companyDto.PhoneNumber))
            {
                return Result.Failure(104, "Phone number is required");
            }

            return Result.Success();
        }
        protected abstract void MapCustomProperties(TDto companyDto, TEntity entity);

        
    }
    //    public class CompanyService : ICompanyService
    //{
    //    private readonly IAppDbContext appDbContext;
    //    private readonly IUnitofWork unitofWork;
    //    protected IAppDbContext AppDbContext => appDbContext;
    //    protected IUnitofWork UnitofWork => unitofWork;

    //    public CompanyService(IAppDbContext appDbContext, IUnitofWork unitofWork) 
    //    {
    //        this.appDbContext = appDbContext;
    //        this.unitofWork = unitofWork;
    //    }
    //    protected void CreateCompany(CompanyDto companyDto, Company company)
    //    {
    //        company.Surname = companyDto.Surname;
    //        company.Name = companyDto.Name;
    //        company.BirthDate = companyDto.BirthDate.Value;
    //        company.PhoneNumber = companyDto.PhoneNumber;
    //    }

    //    protected Result Validate(CompanyDto companyDto)
    //    {
    //        if (companyDto == null)
    //        {
    //            return new Result
    //            {
    //                IsSuccess = false,
    //                ErrorCode = 100,
    //                ErrorMessage = "Vehicle owner data is null"
    //            };
    //        }

    //        if (!companyDto.BirthDate.HasValue)
    //        {
    //            return new Result
    //            {
    //                IsSuccess = false,
    //                ErrorCode = 101,
    //                ErrorMessage = "Birth date is required"
    //            };
    //        }

    //        if (string.IsNullOrEmpty(companyDto.Name))
    //        {
    //            return new Result
    //            {
    //                IsSuccess = false,
    //                ErrorCode = 102,
    //                ErrorMessage = "Name is required"
    //            };
    //        }

    //        if (string.IsNullOrEmpty(companyDto.Surname))
    //        {
    //            return new Result
    //            {
    //                IsSuccess = false,
    //                ErrorCode = 103,
    //                ErrorMessage = "Surname is required"
    //            };
    //        }

    //        if (string.IsNullOrEmpty(companyDto.PhoneNumber))
    //        {
    //            return new Result
    //            {
    //                IsSuccess = false,
    //                ErrorCode = 104,
    //                ErrorMessage = "Phone number is required"
    //            };
    //        }
    //        return new Result { IsSuccess = true };
    //    }

    //}
}
