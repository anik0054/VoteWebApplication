using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VoteWebApplication.BLL;
using VoteWebApplication.Model;

namespace VoteWebApplication
{
    public partial class Home : System.Web.UI.Page
    {
        VoterManager voterManager=new VoterManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Voter voter=new Voter();
            voter.VoterId = voterIdTextBox.Text;
            voter.VoterName = voterNameTextBox.Text;
            voter.VoterStatus = "Not Casted";
            string msg=voterManager.SaveVoter(voter);
            alertMessage.InnerHtml = msg;
        }
    }
}