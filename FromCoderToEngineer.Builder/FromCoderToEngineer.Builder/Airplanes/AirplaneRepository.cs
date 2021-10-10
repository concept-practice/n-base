namespace FromCoderToEngineer.Builder.Airplanes
{
    using System;
    using Microsoft.Data.SqlClient;
    using Repository;

    public class AirplaneRepository : BaseRepository<Airplane>, IAirplaneRepository
    {
        private static readonly Func<SqlDataReader, Airplane> ReaderFunc = reader =>
        {
            return new Airplane(reader.ToGuid(0), reader.ToString(1), reader.ToString(2));
        };

        public AirplaneRepository(SqlBuilder<Airplane> databaseBuilder, SqlConnection sqlConnection)
            : base(databaseBuilder, sqlConnection, ReaderFunc)
        {
        }
    }
}
