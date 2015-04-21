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
        Task<int> GetAcctTransCount(int count);
        Task<int> InsertAccountAsync(Accout account);
        Task UpdateAccountAsync(Accout account);
        Task<Accout> SelectAccountAsync(int Id);
        Task DeleteAccountAsync(int Id);
        Task<IList<Accout>> FindAccountsByHouseHold(string HouseHold);
        Task<decimal> SumTransactionsByAccount(int AccountId, string HouseHold);
    }
}