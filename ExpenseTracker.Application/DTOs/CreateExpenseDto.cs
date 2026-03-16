namespace ExpenseTracker.Application.DTOs;

public class CreateExpenseDto
{
    public string Title { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}