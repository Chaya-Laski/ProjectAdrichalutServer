
//using DAL.Api;
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace DAL.Services
//{
//    public class InspirationService : IInspiration
//    {
//        private readonly DbManager _context;

//        public InspirationService(DbManager context)
//        {
//            _context = context;
//        }

//        public async Task<List<Inspiration>> GetAll()
//        {
//            return await _context.Inspirations.ToListAsync();
//        }

//        public async Task<Inspiration> GetById(int id)
//        {
//            return await _context.Inspirations.FindAsync(id);
//        }

//        public async Task Add(Inspiration item)
//        {
//            await _context.Inspirations.AddAsync(item);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Update(Inspiration item)
//        {
//            Inspiration existing = await _context.Inspirations.FindAsync(item.InspirationId);
//            if (existing == null)
//                throw new Exception("Inspiration not found");
//            existing.InspirationId = item.InspirationId;
//            existing.ImageUrl = item.ImageUrl;
//            existing.Style = item.Style;
//            existing.Description = item.Description;
//            existing.Title = item.Title;
//            existing.CreatedAt = item.CreatedAt;
//            //_context.Inspirations.Update(item);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Delete(int id)
//        {
//            var item = await _context.Inspirations.FindAsync(id);
//            if (item != null)
//            {
//                _context.Inspirations.Remove(item);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System;
//using DAL.Api;

//public class InspirationService : IInspiration
//{
//    private readonly DbManager _context;

//    public InspirationService(DbManager context)
//    {
//        _context = context;
//    }

//    public async Task<List<Inspiration>> GetAll() => await _context.Inspirations.ToListAsync();

//    public async Task<Inspiration> GetById(int id) => await _context.Inspirations.FindAsync(id);

//    public async Task Add(Inspiration item)
//    {
//        await _context.Inspirations.AddAsync(item);
//        await _context.SaveChangesAsync();
//    }

//    public async Task Update(Inspiration item)
//    {
//        var existing = await _context.Inspirations.FindAsync(item.InspirationId);
//        if (existing == null) throw new Exception("Inspiration not found");

//        existing.Title = item.Title;
//        existing.ImageUrl = item.ImageUrl;
//        existing.Style = item.Style;
//        existing.Description = item.Description;
//        existing.RoomImagesJson = item.RoomImagesJson;
//        existing.CreatedAt = item.CreatedAt;

//        await _context.SaveChangesAsync();
//    }

//    public async Task Delete(int id)
//    {
//        var item = await _context.Inspirations.FindAsync(id);
//        if (item != null)
//        {
//            _context.Inspirations.Remove(item);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InspirationService : IInspiration
{
    private readonly DbManager _context;

    public InspirationService(DbManager context)
    {
        _context = context;
    }

    public async Task<List<Inspiration>> GetAll() => await _context.Inspirations.ToListAsync();

    public async Task<Inspiration> GetById(int id) => await _context.Inspirations.FindAsync(id);

    public async Task Add(Inspiration item)
    {
        await _context.Inspirations.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Inspiration item)
    {
        var existing = await _context.Inspirations.FindAsync(item.InspirationId);
        if (existing == null) throw new Exception("Inspiration not found");

        existing.Title = item.Title;
        existing.ImageUrl = item.ImageUrl;
        existing.Style = item.Style;
        existing.Description = item.Description;
        existing.RoomImages = item.RoomImages;
        existing.CreatedAt = item.CreatedAt;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var item = await _context.Inspirations.FindAsync(id);
        if (item != null)
        {
            _context.Inspirations.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}