using System.ComponentModel.DataAnnotations;

namespace Judaica.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם פריט")]
        public string Name { get; set; }

        [Display(Name = "תמונה")]
        public List<Image> Images { get; set; }
        public Category Category { get; set; }

        //יום ג
        //פונקציות להוספת תמונות
        public void AddImage(IFormFile file)
        {

        }
        public List<Price> Prices { get; set; }
        //פונקציות להוספת מחירים
        public void AddPrice(decimal price)
        {
            Prices.Add(new Price { MyPrice = price, Item=this });
        }
        public void AddPrice(decimal price,DateTime end)
        {
            Prices.Add(new Price { MyPrice = price, Item = this, End=end });
        }
        public void AddPrice(decimal price, DateTime start,DateTime end)
        {
            Prices.Add(new Price { MyPrice = price, Item = this, End = end ,Start=start});
        }

    }
}