using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJackpot.Models
{
    public class TriggerCondition
    {
        public int ID { get; set; }

        public int JackpotID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TriggerPoints { get; set; }
    }
}
