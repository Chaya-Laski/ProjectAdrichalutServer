using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Inspiration
{
    public int InspirationId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Style { get; set; }

    public string? Description { get; set; }

    public string? Title { get; set; }

    public DateTime? CreatedAt { get; set; }
}
