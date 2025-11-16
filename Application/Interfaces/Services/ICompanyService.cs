using Application.Dto.Requests;
using Application.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Result> HandleApplicationAsync(CompanyDto companyDto);
        string CompanyType {  get; }
    }

    public interface ICompanyService<TDto>: ICompanyService 
    {
        Task<Result> HandleApplicationAsync(TDto companyDto); 
    }

    // handleappasync eklenilen kaydın id'sini responseta dönecek ve
    // dönen id kullanılarak getcompany adında metoda arametre olarak verilecek ve kaydedilen kayıt geri dönecek.
    // diğer endpointleri de yazıp type parametresi almadan implemente edicez.
}
