using Judaica.Models;
using Judaica.Services;
using System.ComponentModel.DataAnnotations;

namespace Judaica.ViewModels
{
    public class VMCreateCategory
    {
        public VMCreateCategory() { Item = new Item(); Category = new Category(); }
        public Category Parent { get; set; }
        [Display(Name = "שיוך לקבוצה")]
        public int ParentID { get; set; }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public Item Item { get; set; }

        [Display(Name = "הכנסת תמונה לקבוצה החדשה")]
        public IFormFile Image { get; set; }

        [Display(Name = "הכנסת תמונה לפריט הראשון בקבוצה")]
        public IFormFile ImageItem { get; set; }

        [Display(Name = "מחיר")]
        public decimal Price { get; set; } = 1000000;
    }
}
