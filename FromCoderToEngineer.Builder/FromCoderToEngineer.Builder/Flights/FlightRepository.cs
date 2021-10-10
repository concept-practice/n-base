namespace FromCoderToEngineer.Builder.Flights
{
    using System;
    using Microsoft.Data.SqlClient;
    using Repository;

    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        private static readonly Func<SqlDataReader, Flight> ReaderFunc = reader =>
        {
            return new Flight(reader.ToGuid(0), reader.ToInt(1));
        };

        public FlightRepository(SqlBuilder<Flight> databaseBuilder, SqlConnection sqlConnection)
            : base(databaseBuilder, sqlConnection, ReaderFunc)
        {
        }
    }
}
