using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Category GetCategoryById(int categoryId)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _appDbContext.Categories;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }
}
