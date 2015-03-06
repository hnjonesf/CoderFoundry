using CarFinder.Models;
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
    public class CarsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        // GET: TrimFromYearMakesAndModels
        public IEnumerable<Car> Get(string year, string make, string model, string trim)
        {
            List<Car> retval = new List<Car>();
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCarsByYearMakeModelAndTrim", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@year", year));
                cmd.Parameters.Add(new SqlParameter("@make", make));
                cmd.Parameters.Add(new SqlParameter("@model", model));
                cmd.Parameters.Add(new SqlParameter("@trim", trim));

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(new Car
                    {
                        Make = rdr["make"].ToString(),
                        Model = rdr["model_name"].ToString(),
                        Trim = rdr["model_trim"].ToString(),
                        Year = rdr["model_year"].ToString(),
                        Style = rdr["body_style"].ToString(),
                        EnginePosition = rdr["engine_position"].ToString(),
                        EngineCC = rdr["engine_cc"].ToString(),
                        EngineNumCyl = rdr["engine_num_cyl"].ToString(),
                        EngineType = rdr["engine_type"].ToString(),
                        EngineValvesPerCyl = rdr["engine_valves_per_cyl"].ToString(),
                        EnginePowerPs = rdr["engine_power_ps"].ToString(),
                        EnginePowerRpm = rdr["engine_power_rpm"].ToString(),
                        EngineTorNm = rdr["engine_torque_nm"].ToString(),
                        EngineTorRpm = rdr["engine_torque_rpm"].ToString(),
                        EngineBore = rdr["engine_bore_mm"].ToString(),
                        EngineStroke = rdr["engine_stroke_mm"].ToString(),
                        EngineComp = rdr["engine_compression"].ToString(),
                        EngineFuel = rdr["engine_fuel"].ToString(),
                        TopSpeed = rdr["top_speed_kph"].ToString(),
                        ZeroTo100 = rdr["zero_to_100_kph"].ToString(),
                        Transmission = rdr["transmission_type"].ToString(),
                        Seats = rdr["seats"].ToString(),
                        Doors = rdr["doors"].ToString(),
                        WeightKg = rdr["weight_kg"].ToString(),
                        LengthMm = rdr["length_mm"].ToString(),
                        WidthMm = rdr["width_mm"].ToString(),
                        HeightMm = rdr["height_mm"].ToString(),
                        Wheelbase = rdr["wheelbase"].ToString(),
                        LknHwy = rdr["lkm_hwy"].ToString(),
                        LkmMixed = rdr["lkm_mixed"].ToString(),
                        LkmCity = rdr["lkm_city"].ToString(),
                        FuelCapacity = rdr["fuel_capacity_l"].ToString(),
                        SoldInUs = rdr["sold_in_us"].ToString(),
                        Co2 = rdr["co2"].ToString(),
                        MakeDisplay = rdr["make_display"].ToString()
                    });
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
            return retval.ToArray<Car>();
        }


    }
}
