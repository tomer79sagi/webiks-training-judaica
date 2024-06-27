using Judaica.DAL;
using Judaica.Models;
using Judaica.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Judaica.Controllers
{
    public class ManagerController : Controller
    {
        //פונקציה היוצרת קבוצה חדשה במערכת
        public IActionResult Create(int? id)//מספר מזהה של הקבוצה של ההורה
        {
            List<Category> categories = Data.Get.GetAllCategoriesProperties;
            Category parent = categories.FirstOrDefault(c=>c.ID == id,categories.First());

            VMCreateCategory VM = new VMCreateCategory
            {
                Categories = categories,
                Parent = parent,
                ParentID = parent.ID
            };
            return View(VM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(VMCreateCategory VM)
        {
            Category parent = Data.Get.Categories.FirstOrDefault(c => c.ID == VM.ParentID);
            if (parent == null) return RedirectToAction("Index", "Home");
            parent.AddSubCategory(VM.Category.Name, VM.Image).AddItem(VM.Item.Name, VM.ImageItem, VM.Price);
            Data.Get.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index(int? id)
        {
            //Category category = null;
            //List<Item> items = Data.Get.Items.Include(i => i.Prices).ToList();
            //if (id == null) category = Data.Get.Categories.Include(c => c.SubCategories).First();

            //if (id == null) category = Data.Get.Categories.Include(c => c.SubCategories).Include(c=>c.Items.Select(i=>i.Prices)).First();
            //category = Data.Get.GetAllCategoriesProperties.FirstOrDefault(c => c.ID == id, Data.Get.GetAllCategoriesProperties.First());

            return View(Data.Get.GetAllCategoriesProperties);
        }
    }
}
