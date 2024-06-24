using Judaica.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Judaica.Models
{
    public class Category
    {
        public Category() 
        {
            SubCategories = new List<Category>();
            Items=new List<Item>();
        }   
        [Key]
        public int ID { get; set; }

        [Display(Name ="שם קבוצה")]
        public string Name { get; set; }
        [Display(Name ="תמונה")]
        public byte[] Image { get; set; }

        //תתי קבוצות
        public List<Category> SubCategories { get; set; }
        public Category Parent { get; set; }

        //פריטים בקבוצה
        public List<Item> Items { get; set; }


        //פונקציות להוספת תתי קבוצות
        
        public Category AddSubCategory(string categoryName,IFormFile image=null)
        {
            //בדיקה האם נשלח שם לקטגוריה
            if (categoryName == string.Empty) return null;
            //הצהרה על קטגוריה חדשה
            Category category;
            //אם לא נתקבלה תמונה
            if (image == null)
                //יצירת הקטגוריה ללא התמונה כולל הצהרה על ההורה שנמצאים בו
                category= new Category { Name = categoryName, Parent = this };
            else//אם יש תמונה
                //יצירת הקטגוריה החדשה כולל התמונה
                category =new Category
                {
                    Name = categoryName,
                    Parent = this,
                    Image = new ImageService (image).Image
                };
            //הוספת הקטגוריה החדשה לקבוצות הילדים של ההורה
            SubCategories.Add(category);
            //החזרה הקטגוריה החדשה כדי שנוכל להמשיך ולהשתמש בה
            return category;
        }

        //פונקציות להוספת פריטים עם מחיר ראשוני עם תמונה
        public Item AddItem(string itemName, IFormFile image = null, decimal price = 0)
        {
            Item item=new Item { Category=this, Name=itemName };
            item.AddImage(image);
            item.AddPrice(price);
            Items.Add(item);
            return item;
        }


        //פונקציה (פרופרטי) להצגת כל הצאצאים במשפחה
        [NotMapped]
        public List<Item> GetAllItems
        {
            get
            {
                List<Item> items = new List<Item>();
                AllItems(items,this);
                return items;
            }
        }
        private void AllItems(List<Item> items, Category category)
        {
            if(category.Items.Count > 0) 
                items.Concat(category.Items);
                //foreach(Item item in category.Items)
                //    items.Add(item);
            if (category.SubCategories.Count() > 0)
                foreach (Category ctr in category.SubCategories)
                    AllItems(items,ctr);
            
        }
            
    }
}
