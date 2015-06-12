using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VoteWebApplication.Model;

namespace VoteWebApplication.DAL
{
    public class CandidateGateway
    {
        VoterGateway voterGateway=new VoterGateway();
        public void SaveCandidate(Candidate candidate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO CandidateTable (CandidateName,CandidateSymbol,NoOfVote) VALUES('" + candidate.CandidateName + "','" + candidate.CandidateSymbol + "','"+candidate.NoOfVote+"')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Candidate GetCandidateByCandidateSymbol(string candidateSymbol)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CandidateTable WHERE CandidateSymbol = '" + candidateSymbol + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            Candidate candidate = null;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                candidate = new Candidate();
                candidate.CandidateName = sqlDataReader["CandidateName"].ToString();
                candidate.CandidateSymbol = sqlDataReader["CandidateSymbol"].ToString();
                candidate.NoOfVote = int.Parse(sqlDataReader["NoOfVote"].ToString());
            }
            sqlConnection.Close();
            return candidate;
        }

        public List<Candidate> GetAllCandidate()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CandidateTable";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Candidate> candidateList=new List<Candidate>();
            while (sqlDataReader.Read())
            {
                Candidate candidate = new Candidate();
                candidate.CandidateName = sqlDataReader["CandidateName"].ToString();
                candidate.CandidateSymbol = sqlDataReader["CandidateSymbol"].ToString();
                candidate.NoOfVote = int.Parse(sqlDataReader["NoOfVote"].ToString());
                candidateList.Add(candidate);
            }
            sqlConnection.Close();
            return candidateList;
        }

        public List<Candidate> GetAllCandidateOrderByVotes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CandidateTable ORDER BY NoOfVote DESC";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Candidate> candidateList = new List<Candidate>();
            while (sqlDataReader.Read())
            {
                Candidate candidate = new Candidate();
                candidate.CandidateName = sqlDataReader["CandidateName"].ToString();
                candidate.CandidateSymbol = sqlDataReader["CandidateSymbol"].ToString();
                candidate.NoOfVote = int.Parse(sqlDataReader["NoOfVote"].ToString());
                candidateList.Add(candidate);
            }
            sqlConnection.Close();
            return candidateList;
        }
        public void CastVote(string voterId, string candidateSymbol)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "UPDATE VoterTable SET VoterStatus='Casted' WHERE VoterId = '" + voterId + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            Candidate candidate=GetCandidateByCandidateSymbol(candidateSymbol);
            int updatedNoOfVotes = candidate.NoOfVote;
            updatedNoOfVotes++;
            query = "UPDATE CandidateTable SET NoOfVote='" + updatedNoOfVotes + "' WHERE CandidateSymbol = '" + candidateSymbol + "'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}