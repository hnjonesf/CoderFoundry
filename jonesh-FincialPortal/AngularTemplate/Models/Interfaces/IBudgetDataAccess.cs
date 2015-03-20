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
        Task<int> InsertBudgetsAsync(Budget budget);
        Task UpdateBudgetsAsync(Budget budget);
        Task<Budget> SelectBudgetsAsync(int Id);
        Task DeleteBudgetsAsync(int Id);
        Task<Budget> GetBudgetForHouseHold(string HouseHold);
    }
}
