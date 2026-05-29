using AutoMapper;
using DriveLog.Application.Models.Base;
using DriveLog.Application.Services.Contracts.Base;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI.Controllers.v1.Base;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class CrudController<TId, TModel, TCreateModel, TRequestModel, TResponseModel, TApplicationService>(IMapper mapper,
                                                                                                                    TApplicationService applicationService) : ControllerBase
    where TModel : IModel<TId>
    where TId : struct, IEquatable<TId>
    where TCreateModel : ICreateModel
    where TResponseModel : class
    where TApplicationService : IApplicationService<TModel, TCreateModel, TId> {
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public virtual async Task<ActionResult<TResponseModel>> PostAsync(TRequestModel model) {
        var result = await applicationService.CreateModelAsync(mapper.Map<TCreateModel>(model), HttpContext.RequestAborted);

        return result == null ? BadRequest() : Ok(mapper.Map<TResponseModel>(result));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public virtual async Task<ActionResult<TResponseModel>> GetAsync(TId id) {
        var result = await applicationService.GetModelByIdAsync(id, HttpContext.RequestAborted);

        return result == null ? NotFound() : Ok(mapper.Map<TResponseModel>(result));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> PutAsync(TId id, TRequestModel model)
        => await applicationService.UpdateModelAsync(mapper.Map<TModel>(model), HttpContext.RequestAborted) ? NoContent() : BadRequest();

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<IActionResult> DeleteAsync(TId id)
        => await applicationService.DeleteModelAsync(id, HttpContext.RequestAborted) ? NoContent() : BadRequest();
}
