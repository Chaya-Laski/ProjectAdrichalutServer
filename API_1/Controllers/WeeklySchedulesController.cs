
using BL;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WeeklySchedulesController : ControllerBase
{
    BLManager bl;

    public WeeklySchedulesController(BLManager bl)
    {
        this.bl = bl;   
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await bl.WeeklySchedule.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await bl.WeeklySchedule.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(WeeklyScheduleDto dto)
    {
        await bl.WeeklySchedule.AddAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(WeeklyScheduleDto dto)
    {
        await bl.WeeklySchedule.UpdateAsync(dto);
        return Ok();
    }
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await bl.WeeklySchedule.DeleteAsync(id);
        return Ok();
    }
}
