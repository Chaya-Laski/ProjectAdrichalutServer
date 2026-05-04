using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WeeklyScheduleDto
{
    public int Id { get; set; }
    public int DayOfWeek { get; set; }
    public string? FromHour { get; set; }
    public string? ToHour { get; set; }
}
