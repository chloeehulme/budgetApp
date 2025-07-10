namespace backendApi.Models
{
    public class BudgetItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Category { get; set; }
        public string? Subcategory { get; set; }
        public decimal Amount { get; set; }

        public BudgetItem(string category, string subcategory, decimal amount)
        {
            Category = category;
            Subcategory = subcategory;
            Amount = amount;
        }

        public BudgetItem() { }
    }
}
