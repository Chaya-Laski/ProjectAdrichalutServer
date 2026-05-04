//using DAL;
//using DAL.Api;
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace BL.Services
//{

//    public class BLMeetingsService : IBLMeeting
//    {
//        //private readonly DalManager _context;

//        //public BLMeetingsService(DalManager context)
//        //{
//        //    _context = context;
//        //}
//        private readonly IDal _dalManager;

//        // קונסטרוקטור שמקבל את DalManager
//        public BLMeetingsService(IDal dalManager)
//        {
//            _dalManager = dalManager;
//        }

//        public async Task<List<MeetingDto>> GetAllAsync()
//        {
//            List<Meeting> list = await _dalManager.Meeting.GetAll();
//            return list.Select(m => new MeetingDto
//            {
//                MeetingId = m.MeetingId,
//                CustomerId = m.CustomerId,
//                CustomerName = m.Customer.FirstName + " " + m.Customer.LastName,
//                Date = m.Date,
//                FromHour = (TimeOnly)m.FromHour,
//                ToHour = (TimeOnly)m.ToHour,
//                Status = m.Status,
//                Description = m.Description
//            }).ToList();

//        }

//        public async Task<MeetingDto> GetByIdAsync(int id)
//        {

//            var m = await _dalManager.Meeting.GetById(id);
//            if (m == null) return null;

//            return new MeetingDto
//            {
//                MeetingId = m.MeetingId,
//                CustomerId = m.CustomerId,
//                CustomerName = m.Customer.FirstName + " " + m.Customer.LastName,
//                Date = m.Date,
//                FromHour = (TimeOnly)m.FromHour,
//                ToHour = (TimeOnly)m.ToHour,
//                Status = m.Status,
//                Description = m.Description
//            };
//        }

//        public async Task AddAsync(MeetingDto dto)
//        {
//            await _dalManager.Meeting.Add(new Meeting
//            {
//                MeetingId = dto.MeetingId,
//                CustomerId = dto.CustomerId,
//                Date = dto.Date,
//                FromHour = dto.FromHour,
//                ToHour = dto.ToHour,
//                Status = dto.Status,
//                Description = dto.Description
//            });

//        }

//        public async Task UpdateAsync(MeetingDto dto)
//        {

//            await _dalManager.Meeting.Update(new Meeting
//            {
//                MeetingId = dto.MeetingId,
//                CustomerId = dto.CustomerId,
//                Date = dto.Date,
//                FromHour = dto.FromHour,
//                ToHour = dto.ToHour,
//                Status = dto.Status,
//                Description = dto.Description
//            });
//        }

//        public async Task DeleteAsync(int id)
//        {
//            await _dalManager.Meeting.Delete(id);

//        }
//    }

//}using DAL;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BL.Services
{
    public class BLMeetingsService : IBLMeeting
    {
        private readonly IDal _dalManager;

        public BLMeetingsService(IDal dalManager)
        {
            _dalManager = dalManager;
        }

        public async Task<List<MeetingDto>> GetAllAsync()
        {
            List<Meeting> list = await _dalManager.Meeting.GetAll();

            return list.Select(MapToDtoSafe).ToList();
        }

        public async Task<MeetingDto> GetByIdAsync(int id)
        {
            var m = await _dalManager.Meeting.GetById(id);
            if (m == null) return null;

            return MapToDtoSafe(m);
        }

        public async Task AddAsync(MeetingDto dto)
        {
            await _dalManager.Meeting.Add(new Meeting
            {
                // ❌ אין MeetingId כאן

                CustomerId = dto.CustomerId,
                Date = dto.Date,
                FromHour = dto.FromHour,
                ToHour = dto.ToHour,
                Status = dto.Status,
                Description = dto.Description
            });
        }

        public async Task UpdateAsync(MeetingDto dto)
        {
            var m = await _dalManager.Meeting.GetById(dto.MeetingId);
            m.MeetingId = dto.MeetingId;
            m.CustomerId = dto.CustomerId;
            m.Date = dto.Date;
            m.FromHour = dto.FromHour;
            m.ToHour = dto.ToHour;
            m.Status = dto.Status;
            m.Description = dto.Description;
            await _dalManager.Meeting.Update(m);
        }
       
        public async Task DeleteAsync(int id)
        {
            await _dalManager.Meeting.Delete(id);
        }

        // =========================
        // SAFE MAPPING (מונע 500)
        // =========================
        private MeetingDto MapToDtoSafe(Meeting m)
        {
            return new MeetingDto
            {
                MeetingId = m.MeetingId,
                CustomerId = m.CustomerId,

                CustomerName = m.Customer != null
                    ? $"{m.Customer.FirstName} {m.Customer.LastName}"
                    : string.Empty,

                Date = m.Date,

                FromHour = m.FromHour ,
                ToHour = m.ToHour ,

                Status = m.Status,
                Description = m.Description
            };
        }
    }
}