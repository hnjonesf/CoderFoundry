using System.Collections.Generic;
using System.Threading.Tasks;
using CoderFoundry.InsightUserStore.Models;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace CoderFoundry.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IAccountDataAccess
    {
        // auto procs
        Task<int> InsertAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task SelectAccountAsync(int Id);
        Task DeleteAccountAsync(int Id);
        Task<IList<Account>> GetAccountsForHouseHold(string HouseHold);
        Task SumTransactionsByAccount(int AccountId, string HouseHold);
    }
}