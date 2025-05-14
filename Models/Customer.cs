namespace zonable.Models;
public class Customer{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
