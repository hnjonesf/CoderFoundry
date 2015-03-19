using System.Collections.Generic;
using System.Threading.Tasks;
using AngularTemplate.InsightUserStore;
using Insight.Database;
using FinalTemplate.Models.DataModels;

namespace AngularTemplate.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IAccountDataAccess
    {
        // auto procs
        Task<int> InsertAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task<Account> SelectAccountAsync(int Id);
        Task DeleteAccountAsync(int Id);
        Task<IList<Account>> FindAccountsByHouseHold(string HouseHold);
        Task<decimal> SumTransactionsByAccount(int AccountId, string HouseHold);
    }
}