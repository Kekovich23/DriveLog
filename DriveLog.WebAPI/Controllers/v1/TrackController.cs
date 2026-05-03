using AutoMapper;
using DriveLog.Application.Models.Track;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Controllers.v1.Base;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;

namespace DriveLog.WebAPI.Controllers.v1;

public class TrackController(IMapper mapper, ITrackApplicationService applicationService) 
    : CrudController<Guid, TrackModel, TrackCreateModel, TrackRequestModel, TrackResponseModel, ITrackApplicationService>(mapper, applicationService) {
}
