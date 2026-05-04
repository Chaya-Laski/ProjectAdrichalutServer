

using BL;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    
    BLManager bl;
    public CustomersController(BLManager bl)
    {
        //_service = service;
        this.bl = bl;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await bl.Customer.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await bl.Customer.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CustomerDto dto)
    {
        await bl.Customer.AddAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerDto dto)
    {
        await bl.Customer.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await bl.Customer.DeleteAsync(id);
        return Ok();
    }
}
