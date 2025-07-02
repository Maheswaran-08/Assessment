namespace RBACWebAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<GroupCategory> GroupCategories { get; set; }
    }
}
