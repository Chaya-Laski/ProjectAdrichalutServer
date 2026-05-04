using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CustomerDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public string? Address { get; set; }

    public string? SelectedProfile { get; set; }

    public decimal? PaidAmount { get; set; }

    public decimal? RemainingAmount { get; set; }

    public int? TotalMeetings { get; set; }

    public int? RemainingMeetings { get; set; }

    public string? Quotes { get; set; }

    public string? Notes { get; set; }
}
