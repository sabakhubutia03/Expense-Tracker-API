namespace ExpenseTracker.Application.DTOs;

public class UpdateExpenseDto
{
    public string Title { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}