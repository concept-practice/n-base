namespace FromCoderToEngineer.Builder.FlightTimes
{
    using System;
    using System.Collections.Generic;
    using Airplanes;
    using Microsoft.Data.SqlClient;
    using Repository;

    public class FlightTimeRepository : BaseRepository<FlightTime>, IFlightTimeRepository
    {
        private static readonly Func<SqlDataReader, FlightTime> ReaderFunc = reader =>
        {
            return new FlightTime(reader.ToGuid(0), reader.ToDateTime(1), null);
        };

        public FlightTimeRepository(SqlBuilder<FlightTime> databaseBuilder, SqlConnection sqlConnection)
            : base(databaseBuilder, sqlConnection, ReaderFunc)
        {
        }

        public List<FlightTime> AllFlightTimesForAirplane(Guid airplaneId)
        {
            static FlightTime IncludeFunc(SqlDataReader reader)
            {
                return new FlightTime(reader.ToGuid(0), reader.ToDateTime(1), new Airplane(reader.ToGuid(3), reader.ToString(4), reader.ToString(5)));
            }

            return ExecuteQuery(DatabaseBuilder.GetAll().InnerJoin("Airplanes", "AirplaneId").Query, IncludeFunc);
        }
    }
}
