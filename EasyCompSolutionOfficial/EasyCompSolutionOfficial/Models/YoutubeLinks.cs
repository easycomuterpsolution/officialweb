using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

namespace EasyCompSolutionOfficial.Models
{
    public class YoutubeLinksLayer
    {
        public YoutubeLinksLayer()
        {

        }
        public List<YoutubeLink> GetAllLinks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBECSPROJConnectionString"].ConnectionString;

            List<YoutubeLink> links = new List<YoutubeLink>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllYoutubeLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    YoutubeLink link = new YoutubeLink();
                    link.Id = Convert.ToInt32(rdr["Id"]);
                    link.Link = rdr["YoutubeLink"].ToString();
                    link.Title = rdr["Title"].ToString();
                    links.Add(link);
                }
            }

            return links;
        }
        public bool AddNewLink(YoutubeLink link)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBECSPROJConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertYoutubeLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader rdr = cmd.ExecuteReader();

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Link";
                paramName.Value = link.Link;
                cmd.Parameters.Add(paramName);

                 paramName = new SqlParameter();
                paramName.ParameterName = "@Title";
                paramName.Value = link.Title;
                cmd.Parameters.Add(paramName);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return true;
        }
    }

    public class YoutubeLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
    }
}