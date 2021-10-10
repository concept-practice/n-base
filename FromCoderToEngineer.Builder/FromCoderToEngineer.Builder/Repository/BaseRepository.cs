namespace FromCoderToEngineer.Builder.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Data.SqlClient;

    public abstract class BaseRepository<T> :
        IGetAll<T>,
        IGetById<T>,
        IAddEntity<T>,
        IDeleteById,
        IUpdateEntity<T>
        where T : Entity
    {
        private readonly SqlConnection _sqlConnection;
        private readonly Func<SqlDataReader, T> _readerFunc;

        protected BaseRepository(SqlBuilder<T> databaseBuilder, SqlConnection sqlConnection, Func<SqlDataReader, T> readerFunc)
        {
            DatabaseBuilder = databaseBuilder;
            _sqlConnection = sqlConnection;
            _readerFunc = readerFunc;
        }

        protected SqlBuilder<T> DatabaseBuilder { get; }

        public void AddEntity(T entity)
        {
            ExecuteNonQuery(DatabaseBuilder.Insert(entity).Query);
        }

        public List<T> GetAll()
        {
            return ExecuteQuery(DatabaseBuilder.GetAll().Query);
        }

        public T GetById(Guid id)
        {
            return ExecuteQuery(DatabaseBuilder.GetById(id).Query).First();
        }

        public void DeleteEntity(Guid id)
        {
            ExecuteNonQuery(DatabaseBuilder.Delete(id).Query);
        }

        public void UpdateEntity(T entity)
        {
            ExecuteNonQuery(DatabaseBuilder.Update(entity).Query);
        }

        protected void ExecuteNonQuery(string command)
        {
            var sqlCommand = new SqlCommand(command, _sqlConnection);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        protected List<T> ExecuteQuery(string command, Func<SqlDataReader, T> customFunc = null)
        {
            var sqlQuery = new SqlCommand(command, _sqlConnection);

            _sqlConnection.Open();

            var reader = sqlQuery.ExecuteReader();

            var result = new List<T>();

            var readerFunc = customFunc ?? _readerFunc;

            while (reader.Read())
            {
                result.Add(readerFunc.Invoke(reader));
            }

            _sqlConnection.Close();

            return result;
        }
    }
}
