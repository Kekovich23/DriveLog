using AutoMapper;
using DriveLog.Application.Models.Driver;
using DriveLog.Application.Models.Pagination;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class DriversController(IMapper mapper, IDriverApplicationService driverService) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 10, CancellationToken cancellationToken = default) {
        var pagination = new PaginationRequest { Skip = skip, Take = take }.Validate();
        var result = await driverService.GetAllModelsAsync(pagination.Skip, pagination.Take, cancellationToken);

        return Ok(new PaginatedResponse<DriverResponseModel>(mapper.Map<List<DriverResponseModel>>(result.Data), result.Total));
    }

    [HttpGet("{id}", Name = Constants.GetDriverById)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken) {
        var model = await driverService.GetModelByIdAsync(id, cancellationToken);

        return model is not null ? Ok(mapper.Map<DriverResponseModel>(model)) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] DriverRequestModel model, CancellationToken cancellationToken) {
        var createdModel = await driverService.CreateModelAsync(mapper.Map<DriverCreateModel>(model), cancellationToken);

        return createdModel is not null ? CreatedAtRoute(Constants.GetDriverById, new { id = createdModel.Id }, mapper.Map<DriverResponseModel>(createdModel)) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DriverRequestModel model, CancellationToken cancellationToken)
        => await driverService.UpdateModelAsync(new(id, model.FirstName, model.LastName, model.Number), cancellationToken) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await driverService.DeleteModelAsync(id, cancellationToken) ? NoContent() : NotFound();
}
