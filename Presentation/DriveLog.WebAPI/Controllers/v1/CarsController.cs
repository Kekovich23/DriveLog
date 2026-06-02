using AutoMapper;
using DriveLog.Application.Models.Car;
using DriveLog.Application.Services.Contracts;
using DriveLog.WebAPI.Models.Requests;
using DriveLog.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class CarsController(IMapper mapper, ICarApplicationService carService) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        => Ok(mapper.Map<List<CarResponseModel>>(await carService.GetAllModelsAsync(cancellationToken)));

    [HttpGet("{id}", Name = Constants.GetCarById)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken) {
        var model = await carService.GetModelByIdAsync(id, cancellationToken);

        return model is not null ? Ok(mapper.Map<CarResponseModel>(model)) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CarRequestModel model, CancellationToken cancellationToken) {
        var createdModel = await carService.CreateModelAsync(mapper.Map<CarCreateModel>(model), cancellationToken);

        return createdModel is not null ? CreatedAtRoute(Constants.GetCarById, new { id = createdModel.Id }, mapper.Map<CarResponseModel>(createdModel)) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CarRequestModel model, CancellationToken cancellationToken)
        => await carService.UpdateModelAsync(new(id, model.Number), cancellationToken) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await carService.DeleteModelAsync(id, cancellationToken) ? NoContent() : NotFound();
}
