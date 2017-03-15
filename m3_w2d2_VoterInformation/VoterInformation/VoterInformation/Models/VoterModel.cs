using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VoterInformation.Models
{
    public class VoterModel
    {
        public int VoterId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
    }
}