using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Requests
{
    public class CompanyDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
