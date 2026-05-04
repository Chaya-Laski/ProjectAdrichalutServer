//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//public class InspirationDto
//{
//    public int InspirationId { get; set; }
//    public string Title { get; set; }
//    public string ImageUrl { get; set; }
//    public string Style { get; set; }
//    public string Description { get; set; }
//}
public class InspirationDto
{
    public int InspirationId { get; set; }
    public string? Title { get; set; }    // שדה nullable
    public string? ImageUrl { get; set; } // שדה nullable
    public string? Style { get; set; }    // שדה nullable
    public string? Description { get; set; } // שדה nullable

    public DateTime? CreatedAt { get; set; }
}