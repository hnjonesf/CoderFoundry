using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarFinder.Controllers
{
    public class MakesController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        // GET: MakesFromYear
        public IEnumerable<string> Get(string year)
        {
            List<String> retval = new List<string>();
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetMakeByYear", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add((new SqlParameter("@year", year)));

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(rdr["make"].ToString());
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return retval.ToArray<string>();
        }


    }
}