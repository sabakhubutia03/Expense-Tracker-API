namespace ExpenseTracker.Application.DTOs;

public class ExpenseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; } =  DateTime.Now;
}