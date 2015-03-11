using System.Collections.Generic;
using System.Threading.Tasks;
using CoderFoundry.InsightUserStore.Models;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace CoderFoundry.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface ITransactionDataAccess
    {
        // auto procs
        Task<int> InsertTransactionAsync(Transaction t);
        Task UpdateTransactionAsync(Transaction t);
        Task SelectTransactionAsync(int Id);
        Task DeleteTransactionAsync(int Id);
        Task SumTransactionsByAccount(int AccountId, string HouseHold);
        Task<IList<Transaction>> GetTransactionsForHouseHold(string HouseHold);
        Task<IList<Transaction>> GetTransactionsForAccount(int AccountId);
    }


}
