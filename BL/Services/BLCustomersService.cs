using BL.Api;
using DAL;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace BL.Services { 
public class BLCustomerService : IBLCustomer
{
        //private readonly DalManager _context;

        //public BLCustomerService(DalManager context)
        //{
        //    _context = context;
        //}
        private readonly IDal _dalManager;

        // קונסטרוקטור שמקבל את DalManager
        public BLCustomerService(IDal dalManager)
        {
            _dalManager = dalManager;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
    {
        List<Customer> list = await _dalManager.Customer.GetAll();
            return list.Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName =  c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                SelectedProfile = c.SelectedProfile,
                PaidAmount = c.PaidAmount,
                RemainingAmount = c.RemainingAmount,
                TotalMeetings = c.TotalMeetings,
                RemainingMeetings = c.RemainingMeetings,
                Quotes = c.Quotes,
                Notes = c.Notes,

            }).ToList();
    }

    public async Task<CustomerDto> GetByIdAsync(int id)
    {
        var c = await _dalManager.Customer.GetById(id);
        if (c == null) return null;

        return new CustomerDto
        {
            CustomerId = c.CustomerId,
            FirstName = c.FirstName,
            LastName =  c.LastName,
            Email = c.Email,
            Phone = c.Phone,
            Address = c.Address,
            SelectedProfile = c.SelectedProfile,
            PaidAmount = c.PaidAmount,
            RemainingAmount = c.RemainingAmount,
            TotalMeetings = c.TotalMeetings,
            RemainingMeetings = c.RemainingMeetings,
            Quotes = c.Quotes,
            Notes = c.Notes,
        };
    }


    public async Task AddAsync(CustomerDto dto)
    {
        

        await _dalManager.Customer.Add(new Customer
        {
            FirstName = dto.FirstName,
            LastName =dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            SelectedProfile = dto.SelectedProfile,
            PaidAmount = dto.PaidAmount,
            RemainingAmount = dto.RemainingAmount,
            TotalMeetings = dto.TotalMeetings,
            RemainingMeetings = dto.RemainingMeetings,
            Quotes = dto.Quotes,
            Notes = dto.Notes,
        });

    }

        public async Task UpdateAsync(CustomerDto dto)
        {

            await _dalManager.Customer.Update(new Customer
            {
                CustomerId = dto.CustomerId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                SelectedProfile = dto.SelectedProfile,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                TotalMeetings = dto.TotalMeetings,
                RemainingMeetings = dto.RemainingMeetings,
                Quotes = dto.Quotes,
                Notes = dto.Notes,
            });
                 
        }
       
        public async Task DeleteAsync(int id)
    {
        await _dalManager.Customer.Delete(id);

    }

}
}