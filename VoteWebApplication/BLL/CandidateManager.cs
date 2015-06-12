using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteWebApplication.DAL;
using VoteWebApplication.Model;

namespace VoteWebApplication.BLL
{
    public class CandidateManager
    {
        CandidateGateway candidateGateway=new CandidateGateway();
        VoterGateway voterGateway=new VoterGateway();
        public string SaveCandidate(Candidate candidate)
        {
            if (candidate.CandidateName == "" || candidate.CandidateSymbol == "")
            {
                return "Fiedls cannot be empty";
            }
            else if(candidateGateway.GetCandidateByCandidateSymbol(candidate.CandidateSymbol)!=null)
            {
                return "Candidate already exists";
            }
            else
            {
                candidateGateway.SaveCandidate(candidate);
                return "Successfully Saved";
            }
        }

        public List<Candidate> GetAllCandidate()
        {
            return candidateGateway.GetAllCandidate();
        }

        public List<Candidate> GetAllCandidateOrderByVotes()
        {
            return candidateGateway.GetAllCandidateOrderByVotes();
        }

        public string CastVote(string voterId, string candidateSymbol)
        {
            if (voterId == "")
            {
                return "Fields cannot be empty";
            }
            else if (voterGateway.GetVoterByVoterId(voterId) == null)
            {
                return "Voter does not exist";
            }
            else if(voterGateway.GetVoterByVoterId(voterId).VoterStatus=="Casted")
            {
                return "Voter already casted vote";
            }
            else
            {
                candidateGateway.CastVote(voterId, candidateSymbol);
                return "Vote successfully casted";
            }
        }
    }
}