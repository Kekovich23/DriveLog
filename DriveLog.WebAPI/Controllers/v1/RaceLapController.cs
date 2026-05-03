using AutoMapper;
using DriveLog.Application.Models.RaceLap;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Controllers.v1.Base;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;

namespace DriveLog.WebAPI.Controllers.v1;

public class RaceLapController(IMapper mapper, IRaceLapApplicationService applicationService) 
    : CrudController<Guid, RaceLapModel, RaceLapCreateModel, RaceLapRequestModel, RaceLapResponseModel, IRaceLapApplicationService>(mapper, applicationService) {
}
