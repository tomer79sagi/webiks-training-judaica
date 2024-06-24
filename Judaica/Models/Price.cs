using System.ComponentModel.DataAnnotations;

namespace Judaica.Models
{
    public class Price
    {
        public Price() { }
        [Key]
        public int ID {  get; set; }

        public Item Item { get; set; }

        [Display(Name = "מחיר")]
        public decimal MyPrice { get; set; } = 1000000;

        [Display(Name = "תאריך התחלה"),DataType(DataType.Date)]
        public DateTime Start { get; set; } = DateTime.Now;

        [Display(Name ="תאריך סיום"), DataType(DataType.Date)]
        public DateTime End { get; set; }= DateTime.Now.AddYears(1);
    }
}