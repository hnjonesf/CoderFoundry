using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTemplate.Models.DataModels
{
    /// <summary>
    /// Invitations sent and accepted to join Household
    /// </summary>
    public class Invitation
    {
        public int Id { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string HouseHold { get; set; }
        public bool? Accepted { get; set; }
    }
}