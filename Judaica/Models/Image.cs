using System.ComponentModel.DataAnnotations;

namespace Judaica.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public Item Item { get; set; }
        public byte[] MyImage { get; set; }
    }
}