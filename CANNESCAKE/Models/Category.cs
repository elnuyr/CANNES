namespace CANNESCAKE.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Cake> Cakes { get; set; } = new List<Cake>();
    }
}
