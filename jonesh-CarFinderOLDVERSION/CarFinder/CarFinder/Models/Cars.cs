using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFinder.Models
{
    public class Car
    {
        public int id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string Year { get; set; }
        public string Style { get; set; }
        public string EnginePosition { get; set; }
        public string EngineCC { get; set; }
        public string EngineNumCyl { get; set; }
        public string EngineType { get; set; }
        public string EngineValvesPerCyl { get; set; }
        public string EnginePowerPs { get; set; }
        public string EnginePowerRpm { get; set; }
        public string EngineTorNm { get; set; }
        public string EngineTorRpm { get; set; }
        public string EngineBore { get; set; }
        public string EngineStroke { get; set; }    
        public string EngineComp { get; set; }
        public string EngineFuel { get; set; }
        public string TopSpeed { get; set; }
        public string ZeroTo100 { get; set; }
        public string Transmission { get; set; }
        public string Seats { get; set; }
        public string Doors { get; set; }
        public string WeightKg { get; set; }
        public string LengthMm { get; set; }
        public string WidthMm { get; set; }
        public string HeightMm { get; set; }
        public string Wheelbase { get; set; }
        public string LknHwy { get; set; }
        public string LkmMixed { get; set; }
        public string LkmCity { get; set; }
        public string FuelCapacity { get; set; }
        public string SoldInUs { get; set; }
        public string Co2 { get; set; }
        public string MakeDisplay { get; set; }
    }

    public class EdmundsCarId
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}