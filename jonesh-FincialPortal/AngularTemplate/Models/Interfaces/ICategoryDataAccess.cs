using AngularTemplate.InsightUserStore;
using AngularTemplate.Models.Interfaces;
using FinalTemplate.Models.DataModels;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTemplate.Models.Interfaces
{
    [Sql(Schema = "dbo")]
    public interface ICategoryDataAccess
    {
        // auto procs
        Task<int> InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task SelectCategoryAsync(int Id);
        Task DeleteCategoryAsync(int Id);
        Task<IList<Account>> GetCategoriesForHouseHold(string HouseHold);
        Task SumTransactionsByCategory(int AccountId, string HouseHold);
        Task GetCategoriesForHousehold(string Household);
    }
}
