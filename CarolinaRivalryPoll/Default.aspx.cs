using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CarolinaRivalryPoll
{
    public partial class _Default : Page
    {

        double totalVotes;
        double UNCVotes;
        double UNCVotesPercentage;
        double DUKEVotes;
        double DUKEVotesPercentage;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack) 
            {
                ShowVotePercentages();
                checkboxUNC.Visible = false;
                checkboxDUKE.Visible = false;
                btnSubmit.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=TeamsDB;Integrated Security=True;Pooling=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.UpdateTeamVotes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (radioboxUNC.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@TeamName", "UNC");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (radioboxDUKE.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@TeamName", "DUKE");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    Response.Write("You are currently in the catch all else statement which means there is a error in the logic before this");
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            checkboxUNC.Visible = false;
            checkboxDUKE.Visible = false;
        }

        protected void ShowVotePercentages()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=TeamsDB;Integrated Security=True;Pooling=False");
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetTeamVotes", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable schemaTable = dataReader.GetSchemaTable();

                // Call Read before accessing data.
                while (dataReader.Read())
                {
                    if (dataReader.GetString(1) == "UNC")
                    {
                        UNCVotes = dataReader.GetInt32(2);
                        //Response.Write($"UNC currently has {UNCVotes} votes in total at the moment");
                    }

                    else if (dataReader.GetString(1) == "DUKE")
                    {
                        DUKEVotes = dataReader.GetInt32(2);
                        //Response.Write($"Duke currently has {DUKEVotes} votes in total at the moment");
                    }
                    else
                    {
                        Response.Write("You are currently in the catch all else statement which means there is a error in the logic before this");
                    }

                }

                totalVotes = UNCVotes + DUKEVotes;
                UNCVotesPercentage = ((UNCVotes / totalVotes) * 100);
                UNCVotesPercentage = (int)Math.Round(UNCVotesPercentage);
                DUKEVotesPercentage = ((DUKEVotes / totalVotes) * 100);
                DUKEVotesPercentage = (int)Math.Round(DUKEVotesPercentage);

                //Response.Write($"This is current total of votes saved in this application {totalVotes} and out of those {totalVotes} votes, {UNCVotesPercentage}% are UNC votes and {DUKEVotesPercentage}% are Duke votes");



                lblUNC.Text = $"{UNCVotesPercentage.ToString()}%";
                lblDUKE.Text = $"{DUKEVotesPercentage.ToString()}%";

                // Call Close when done reading.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}