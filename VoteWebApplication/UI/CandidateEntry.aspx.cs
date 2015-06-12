using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VoteWebApplication.BLL;
using VoteWebApplication.Model;

namespace VoteWebApplication.UI
{
    public partial class CandidateEntry : System.Web.UI.Page
    {
        CandidateManager candidateManager=new CandidateManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Candidate candidate=new Candidate();
            candidate.CandidateName = candidateNameTextBox.Text;
            candidate.CandidateSymbol = candidateSymbolTextBox.Text;
            candidate.NoOfVote = 0;
            string str=candidateManager.SaveCandidate(candidate);
            alertMessage.InnerHtml = str;
        }
    }
}