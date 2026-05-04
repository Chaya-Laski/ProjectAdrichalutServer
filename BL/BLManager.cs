//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BL.Api;
//using BL.Services;
//using DAL.Api;
//using DAL.Services;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Authentication.ExtendedProtection;
//using DAL;
//using DAL.Models;
//namespace BL
//{

//    public class BLManager
//    {
//        public IBLCustomer Customer { get; }
//        public IBLInspiration Inspiration { get; }
//        public IBLMeeting Meeting { get; }
//        public IBLWeeklySchedule WeeklySchedule { get; }

//        public BLManager()
//        {
//            ServiceCollection services = new ServiceCollection();

//            services.AddSingleton<IDal, DalManager>();
//            services.AddSingleton<IBLCustomer, BLCustomerService>();
//            services.AddSingleton<IBLMeeting, BLMeetingsService>();
//            services.AddSingleton<IBLInspiration, BLInspirationsService>();
//            services.AddSingleton<IBLWeeklySchedule, BLWeeklyScheduleService>();



//            ServiceProvider serviceProvider = services.BuildServiceProvider();

//            // הזרקה אוטמטית באמצעות מנגנון ההזרקה של C#
//            Customer = serviceProvider.GetRequiredService<IBLCustomer>();
//            Meeting = serviceProvider.GetRequiredService<IBLMeeting>();
//            Inspiration = serviceProvider.GetRequiredService<IBLInspiration>();
//            WeeklySchedule = serviceProvider.GetRequiredService<IBLWeeklySchedule>();


//            //PotentialSchedulesTeacher = serviceProvider.GetRequiredService<IBLPotentialSchedulesTeacher>();
//        }
//    }
//}
using BL.Api;
using BL.Services;
using DAL;
using DAL.Api;
using Microsoft.Extensions.DependencyInjection;

public class BLManager
{
    public IBLCustomer Customer { get; }
    public IBLInspiration Inspiration { get; }
    public IBLMeeting Meeting { get; }
    public IBLWeeklySchedule WeeklySchedule { get; }

    public BLManager()
    {
        ServiceCollection services = new ServiceCollection();

        // רישום כל השירותים
        services.AddScoped<IDal, DalManager>(); // תלות ב-DalManager
        services.AddScoped<IBLCustomer, BLCustomerService>(); // תלות ב-BLCustomerService
        services.AddScoped<IBLMeeting, BLMeetingsService>();
        services.AddScoped<IBLInspiration, BLInspirationsService>();
        services.AddScoped<IBLWeeklySchedule, BLWeeklyScheduleService>();

        // יצירת ServiceProvider
        ServiceProvider serviceProvider = services.BuildServiceProvider();

        // קבלת השירותים
        Customer = serviceProvider.GetRequiredService<IBLCustomer>();
        Meeting = serviceProvider.GetRequiredService<IBLMeeting>();
        Inspiration = serviceProvider.GetRequiredService<IBLInspiration>();
        WeeklySchedule = serviceProvider.GetRequiredService<IBLWeeklySchedule>();
    }
}