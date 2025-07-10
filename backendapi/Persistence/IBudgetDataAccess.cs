using backendApi.Models;

namespace backendApi.Persistence
{
    public interface IBudgetDataAccess
    {
        List<BudgetItem> GetAllBudgetItems();
        BudgetItem? GetBudgetItemById(string id);
        void AddBudgetItem(BudgetItem item);
        bool DeleteBudgetItem(string id);
    }
}