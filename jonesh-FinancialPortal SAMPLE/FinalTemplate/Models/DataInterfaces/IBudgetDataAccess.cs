using System.Collections.Generic;
using System.Threading.Tasks;
using CoderFoundry.InsightUserStore.Models;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace CoderFoundry.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IBudgetDataAccess
    {
        // auto procs
        Task<int> InsertBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(Budget budget);
        Task SelectBudgetAsync(int Id);
        Task DeleteBudgetAsync(int Id);
        Task<Budget> GetBudgetForHouseHold(string HouseHold);
    }
}
