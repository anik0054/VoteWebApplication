using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VoteWebApplication.BLL;
using VoteWebApplication.DAL;
using VoteWebApplication.Model;

namespace VoteWebApplication.UI
{
    public partial class CastVote : System.Web.UI.Page
    {
        CandidateManager candidateManager=new CandidateManager();
        VoterManager voterManager=new VoterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Candidate> candidateList=candidateManager.GetAllCandidate();
                foreach (Candidate candidate in candidateList)
                {
                    candidateSymbolDropDownList.Items.Add(new ListItem(candidate.CandidateSymbol));
                }
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string msg=candidateManager.CastVote(voterIdTextBox.Text,candidateSymbolDropDownList.SelectedValue);
            alertMessage.InnerHtml = msg;
        }
    }
}