using AutoMapper;
using FormulaOne.DataService.Resositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers;

public class AchievementController:BaseController
{
    public AchievementController(
        IUnitOfWork unitOfWork, 
        IMapper mapper , IMediator mediator) : base(unitOfWork, mapper,mediator)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchivements(Guid driverId)
    {
        var driverAchievements = await UnitOfWork.Achievements.GetDriverAchievementAsync(driverId);

        if (driverAchievements == null)
            return NotFound("Achievements not found");

        var result = Mapper.Map<DriverAchievementsResponse>(driverAchievements);

        return Ok(result);

    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = Mapper.Map<Achievement>(achievement);

        await UnitOfWork.Achievements.Add(result);
        await UnitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchivements),new
        {
            driverId = result.DriverId,
        }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = Mapper.Map<Achievement>(achievement);

        await UnitOfWork.Achievements.Update(result);
        await UnitOfWork.CompleteAsync();

        return NoContent();
    }
    
}