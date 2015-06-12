using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteWebApplication.Model
{
    public class Candidate
    {
        public string CandidateName { set; get; }
        public string CandidateSymbol { set; get; }
        public int NoOfVote { set; get; }
    }
}