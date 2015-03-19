using System.Collections.Generic;
using System.Threading.Tasks;
using AngularTemplate.InsightUserStore;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace AngularTemplate.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface ITransactionDataAccess
    {

        Task<IList<Transaction>> GetTransactionsForAccount(int AccountId);

        // auto procs
        Task<int> InsertTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task<Transaction> SelectTransactionAsync(int Id);
        Task DeleteTransactionAsync(int Id);
    }
}
