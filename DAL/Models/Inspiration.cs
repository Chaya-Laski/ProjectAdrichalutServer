//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json;

//namespace DAL.Models;

//public partial class Inspiration
//{
//    public int InspirationId { get; set; }

//    public string? ImageUrl { get; set; }

//    public string? Style { get; set; }

//    public string? Description { get; set; }

//    public string? Title { get; set; }

//    public string? RoomImagesJson { get; set; }

//    public DateTime? CreatedAt { get; set; }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public partial class Inspiration
{
    public int InspirationId { get; set; }
    public string? ImageUrl { get; set; }
    public string? Style { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public string? RoomImagesJson { get; set; } // שמירה כ-JSON
    public DateTime? CreatedAt { get; set; }

    [NotMapped]
    public List<string> RoomImages
    {
        get => string.IsNullOrEmpty(RoomImagesJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(RoomImagesJson);
        set => RoomImagesJson = JsonSerializer.Serialize(value);
    }
}