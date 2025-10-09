using Application.Dto.Responses;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CompanyController<TDto, TService> : ControllerBase
    where TService : ICompanyService
    {
        protected readonly TService _service;
        protected readonly ILogger _logger;

        protected CompanyController(ILogger logger, TService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("accept-application")]
        public abstract Result AcceptApplication([FromBody] TDto dto);
        
    }
}
