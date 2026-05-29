using AutoMapper;
using DriveLog.Application.Models.Driver;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class DriversController(IMapper mapper, IDriverApplicationService driverService) : ControllerBase {
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken) {
        var model = await driverService.GetModelByIdAsync(id, cancellationToken);

        return model is not null ? Ok(mapper.Map<DriverResponseModel>(model)) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] DriverRequestModel model, CancellationToken cancellationToken) {
        var createdModel = await driverService.CreateModelAsync(mapper.Map<DriverCreateModel>(model), cancellationToken);

        return createdModel is not null ? CreatedAtAction(nameof(GetByIdAsync), new { id = createdModel.Id }, mapper.Map<DriverResponseModel>(createdModel)) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DriverRequestModel model, CancellationToken cancellationToken)
        => await driverService.UpdateModelAsync(new(id, model.FirstName, model.LastName, model.Number), cancellationToken) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await driverService.DeleteModelAsync(id, cancellationToken) ? NoContent() : NotFound();
}
