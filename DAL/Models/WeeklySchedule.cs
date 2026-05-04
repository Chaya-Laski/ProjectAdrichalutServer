using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class WeeklySchedule
{
    public int Id { get; set; }

    public int DayOfWeek { get; set; }

    public string? FromHour { get; set; }

    public string? ToHour { get; set; }
}
