using System.Collections.Generic;
using System.Threading.Tasks;
using CoderFoundry.InsightUserStore.Models;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace CoderFoundry.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IHomeDataAccess
    {
        // auto procs
        Task<IList<Account>> GetAccountsForHouseHold(string HouseHold);
        Task<IList<Transaction>> GetTransactionsForHouseHold(string HouseHold);

    }
}