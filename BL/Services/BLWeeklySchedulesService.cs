using DAL;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
namespace BL.Services
{

    public class BLWeeklyScheduleService : IBLWeeklySchedule
    {
        private readonly IDal _dalManager;

        // קונסטרוקטור שמקבל את DalManager
        public BLWeeklyScheduleService(IDal dalManager)
        {
            _dalManager = dalManager;
        }



        public async Task<List<WeeklyScheduleDto>> GetAllAsync()
        {
            List<WeeklySchedule> list = await _dalManager.WeeklySchedule.GetAll();
            return list.Select(w => new WeeklyScheduleDto
            {
                Id = w.Id,
                DayOfWeek = w.DayOfWeek,
                FromHour = w.FromHour,
                ToHour = w.ToHour
            }).ToList();

        }



        public async Task<WeeklyScheduleDto> GetByIdAsync(int id)
        {
            var w = await _dalManager.WeeklySchedule.GetById(id);
            if (w == null) return null;

            return new WeeklyScheduleDto
            {
                Id = w.Id,
                DayOfWeek = w.DayOfWeek,
                FromHour = w.FromHour,
                ToHour = w.ToHour
            };
        }

        public async Task AddAsync(WeeklyScheduleDto dto)
        {
            await _dalManager.WeeklySchedule.Add(new WeeklySchedule
            {

                DayOfWeek = dto.DayOfWeek,
                FromHour = dto.FromHour,
                ToHour = dto.ToHour
            });

        }


        public async Task UpdateAsync(WeeklyScheduleDto dto)
        {
            await _dalManager.WeeklySchedule.Update(new WeeklySchedule
            {
                Id = dto.Id,
                DayOfWeek = dto.DayOfWeek,
                FromHour = dto.FromHour,
                ToHour = dto.ToHour
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _dalManager.WeeklySchedule.Delete(id);

        }
    }
}