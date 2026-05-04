
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//public class CustomerService
//{
//    private readonly DbManager _context;

//    public CustomerService(DbManager context)
//    {
//        _context = context;
//    }

//    // קבלת כל הלקוחות
//    public async Task<List<Customer>> GetAll()
//    {
//        return await _context.Customers
//            .Include(c => c.Meetings)
//            .ToListAsync();
//    }

//    // לפי מזהה
//    public async Task<Customer> GetById(int id)
//    {
//        return await _context.Customers
//            .Include(c => c.Meetings)
//            .FirstOrDefaultAsync(c => c.CustomerId == id);
//    }

//    // הוספה
//    public async Task Add(Customer customer)
//    {
//        await _context.Customers.AddAsync(customer);
//        await _context.SaveChangesAsync();
//    }

//    // עדכון
//    public async Task Update(Customer customer)
//    {
//        _context.Customers.Update(customer);
//        await _context.SaveChangesAsync();
//    }

//    // מחיקה
//    public async Task Delete(int id)
//    {
//        var customer = await _context.Customers.FindAsync(id);
//        if (customer != null)
//        {
//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();
//        }
//    }
//}

//using DAL.Api;
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace DAL.Services
//{
//    public class CustomerService : ICustomer
//    {
//        private readonly DbManager _context;

//        public CustomerService(DbManager context)
//        {
//            _context = context;
//        }

//        public async Task<List<Customer>> GetAll()
//        {
//            return await _context.Customers
//                .Include(c => c.Meetings)
//                .ToListAsync();
//        }

//        public async Task<Customer> GetById(int id)
//        {
//            return await _context.Customers
//                .Include(c => c.Meetings)
//                .FirstOrDefaultAsync(c => c.CustomerId == id);
//        }

//        public async Task Add(Customer item)
//        {
//            await _context.Customers.AddAsync(item);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Update(Customer item)
//        {
//            _context.Customers.Update(item);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Delete(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer != null)
//            {
//                _context.Customers.Remove(customer);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
using DAL.Api;  // זהו הממשק שלך
using DAL.Models;  // תוודא שהמודל שלך נכון
using Microsoft.EntityFrameworkCore;  // הוספת חבילה חשוב
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Services  // תוודא שהשירותים נמצאים תחת שם הספריה הנכון
{
    public class CustomerService : ICustomer  // אם הממשק שלך נקרא ICustomer, תוודא שהוא נמצא בתיקייה המתאימה
    {
        private readonly DbManager _context;  // DbManager זה ההקשר שלך, תוודא שזה שם נכון של DbContext

        // בנאי מקבל DbContext
        public CustomerService(DbManager context)
        {
            _context = context;
        }

        // קבלת כל הלקוחות עם מידע על פגישות
        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers
                .Include(c => c.Meetings)  // אם יש לך קשר לפגישות, תוודא שזה מופיע במודל
                .ToListAsync();  // טוען את כל הלקוחות
        }

        // קבלת לקוח לפי מזהה
        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers
                .Include(c => c.Meetings)  // כלול גם את הפגישות אם יש קשר ביניהם
                .FirstOrDefaultAsync(c => c.CustomerId == id);  // מחפש לפי מזהה הלקוח
        }

        // הוספת לקוח חדש
        public async Task Add(Customer item)
        {
            await _context.Customers.AddAsync(item);  // הוספה אסינכרונית
            await _context.SaveChangesAsync();  // שומר את השינויים בבסיס הנתונים
        }

        // עדכון לקוח
        //public async Task Update(Customer item)
        //{
        //    _context.Customers.Update(item);  // עדכון הלקוח
        //    await _context.SaveChangesAsync();  // שומר את השינויים בבסיס הנתונים
        //}
        public async Task Update(Customer item)
        {
            Customer  existing = await _context.Customers.FindAsync(item.CustomerId);
            if (existing == null)
                throw new Exception("Course not found");
            existing.CustomerId = item.CustomerId;
            existing.FirstName = item.FirstName;
            existing.LastName = item.LastName;
            existing.Phone = item.Phone;
            existing.Email = item.Email;
            existing.Address = item.Address;
            existing.SelectedProfile = item.SelectedProfile;
            existing.PaidAmount = item.PaidAmount;
            existing.RemainingAmount = item.RemainingAmount;
            existing.TotalMeetings = item.TotalMeetings;
            existing.RemainingMeetings = item.RemainingMeetings;
            existing.Quotes = item.Quotes;
            existing.Notes = item.Notes;
            await _context.SaveChangesAsync();
        }
        // מחיקת לקוח
        public async Task Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);  // חיפוש הלקוח לפי מזהה
            if (customer != null)
            {
                _context.Customers.Remove(customer);  // הסרה של הלקוח
                await _context.SaveChangesAsync();  // שמירה בבסיס הנתונים
            }
        }
    }
}