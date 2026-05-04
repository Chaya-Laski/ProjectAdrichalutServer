using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


public class MeetingDto
{
    public int MeetingId { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }

    public string Date { get; set; }
    public string? FromHour { get; set; }
    public string? ToHour { get; set; }

    public string? Status { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public virtual Customer? Customer { get; set; } 
    
}
