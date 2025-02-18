namespace SimpleEshop.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property:
        public List<Product> Products { get; set; }

    }
}