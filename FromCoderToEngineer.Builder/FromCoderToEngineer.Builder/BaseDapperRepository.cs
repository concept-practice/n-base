namespace FromCoderToEngineer.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dapper;
    using Microsoft.Data.SqlClient;
    using Repository;

    public abstract class BaseDapperRepository<T> :
        IGetAll<T>,
        IGetById<T>,
        IAddEntity<T>,
        IDeleteById,
        IUpdateEntity<T>
        where T : Entity
    {
        private readonly SqlConnection _sqlConnection;

        protected BaseDapperRepository(SqlConnection sqlConnection, SqlBuilder<T> databaseBuilder)
        {
            _sqlConnection = sqlConnection;
            DatabaseBuilder = databaseBuilder;
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
            _sqlConnection.Open();

            _sqlConnection.Execute(command);

            _sqlConnection.Close();
        }

        protected List<T> ExecuteQuery(string command)
        {
            _sqlConnection.Open();

            var result = _sqlConnection.Query<T>(command).ToList();

            _sqlConnection.Close();

            return result;
        }

        protected List<T> ExecuteQuery<TK>(string command, Func<T, TK, T> mappingFunc)
        {
            _sqlConnection.Open();

            var result = _sqlConnection.Query(command, mappingFunc).ToList();

            _sqlConnection.Close();

            return result;
        }
    }
}
