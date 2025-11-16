using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dto.Requests
{
    [JsonDerivedType(typeof(FuelStationDto), typeDiscriminator: "fuel")]
    [JsonDerivedType(typeof(ServiceCompanyDto), typeDiscriminator: "service")]
    [JsonDerivedType(typeof(VehicleOwnerDto), typeDiscriminator: "owner")]
    public class CompanyDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
