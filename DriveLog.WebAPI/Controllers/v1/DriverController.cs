using AutoMapper;
using DriveLog.Application.Models.Driver;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Controllers.v1.Base;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;

namespace DriveLog.WebAPI.Controllers.v1;

public class DriverController(IMapper mapper, IDriverApplicationService applicationService) 
    : CrudController<Guid, DriverModel, DriverCreateModel, DriverRequestModel, DriverResponseModel, IDriverApplicationService>(mapper, applicationService) {
}
