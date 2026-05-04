
using BL;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MeetingsController : ControllerBase
{
    BLManager bl;

    public MeetingsController(BLManager bl)
    {
        this.bl = bl;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await bl.Meeting.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id )
        => Ok(await bl.Meeting.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(MeetingDto dto)
    {
        await bl.Meeting.AddAsync(dto);
        return Ok();
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(CustomerDto dto)
    //{
    //    await bl.Customer.AddAsync(dto);
    //    return Ok();
    //}

    [HttpPut]
    public async Task<IActionResult> Update(MeetingDto dto)
    {
       
        await bl.Meeting.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await bl.Meeting.DeleteAsync(id);
        return Ok();
    }
}

