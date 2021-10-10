namespace FromCoderToEngineer.Builder.FlightTimes
{
    using System;
    using System.Collections.Generic;
    using Airplanes;
    using Microsoft.Data.SqlClient;

    internal class FlightTimeDapperRepository : BaseDapperRepository<FlightTime>, IFlightTimeRepository
    {
        public FlightTimeDapperRepository(SqlConnection sqlConnection, SqlBuilder<FlightTime> databaseBuilder)
            : base(sqlConnection, databaseBuilder)
        {
        }

        public List<FlightTime> AllFlightTimesForAirplane(Guid airplaneId)
        {
            static FlightTime IncludeFunc(FlightTime flightTime, Airplane airplane)
            {
                return new FlightTime(flightTime.Id, flightTime.Departure, airplane);
            }

            return ExecuteQuery<Airplane>(DatabaseBuilder.GetAll().InnerJoin("Airplanes", "AirplaneId").Query, IncludeFunc);
        }
    }
}
