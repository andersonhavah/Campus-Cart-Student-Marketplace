using CampusCart.Models;
public class CategoryService
{
    public List<Category> GetCategories()
    {
        return new()
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
    }
}