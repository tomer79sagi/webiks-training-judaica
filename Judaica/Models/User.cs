using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Judaica.Models
{
    public class User
    {
        public User() { RND = 5; }// הכנסת מספר אקראי להפעלת הפונקציה (פרופרטי) של הרנדום
        [Key]
        public int ID { get; set; }

        public int RandomID { get; set; }

        [NotMapped]//שדה שלא מופיע בטבלה
        public int RND 
        { 
            get 
            { 
                //מחזיר את הרנדום בשילוב מספר מזהה של המשתמש
                return ID*100000+RandomID;
            }
            set
            {
                //יצירת אובייקט היודע לחשב רנדום
                Random random = new Random();
                //הוצאת מספר בין שני המספרים בסוגריים והכנסתם לתוך המשתנה של הרנדום
                RandomID = random.Next(10000, 99999);
            }
        }



        [Display(Name ="שם פרטי")]
        public string FirstName { get; set; }
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "תאריך לידה"),DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } 

        [Display(Name = "כתובת מייל"),EmailAddress(ErrorMessage ="כתובת מייל אינה נכונה")]
        public string Email { get; set; } 
        [Display(Name = "מספר טלפון"),Phone]
        public string Phone { get; set; }

        [Display(Name = "האם מנהל")]
        public bool IsManager { get; set; }

        [Display(Name = "מנהל"),NotMapped] // לא מופיע 
        public string Manager { get { return IsManager ? "מנהל" : "משתמש רגיל"; } }

        [Display(Name = "סיסמא"),DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
