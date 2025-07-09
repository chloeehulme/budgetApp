public class Budget
{
    public decimal MonthlySalary { get; set; }
    public List<BudgetItem> Items { get; set; } = new();
}
