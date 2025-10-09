using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Requests
{
    public class FuelStationDto : CompanyDto
    {
       public required int EpdkNo { get; set; }
    }
}
