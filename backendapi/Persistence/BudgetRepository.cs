
using System;
using backendApi.Models;

namespace backendApi.Persistence
{
    public class BudgetRepository : FileRepositoryBase<BudgetItem>, IBudgetDataAccess
    {
        public BudgetRepository() : base("budgetData.json") { }

        public List<BudgetItem> GetAllBudgetItems() => ReadData();

        public BudgetItem? GetBudgetItemById(string id) =>
            ReadData().FirstOrDefault(b => b.Id == id);

        public void AddBudgetItem(BudgetItem item)
        {
            var data = ReadData();
            data.Add(item);
            WriteData(data);
        }

        public bool DeleteBudgetItem(string id)
        {
            var data = ReadData();
            var toRemove = data.FirstOrDefault(b => b.Id == id);
            if (toRemove == null) return false;

            data.Remove(toRemove);
            WriteData(data);
            return true;
        }
    }
}
