
using BL;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InspirationsController : ControllerBase
{

    BLManager bl;
    public InspirationsController(BLManager bl)
    {
        this.bl  = bl;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await bl.Inspiration.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await bl.Inspiration.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(InspirationDto dto)
    {
        await bl.Inspiration.AddAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(InspirationDto dto)
    {
        await bl.Inspiration.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await bl.Inspiration.DeleteAsync(id);
        return Ok();
    }
}

