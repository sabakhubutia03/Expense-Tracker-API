namespace ExpenseTracker.Domain.Entity;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    
}
