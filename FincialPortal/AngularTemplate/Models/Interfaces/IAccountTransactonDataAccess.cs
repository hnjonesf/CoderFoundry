using AngularTemplate.InsightUserStore;
using AngularTemplate.Models.Database;
using AngularTemplate.Models.Interfaces;
using FinalTemplate.Models.DataModels;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AngularTemplate.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IAccountTransactionDataAccess
    {

        Task<IList<AccountTransaction>> GetAccountTransactionsForAccount(int AccountId);
        Task<int> GetAcctTransCount(int AccountId);

        // auto procs
        Task<ApplicationUser> SelectUserAsync(int id);
        Task<int> InsertAccountTransactionAsync(AccountTransaction t);
        Task UpdateAccountTransactionAsync(AccountTransaction t);
        Task<AccountTransaction> SelectAccountTransactionAsync(int Id);
        Task DeleteAccountTransactionAsync(int Id);
    }
}
