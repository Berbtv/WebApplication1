using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Requests
{
    public class ServiceCompanyDto :CompanyDto
    {
        public required int Vkn { get; set; }
    }
}
