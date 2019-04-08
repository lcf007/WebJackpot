using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJackpot.ViewModels
{
    public class Player
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentWin { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TriggerPoints { get; set; }

        [Display(Name = "Current Date")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentTime { get; set; }
    }

}
}
