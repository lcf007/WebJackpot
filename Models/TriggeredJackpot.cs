using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJackpot.Models
{
    public class TriggeredJackpot
    {
        public int ID { get; set; }

        public int JackpotID { get; set; }
        public int PlayerID { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentWin { get; set; }

        [Display(Name = "Trigger Date")]
        [DataType(DataType.DateTime)]
        public DateTime TriggerTime { get; set; }

        public Jackpot Jackpot { get; set; }
        public Player Player { get; set; }

    }
}
