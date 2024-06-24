using Judaica.DAL;
using Judaica.Models;
using Judaica.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Judaica.Controllers
{
    public class ManagerController : Controller
    {
        // פונקציה היוצרת קבוה חדשה במערכת
        public IActionResult Create(int? id) // מספר מזהה של הקבוצה של ההורה
        {
            List<Category> categories = Data.Get.GetAllCategoriesProperties;
            Category parent = categories.FirstOrDefault(c => c.ID == id, categories.First());

            VMCreateCategory VM = 
        }

        public IActionResult Index(int? id)
        {
            Category category = null;
            //List<Item> items = Data.Get.Items.Include(i => i.Prices).ToList();
            //if (id == null) category = Data.Get.Categories.Include(c => c.SubCategories).First();

            //if (id == null) category = Data.Get.Categories.Include(c => c.SubCategories).Include(c=>c.Items.Select(i=>i.Prices)).First();


            category = Data.Get.GetAllCategoriesProperties.FirstOrDefault(c => c.ID == id, Data.Get.GetAllCategoriesProperties.First());
            return View();
        }
    }
}
