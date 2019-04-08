using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebJackpot.Areas.Identity.Data;

namespace WebJackpot.Models
{
    public class TriggeredJackpot
    {
        public int ID { get; set; }

        public int JackpotID { get; set; }
        public string UserId { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentWin { get; set; }

        [Display(Name = "Trigger Date")]
        [DataType(DataType.DateTime)]
        public DateTime TriggerTime { get; set; }

        public WebJackpotUser Player { get; set; }
        public Jackpot Jackpot { get; set; }

    }
}
