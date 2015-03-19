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

namespace AngularTemplate.Models.Interfaces
{
    [Sql(Schema = "dbo")]
    public interface ICategoryDataAccess
    {
        Task<IList<Category>> GetCategoriesForHouseHold(string HouseHold);
        Task<decimal> SumTransactionsByCategory(int AccountId, string HouseHold);
        
        // auto procs
        Task<ApplicationUser> SelectUserAsync(int id);
        Task InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task<Category> SelectCategoryAsync(int Id);
        Task DeleteCategoryAsync(int Id);
    }
}
