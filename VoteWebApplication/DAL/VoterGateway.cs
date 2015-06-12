using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VoteWebApplication.Model;

namespace VoteWebApplication.DAL
{
    public class VoterGateway
    {
        public void SaveVoter(Voter voter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO VoterTable (VoterId,VoterName,VoterStatus) VALUES('" + voter.VoterId + "','" + voter.VoterName + "','"+voter.VoterStatus+"')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Voter GetVoterByVoterId(string voterId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM VoterTable WHERE VoterId = '"+voterId+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            Voter voter=null;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();           
            while (sqlDataReader.Read())
            {
                voter = new Voter();
                voter.VoterId = sqlDataReader["VoterId"].ToString();
                voter.VoterName = sqlDataReader["VoterName"].ToString();
                voter.VoterStatus = sqlDataReader["VoterStatus"].ToString();
            }
            sqlConnection.Close();
            return voter;           
        }
    }
}