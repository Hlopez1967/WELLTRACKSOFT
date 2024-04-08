using System.ComponentModel.DataAnnotations;

namespace WELLTRACKSOFT.Models
{
    public class TranscationsLog
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public required string description { get; set; } 
    }
}
