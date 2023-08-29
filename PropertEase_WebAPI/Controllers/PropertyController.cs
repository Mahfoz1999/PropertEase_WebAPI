using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertEase_Commends.PropertyCommends.Commend;
using PropertEase_Commends.PropertyCommends.Query;
using PropertEase_DTO.Property;

namespace PropertEase_WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyController : ControllerBase
{
    private readonly IMediator _mediator;
    public PropertyController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PropertyPrediction(PropertyFormDto formDto)
    {
        int result = await _mediator.Send(new PropertyPredictionCommend(formDto));
        return Ok(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllAreas()
    {
        List<string> result = await _mediator.Send(new GetAllAreasQuery());
        return Ok(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllQualities()
    {
        List<string> result = await _mediator.Send(new GetAllQualitiesQuery());
        return Ok(result);
    }
}
