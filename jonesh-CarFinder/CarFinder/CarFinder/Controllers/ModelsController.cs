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
    public class ModelsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        // GET: ModelsFromYearAndMakes
        public IEnumerable<string> Get(string year, string make)
        {
            List<String> retval = new List<string>();
            using (conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=HCL2;integrated security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetModelByYearAndMake", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add((new SqlParameter("@year", year)));
                cmd.Parameters.Add((new SqlParameter("@make", make)));

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(rdr["model_name"].ToString());
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