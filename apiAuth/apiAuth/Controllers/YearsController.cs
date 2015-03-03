using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarFinder.Controllers
{
    public class YearsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;
        // GET: All Years of Cars in the Database
        public IEnumerable<string> Get()
        {
            List<String> retval = new List<string>();
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetYears", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(rdr["model_year"].ToString());
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
}​
