using AutoMapper;
using FormulaOne.DataService.Repositories;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FormulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievmentAsync(driverId);

        if (driverAchievements == null)
        {
            return NotFound("Achievements not found");
        }

        var result = _mapper.Map<CreateDriverAchievementResponse>(driverAchievements);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        //convert to an Achievement from CreateDriverAchievementRequest
        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();

    }

}