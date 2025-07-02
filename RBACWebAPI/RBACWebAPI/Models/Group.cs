namespace RBACWebAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<GroupCategory> GroupCategories { get; set; }


    }
}
