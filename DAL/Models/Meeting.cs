using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Meeting
{
    public int MeetingId { get; set; }

    public int CustomerId { get; set; }

    public string Date { get; set; } = null!;

    public int? DayOfWeek { get; set; }

    public string? FromHour { get; set; }

    public string? ToHour { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
