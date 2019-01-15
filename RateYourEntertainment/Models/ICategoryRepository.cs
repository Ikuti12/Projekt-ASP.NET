using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        Category GetCategoryById(int categoryId);
        IEnumerable<Category> GetAllCategories();
        void CreateCategory(Category category);

        void UpdateCategory(Category category);
    }
}
