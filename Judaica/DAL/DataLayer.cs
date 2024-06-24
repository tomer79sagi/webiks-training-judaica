using Judaica.Models;
using Microsoft.EntityFrameworkCore;

namespace Judaica.DAL
{
    public class DataLayer:DbContext
    {
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();//מייצר מסד נתונים לפי הטבלאות המוצהרות בהמשך הקלאס
            if (Categories.Count() == 0) Seed();
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(),
                connectionString).Options;
        }
        private void Seed()
        {
            Category category = new Category { Name = "חנות יודאיקה הכי שווה בעולם" };
            Categories.Add(category);
            SaveChanges();
        }
        //פונקציה (פרופרטי) המחזירה את הקבוצות כולל כל הצירופים
        public List<Category> GetAllCategoriesProperties
        {
            get
            {                
                return Categories.Include(c=>c.SubCategories).Include(c=>c.Items).ThenInclude(i=>i.Prices).ToList();
            }
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
