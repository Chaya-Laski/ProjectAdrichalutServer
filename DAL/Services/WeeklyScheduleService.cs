using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class WeeklyScheduleService : IWeeklySchedule
    {
        private readonly DbManager _context;

        public WeeklyScheduleService(DbManager context)
        {
            _context = context;
        }

        public async Task<List<WeeklySchedule>> GetAll()
        {
            return await _context.WeeklySchedules.ToListAsync();
        }

        public async Task<WeeklySchedule> GetById(int id)
        {
            return await _context.WeeklySchedules.FindAsync(id);
        }

        public async Task Add(WeeklySchedule item)
        {
            await _context.WeeklySchedules.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(WeeklySchedule item)
        {
            _context.WeeklySchedules.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.WeeklySchedules.FindAsync(id);
            if (item != null)
            {
                _context.WeeklySchedules.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}