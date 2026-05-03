using AutoMapper;
using DriveLog.Application.Models.Race;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Controllers.v1.Base;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;

namespace DriveLog.WebAPI.Controllers.v1;

public class RaceController(IMapper mapper, IRaceApplicationService applicationService) 
    : CrudController<Guid, RaceModel, RaceCreateModel, RaceRequestModel, RaceResponseModel, IRaceApplicationService>(mapper, applicationService) {
}
