

//using BL;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System.IO;
//using System;
//using System.Threading.Tasks;

//[ApiController]
//[Route("api/[controller]")]
//public class InspirationsController : ControllerBase
//{
//    private readonly BLManager _bl;
//    private readonly IWebHostEnvironment _env;

//    public InspirationsController(BLManager bl, IWebHostEnvironment env)
//    {
//        _bl = bl;
//        _env = env;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAll() => Ok(await _bl.Inspiration.GetAllAsync());

//    [HttpGet("{id}")]
//    public async Task<IActionResult> Get(int id) => Ok(await _bl.Inspiration.GetByIdAsync(id));

//    [HttpPost]
//    public async Task<IActionResult> Create(InspirationDto dto)
//    {
//        await _bl.Inspiration.AddAsync(dto);
//        return Ok();
//    }

//    [HttpPut]
//    public async Task<IActionResult> Update(InspirationDto dto)
//    {
//        var existing = await _bl.Inspiration.GetByIdAsync(dto.InspirationId);
//        if (existing == null) return NotFound();

//        // מחיקת תמונות ישנות אם הוחלפו
//        if (!string.IsNullOrEmpty(existing.ImageUrl) && existing.ImageUrl != dto.ImageUrl)
//        {
//            var oldPath = Path.Combine(_env.WebRootPath, existing.ImageUrl.TrimStart('/'));
//            if (System.IO.File.Exists(oldPath))
//                System.IO.File.Delete(oldPath);
//        }

//        await _bl.Inspiration.UpdateAsync(dto);
//        return Ok();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(int id)
//    {
//        var existing = await _bl.Inspiration.GetByIdAsync(id);
//        if (existing == null) return NotFound();

//        // מחיקת תמונה ראשית
//        if (!string.IsNullOrEmpty(existing.ImageUrl))
//        {
//            var filePath = Path.Combine(_env.WebRootPath, existing.ImageUrl.TrimStart('/'));
//            if (System.IO.File.Exists(filePath))
//                System.IO.File.Delete(filePath);
//        }

//        // מחיקת תמונות חדרים
//        if (existing.RoomImages != null)
//        {
//            foreach (var roomUrl in existing.RoomImages)
//            {
//                if (string.IsNullOrEmpty(roomUrl)) continue;
//                var roomPath = Path.Combine(_env.WebRootPath, roomUrl.TrimStart('/'));
//                if (System.IO.File.Exists(roomPath))
//                    System.IO.File.Delete(roomPath);
//            }
//        }

//        await _bl.Inspiration.DeleteAsync(id);
//        return Ok();
//    }

//    [HttpPost("upload")]
//    public async Task<IActionResult> Upload(IFormFile file)
//    {
//        if (file == null || file.Length == 0)
//            return BadRequest(new { error = "No file uploaded" });

//        var wwwrootPath = _env.WebRootPath;
//        if (string.IsNullOrEmpty(wwwrootPath))
//            wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

//        var uploadDir = Path.Combine(wwwrootPath, "Images");
//        if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

//        var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//        var filePath = Path.Combine(uploadDir, uniqueName);

//        using (var stream = new FileStream(filePath, FileMode.Create))
//            await file.CopyToAsync(stream);

//        var url = $"/Images/{uniqueName}";
//        return Ok(new { url });
//    }
//}
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class InspirationsController : ControllerBase
{
    private readonly BLManager _bl;
    private readonly IWebHostEnvironment _env;

    public InspirationsController(BLManager bl, IWebHostEnvironment env)
    {
        _bl = bl;
        _env = env;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _bl.Inspiration.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _bl.Inspiration.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(InspirationDto dto)
    {
        await _bl.Inspiration.AddAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(InspirationDto dto)
    {
        var existing = await _bl.Inspiration.GetByIdAsync(dto.InspirationId);
        if (existing == null) return NotFound();

        // מחיקת תמונה ראשית ישנה אם הוחלפה
        if (!string.IsNullOrEmpty(existing.ImageUrl) && existing.ImageUrl != dto.ImageUrl)
        {
            var oldPath = Path.Combine(_env.WebRootPath, existing.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(oldPath))
                System.IO.File.Delete(oldPath);
        }

        // מחיקת תמונות חדרים ישנות שאינן קיימות יותר
        if (existing.RoomImages != null)
        {
            foreach (var roomUrl in existing.RoomImages)
            {
                if (!string.IsNullOrEmpty(roomUrl) && (dto.RoomImages == null || !dto.RoomImages.Contains(roomUrl)))
                {
                    var roomPath = Path.Combine(_env.WebRootPath, roomUrl.TrimStart('/'));
                    if (System.IO.File.Exists(roomPath))
                        System.IO.File.Delete(roomPath);
                }
            }
        }

        await _bl.Inspiration.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _bl.Inspiration.GetByIdAsync(id);
        if (existing == null) return NotFound();

        if (!string.IsNullOrEmpty(existing.ImageUrl))
        {
            var filePath = Path.Combine(_env.WebRootPath, existing.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        if (existing.RoomImages != null)
        {
            foreach (var roomUrl in existing.RoomImages)
            {
                if (string.IsNullOrEmpty(roomUrl)) continue;
                var roomPath = Path.Combine(_env.WebRootPath, roomUrl.TrimStart('/'));
                if (System.IO.File.Exists(roomPath))
                    System.IO.File.Delete(roomPath);
            }
        }

        await _bl.Inspiration.DeleteAsync(id);
        return Ok();
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest(new { error = "No file uploaded" });

        var wwwrootPath = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var uploadDir = Path.Combine(wwwrootPath, "Images");
        if (!Directory.Exists(uploadDir))
            Directory.CreateDirectory(uploadDir);

        var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadDir, uniqueName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        var url = $"/Images/{uniqueName}";
        return Ok(new { url });
    }
}