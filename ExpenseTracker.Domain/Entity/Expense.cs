namespace ExpenseTracker.Domain.Entity;

public class Expense
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}