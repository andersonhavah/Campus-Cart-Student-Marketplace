using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class CategoryService
    {
        private List<Category> Categories = new()
            {
                new() { Id = 1, Name = "Furniture" },
                new() { Id = 2, Name = "Appliances" },
                new() { Id = 3, Name = "Electronics" },
                new() { Id = 4, Name = "Books" },
                new() { Id = 5, Name = "Accessories" },
                new() { Id = 6, Name = "Clothing" },
                new() { Id = 7, Name = "Sports" },
                new() { Id = 8, Name = "School Supplies" },
                new() { Id = 9, Name = "Dorm Essentials" },
                new() { Id = 10, Name = "Other" }
            };
        public List<Category> GetCategories()
        {
            return Categories;
        }

        public Category? GetCategoryById(int id)
        {
            return Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category? SearchCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return null;

            return Categories.FirstOrDefault(c =>
                c.Name.Contains(categoryName,
                    StringComparison.OrdinalIgnoreCase));
        }

        public void AddCategory(Category category)
        {
            category.Id = Categories.Any()
                ? Categories.Max(c => c.Id) + 1
                : 1;

            Categories.Add(category);
        }

        public bool UpdateCategory(Category updatedCategory)
        {
            var existingCategory = Categories
                .FirstOrDefault(c => c.Id == updatedCategory.Id);

            if (existingCategory == null)
                return false;

            existingCategory.Name = updatedCategory.Name;

            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
                return false;

            Categories.Remove(category);

            return true;
        }
    }
}
