using AutoMapper;
using DriveLog.Application.Models.Car;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Controllers.v1.Base;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;

namespace DriveLog.WebAPI.Controllers.v1;

public class CarController(IMapper mapper, ICarApplicationService applicationService) 
    : CrudController<Guid, CarModel, CarCreateModel, CarRequestModel, CarResponseModel, ICarApplicationService>(mapper, applicationService) {
}
