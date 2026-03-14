using System.Text.Json.Serialization;

namespace ExpenseTracker.Domain.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [JsonIgnore]
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}