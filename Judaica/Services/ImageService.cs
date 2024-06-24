namespace Judaica.Services
{
    public class ImageService
    {        
        public ImageService(IFormFile file)
        {
            //אם הקובץ הגיע ריק, יוצא מהפונקציה
            if (file == null) return;
            //יצירת מקום בזיכרון המכיל קובץ
            MemoryStream memory = new MemoryStream();
            //העתקת הקובץ לתוך המקום בזיכרון
            file.CopyTo(memory);
            //הפיכת מקום הזיכרון למערך בייטים
            Image = memory.ToArray();
        }
        public byte[] Image { get; }
    }
}
