namespace RBACWebAPI.Models
{
    public class GroupCategory
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
