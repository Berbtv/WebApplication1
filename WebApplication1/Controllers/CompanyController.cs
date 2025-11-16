using Application.Dto.Requests;
using Application.Dto.Responses;
using Application.Interfaces.Services;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController: ControllerBase
    {
        private readonly IEnumerable<ICompanyService> _companyServices;

        public CompanyController(IEnumerable<ICompanyService> companyServices) 
        {
            _companyServices = companyServices;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto companyDto)
        {
            var service = _companyServices.FirstOrDefault(x => x.CompanyType == companyDto.GetType().Name);

            if (service == null)
            {
                return NotFound("Service not found.");
            }

            var result= await service.HandleApplicationAsync(companyDto);
            return Ok(result);
        }

    }
}
