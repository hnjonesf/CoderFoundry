using System.Collections.Generic;
using System.Threading.Tasks;
using AngularTemplate.InsightUserStore;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace AngularTemplate.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IBudgetDataAccess
    {

        Task<IList<Budget>> GetBudgetsForHouseHold(string HouseHold);

        // auto procs
        Task<int> InsertBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(Budget budget);
        Task<Budget> SelectBudgetAsync(int Id);
        Task DeleteBudgetAsync(int Id);
        Task<Budget> GetBudgetForHouseHold(string HouseHold);
    }
}
