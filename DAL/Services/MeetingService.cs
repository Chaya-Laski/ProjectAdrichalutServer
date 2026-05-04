
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//public class MeetingService
//{
//    private readonly DbManager _context;

//    public MeetingService(DbManager context)
//    {
//        _context = context;
//    }

//    public async Task<List<Meeting>> GetAll()
//    {
//        return await _context.Meetings
//            .Include(m => m.Customer)
//            .ToListAsync();
//    }

//    public async Task<Meeting> GetById(int id)
//    {
//        return await _context.Meetings
//            .Include(m => m.Customer)
//            .FirstOrDefaultAsync(m => m.MeetingId == id);
//    }

//    public async Task Add(Meeting item)
//    {
//        await _context.Meetings.AddAsync(item);
//        await _context.SaveChangesAsync();
//    }

//    public async Task Update(Meeting item)
//    {
//        _context.Meetings.Update(item);
//        await _context.SaveChangesAsync();
//    }

//    public async Task Delete(int id)
//    {
//        var item = await _context.Meetings.FindAsync(id);
//        if (item != null)
//        {
//            _context.Meetings.Remove(item);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MeetingService : IMeeting
    {
        private readonly DbManager _context;

        public MeetingService(DbManager context)
        {
            _context = context;
        }

        public async Task<List<Meeting>> GetAll()
        {
            return await _context.Meetings
                .Include(m => m.Customer)
                .ToListAsync();
        }

        public async Task<Meeting> GetById(int id)
        {
            return await _context.Meetings
                .Include(m => m.Customer)
                .FirstOrDefaultAsync(m => m.MeetingId == id);
        }

        public async Task Add(Meeting item)
        {
            await _context.Meetings.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Meeting item)
        {
            _context.Meetings.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Meetings.FindAsync(id);
            if (item != null)
            {
                _context.Meetings.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
