using AutoMapper;
using DriveLog.Application.Models.Pagination;
using DriveLog.Application.Models.Track;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class TracksController(IMapper mapper, ITrackApplicationService trackService) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 10, CancellationToken cancellationToken = default) {
        var pagination = new PaginationRequest { Skip = skip, Take = take }.Validate();
        var result = await trackService.GetAllModelsAsync(pagination.Skip, pagination.Take, cancellationToken);

        return Ok(new PaginatedResponse<TrackResponseModel>(mapper.Map<List<TrackResponseModel>>(result.Data), result.Total));
    }

    [HttpGet("{id}", Name = Constants.GetTrackById)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken) {
        var model = await trackService.GetModelByIdAsync(id, cancellationToken);

        return model is not null ? Ok(mapper.Map<TrackResponseModel>(model)) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TrackRequestModel model, CancellationToken cancellationToken) {
        var createdModel = await trackService.CreateModelAsync(mapper.Map<TrackCreateModel>(model), cancellationToken);

        return createdModel is not null ? CreatedAtRoute(Constants.GetTrackById, new { id = createdModel.Id }, mapper.Map<TrackResponseModel>(createdModel)) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TrackRequestModel model, CancellationToken cancellationToken)
        => await trackService.UpdateModelAsync(new(id, model.Name), cancellationToken) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await trackService.DeleteModelAsync(id, cancellationToken) ? NoContent() : NotFound();
}
