namespace FromCoderToEngineer.Builder
{
    using System;
    using Microsoft.Data.SqlClient;

    public static class DataReaderExtensions
    {
        public static Guid ToGuid(this SqlDataReader reader, int position)
        {
            return Guid.Parse(reader[position].ToString());
        }

        public static string ToString(this SqlDataReader reader, int position)
        {
            return reader[position].ToString();
        }

        public static int ToInt(this SqlDataReader reader, int position)
        {
            return int.Parse(reader[position].ToString());
        }

        public static DateTime ToDateTime(this SqlDataReader reader, int position)
        {
            return DateTime.Parse(reader[position].ToString());
        }
    }
}
