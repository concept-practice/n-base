namespace FromCoderToEngineer.Builder.Flights
{
    using Microsoft.Data.SqlClient;

    public class FlightDapperRepository : BaseDapperRepository<Flight>, IFlightRepository
    {
        public FlightDapperRepository(SqlConnection sqlConnection, SqlBuilder<Flight> databaseBuilder)
            : base(sqlConnection, databaseBuilder)
        {
        }
    }
}
