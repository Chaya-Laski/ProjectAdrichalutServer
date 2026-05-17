//using DAL;
//using DAL.Api;
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Threading.Tasks;

//namespace BL.Services { 

//public class BLInspirationsService : IBLInspiration
//{
//        private readonly IDal _dalManager;

//        // קונסטרוקטור שמקבל את DalManager
//        public BLInspirationsService(IDal dalManager)
//        {
//            _dalManager = dalManager;
//        }


//        public async Task<List<InspirationDto>> GetAllAsync()
//    {
//        List<Inspiration> list = await _dalManager.Inspiration.GetAll();
//        return list.Select(x=> new InspirationDto
//        {
//            InspirationId = x.InspirationId,
//            Title = x.Title,
//            ImageUrl = x.ImageUrl,
//            Style = x.Style,
//            Description = x.Description
//        }).ToList();

//    }



//    public async Task<InspirationDto> GetByIdAsync(int id)
//    {
//        var i = await _dalManager.Inspiration.GetById( id );
//        if (i == null) return null;

//        return new InspirationDto
//        {
//            InspirationId = i.InspirationId,
//            Title = i.Title,
//            ImageUrl = i.ImageUrl,
//            Style = i.Style,
//            Description = i.Description
//        };
//    }

//    public async Task AddAsync(InspirationDto dto)
//    {
//        await _dalManager.Inspiration.Add(new Inspiration
//        {
//            Title = dto.Title,
//            ImageUrl = dto.ImageUrl,
//            Style = dto.Style,
//            Description = dto.Description,
//            CreatedAt = System.DateTime.Now
//        });
//    }

//    public async Task UpdateAsync(InspirationDto dto)
//    {
//        await _dalManager.Inspiration.Update(new Inspiration
//        {
//            InspirationId= dto.InspirationId,
//            Title = dto.Title,
//            ImageUrl = dto.ImageUrl,
//            Style = dto.Style,
//            Description = dto.Description,
//            CreatedAt = System.DateTime.Now
//        });

//    }

//    public async Task DeleteAsync(int id)
//    {
//        await _dalManager.Inspiration.Delete(id);

//    }
//}
////}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DAL.Models;
//using DAL.Api;

//public class BLInspirationsService : IBLInspiration
//{
//    private readonly IDal _dalManager;

//    public BLInspirationsService(IDal dalManager)
//    {
//        _dalManager = dalManager;
//    }

//    public async Task<List<InspirationDto>> GetAllAsync()
//    {
//        var list = await _dalManager.Inspiration.GetAll();
//        return list.Select(x => new InspirationDto
//        {
//            InspirationId = x.InspirationId,
//            Title = x.Title,
//            ImageUrl = x.ImageUrl,
//            Style = x.Style,
//            Description = x.Description,
//            RoomImagesJson = x.RoomImagesJson
//        }).ToList();
//    }

//    public async Task<InspirationDto> GetByIdAsync(int id)
//    {
//        var i = await _dalManager.Inspiration.GetById(id);
//        if (i == null) return null;
//        return new InspirationDto
//        {
//            InspirationId = i.InspirationId,
//            Title = i.Title,
//            ImageUrl = i.ImageUrl,
//            Style = i.Style,
//            Description = i.Description,
//            RoomImagesJson = i.RoomImagesJson
//        };
//    }

//    public async Task AddAsync(InspirationDto dto)
//    {
//        await _dalManager.Inspiration.Add(new Inspiration
//        {
//            Title = dto.Title,
//            ImageUrl = dto.ImageUrl,
//            Style = dto.Style,
//            Description = dto.Description,
//            RoomImagesJsons = dto.RoomImagesJsons ?? new List<string>(),
//            CreatedAt = DateTime.Now
//        });
//    }

//    public async Task UpdateAsync(InspirationDto dto)
//    {
//        await _dalManager.Inspiration.Update(new Inspiration
//        {
//            InspirationId = dto.InspirationId,
//            Title = dto.Title,
//            ImageUrl = dto.ImageUrl,
//            Style = dto.Style,
//            Description = dto.Description,
//            RoomImagesJsons = dto.ImageUrls ?? new List<string>(),
//            CreatedAt = DateTime.Now
//        });
//    }

//    public async Task DeleteAsync(int id)
//    {
//        await _dalManager.Inspiration.Delete(id);
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Api;

public class BLInspirationsService : IBLInspiration
{
    private readonly IDal _dalManager;

    public BLInspirationsService(IDal dalManager)
    {
        _dalManager = dalManager;
    }

    public async Task<List<InspirationDto>> GetAllAsync()
    {
        var list = await _dalManager.Inspiration.GetAll();
        return list.Select(x => new InspirationDto
        {
            InspirationId = x.InspirationId,
            Title = x.Title,
            ImageUrl = x.ImageUrl,
            Style = x.Style,
            Description = x.Description,
            RoomImages = x.RoomImages
        }).ToList();
    }

    public async Task<InspirationDto> GetByIdAsync(int id)
    {
        var i = await _dalManager.Inspiration.GetById(id);
        if (i == null) return null;
        return new InspirationDto
        {
            InspirationId = i.InspirationId,
            Title = i.Title,
            ImageUrl = i.ImageUrl,
            Style = i.Style,
            Description = i.Description,
            RoomImages = i.RoomImages
        };
    }

    public async Task AddAsync(InspirationDto dto)
    {
        await _dalManager.Inspiration.Add(new Inspiration
        {
            Title = dto.Title,
            ImageUrl = dto.ImageUrl,
            Style = dto.Style,
            Description = dto.Description,
            RoomImages = dto.RoomImages ?? new List<string>(),
            CreatedAt = DateTime.Now
        });
    }

    public async Task UpdateAsync(InspirationDto dto)
    {
        await _dalManager.Inspiration.Update(new Inspiration
        {
            InspirationId = dto.InspirationId,
            Title = dto.Title,
            ImageUrl = dto.ImageUrl,
            Style = dto.Style,
            Description = dto.Description,
            RoomImages = dto.RoomImages ?? new List<string>(),
            CreatedAt = DateTime.Now
        });
    }

    public async Task DeleteAsync(int id)
    {
        await _dalManager.Inspiration.Delete(id);
    }
}