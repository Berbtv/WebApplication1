using Application.Dto.Requests;
using Application.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IVehicleOwnerService : ICompanyService
    {
        Task <Result> AcceptApplication(VehicleOwnerDto vehicleOwner);
    }
}
// AcceptApplication tüm classlarda olacak. Polymorphism. Validate in kodları çoğunlukla aynı olacak sadece eklemeler yapılacak epdk no gibi. kod duplication olmasın
// classa spesifik özellikler diğer fonksiyon da