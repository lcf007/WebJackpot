using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJackpot.Models
{
    public class Jackpot
    {
        public int JackpotID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentWin { get; set; }

        [Display(Name = "Current Date")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentTime { get; set; }

    }
}
