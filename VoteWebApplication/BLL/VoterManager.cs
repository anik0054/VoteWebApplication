using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteWebApplication.DAL;
using VoteWebApplication.Model;

namespace VoteWebApplication.BLL
{
    public class VoterManager
    {
        VoterGateway voterGateway=new VoterGateway();
        public string SaveVoter(Voter voter)
        {
            if (voter.VoterName == "" || voter.VoterId == "")
            {
                return "Fiedls cannot be empty";
            }
            else if (voter.VoterId.Count() != 13)
            {
                return "Voter Id must be 13 characters long";
            }
            else
            {
                if (voterGateway.GetVoterByVoterId(voter.VoterId) != null)
                {
                    return "Voter already exists";
                }
                else
                {
                    voterGateway.SaveVoter(voter);
                    return "Successfully Saved";
                }                
            }           
        }

        public Voter GetVoterByVoterId(string voterId)
        {
            return voterGateway.GetVoterByVoterId(voterId);
        }
    }
}