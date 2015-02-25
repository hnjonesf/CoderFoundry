using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarFinder.Controllers
{
    public class TrimsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        // GET: TrimFromYearMakesAndModels
        public IEnumerable<string> Get(string year, string make, string model)
        {
            List<String> retval = new List<string>();
            using (conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=HCL2;integrated security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetTrimsByYearAndMakeAndModel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add((new SqlParameter("@year", year)));
                cmd.Parameters.Add((new SqlParameter("@make", make)));
                cmd.Parameters.Add((new SqlParameter("@model", model)));

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(rdr["model_trim"].ToString());
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
