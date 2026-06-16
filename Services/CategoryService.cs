using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Category.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _context.Category.FirstOrDefault(c => c.Id == id);
        }

        public Category? SearchCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return null;

            return _context.Category.FirstOrDefault(c =>
                c.Name.Contains(categoryName));
        }
    }
}