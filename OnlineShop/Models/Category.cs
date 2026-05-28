namespace OnlineShop.Models
{
    public class Category
    {
        public Category()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

