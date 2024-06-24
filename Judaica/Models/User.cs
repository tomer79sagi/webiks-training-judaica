using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Judaica.Models
{
    public class User
    {
        public User() { RND = 5; } // הפעלת הסטר של הפונקציה RND

        [Key]
        public int ID { get; set; }

        public int RandomID { get; set; }

        [NotMapped]
        public int RND
        {
            get
            {
                return ID * 100000 + RandomID;
            }
            set
            {
                Random random = new Random();
                RandomID = random.Next(10000, 99999);
            }
        }

        [Display(Name ="שם פרטי")]
        public string FirstName{ get; set; }

        [Display(Name = "שם משפחה")]
        public string LastName{ get; set; }

        [Display(Name = "תאריך לידה"), DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "כתובת מייל"), EmailAddress(ErrorMessage = "כתובת מייל אינה נכונה")]
        public string Email { get; set; }

        [Display(Name = "טלפון"), Phone]
        public string Phone{ get; set; }

        [Display(Name ="האם מנהל")]
        public bool IsManager { get; set; }

        [Display(Name = "מנהל"), NotMapped] // לא מופיע
        public string Manager { get { return IsManager ? "מנהל" : "משתמש רגיל"; } }

        [Display(Name = "סיסמא"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
