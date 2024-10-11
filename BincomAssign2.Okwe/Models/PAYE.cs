using System.ComponentModel.DataAnnotations;

namespace BincomAssign2.Okwe.Models
{
    public class PAYE
    {
        [Required(ErrorMessage = "Annual Income is required.")]
        public decimal Income { get; set; }
        public decimal Tax { get; set; }

    }
}
