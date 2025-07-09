
Console.Write("Enter your monthly salary: $");
decimal salary = decimal.Parse(Console.ReadLine()!);

var budget = new Budget
{
    MonthlySalary = 5000
};

Console.WriteLine("Enter budget items. Type '#' to finish.\n");

while (true)
{
    Console.Write("Subcategory name (or '#'): ");
    string? name = Console.ReadLine();
    if (name?.ToLower() == "#") break;

    Console.Write("Category (Wants / Needs / Savings): ");
    string? category = Console.ReadLine();

    Console.Write("Amount: $");
    string? amountInput = Console.ReadLine();
    if (!decimal.TryParse(amountInput, out decimal amount))
    {
        Console.WriteLine("Invalid amount. Please enter a valid number.");
        continue;
    }

    var item = new BudgetItem
    {
        Name = name ?? "",
        Category = category ?? "",
        Amount = amount
    };

    budget.Items.Add(item);
    Console.WriteLine($"✅ Added: {item.Name} | {item.Category} | ${item.Amount}");
}

StorageService.SaveToFile(budget, "budget.json");
Console.WriteLine("\n✅ Budget saved to 'budget.json'.");