
using DAL.Api;
using DAL.Models;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class DalManager : IDal
    {
        public ICustomer Customer { get; }
        public IInspiration Inspiration { get; }
        public IMeeting Meeting { get; }
        public IWeeklySchedule WeeklySchedule { get; }

        public DalManager()
        {
            ServiceCollection service = new ServiceCollection();

            service.AddDbContext<DbManager>();

            // ✔ תיקון חשוב: לא Singleton
            service.AddScoped<ICustomer, CustomerService>();
            service.AddScoped<IInspiration, InspirationService>();
            service.AddScoped<IMeeting, MeetingService>();
            service.AddScoped<IWeeklySchedule, WeeklyScheduleService>();

            ServiceProvider serviceProvider = service.BuildServiceProvider();

            Customer = serviceProvider.GetService<ICustomer>();
            Inspiration = serviceProvider.GetService<IInspiration>();
            Meeting = serviceProvider.GetService<IMeeting>();
            WeeklySchedule = serviceProvider.GetService<IWeeklySchedule>();
        }
    }
}