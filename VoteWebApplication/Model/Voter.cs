using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteWebApplication.Model
{
    public class Voter
    {
        public string VoterId { set; get; }
        public string VoterName { set; get; }
        public string VoterStatus { set; get; }
    }
}