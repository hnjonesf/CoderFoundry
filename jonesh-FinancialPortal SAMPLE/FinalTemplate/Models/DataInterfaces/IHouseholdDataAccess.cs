using System.Collections.Generic;
using System.Threading.Tasks;
using CoderFoundry.InsightUserStore.Models;
using Insight.Database;
using FinalTemplate.Models.DataModels;


namespace CoderFoundry.InsightUserStore.DataAccess
{
    [Sql(Schema = "dbo")]
    public interface IHouseholdDataAccess
    {
        // auto procs
        Task<int> InsertInvitationAsync(Invitation invitation);
        Task UpdateInvitationAsync(Invitation invitation);
        Task SelectInvitationAsync(int Id);
        Task DeleteInvitationAsync(int Id);

        Task<IList<AppUser>> GetUsersForHousehold(string Household);
        Task<IList<Invitation>> GetInvitationsForUser(string Email);
    }
}