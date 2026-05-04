using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDal
    {
        ICustomer Customer { get; }
        IInspiration Inspiration { get; }
        IMeeting Meeting { get; }
        IWeeklySchedule WeeklySchedule { get; }
    }
}
