namespace FromCoderToEngineer.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class SqlBuilder<T>
        where T : Entity
    {
        private readonly string _table;
        private readonly IEnumerable<string> _columns;
        private string _query;

        protected SqlBuilder(string table, params string[] columns)
        {
            _table = table;
            _columns = columns;
        }

        public string Query
        {
            get
            {
                var tempQuery = _query + ";";
                _query = string.Empty;
                return tempQuery;
            }
        }

        protected abstract Func<T, IReadOnlyList<string>> PropertyValues { get; }

        public SqlBuilder<T> GetAll()
        {
            _query += $"SELECT * FROM dbo.[{_table}]";

            return this;
        }

        public SqlBuilder<T> InnerJoin(string table, string columnName)
        {
            _query += $" INNER JOIN dbo.[{table}] ON dbo.[{_table}].{columnName} = dbo.[{table}].Id";

            return this;
        }

        public SqlBuilder<T> GetById(Guid id)
        {
            return GetAll().Where("Id").IsEqual(id.ToString());
        }

        public SqlBuilder<T> Update(T entity)
        {
            var updatedValues = string.Empty;

            var propertyValues = PropertyValues.Invoke(entity);

            for (int i = 0; i < propertyValues.Count; i++)
            {
                updatedValues += $"{_columns.ToList()[i]} = '{propertyValues[i]}', ";
            }

            _query += $"UPDATE {_table} SET {updatedValues.Trim().TrimEnd(',')}";

            return Where("Id").IsEqual(entity.Id.ToString());
        }

        public SqlBuilder<T> Where(string column)
        {
            _query += $" WHERE [{column}]";

            return this;
        }

        public SqlBuilder<T> IsEqual(string value)
        {
            _query += $" = \'{value}\'";

            return this;
        }

        public SqlBuilder<T> Delete(Guid id)
        {
            _query += $"DELETE FROM dbo.{_table}";

            return Where("Id").IsEqual(id.ToString());
        }

        public SqlBuilder<T> Insert(T entity)
        {
            var columns = _columns.Aggregate(string.Empty, (final, next) => final += $"{next}, ").Trim().TrimEnd(',');

            var flattenedValues = PropertyValues.Invoke(entity).Aggregate(string.Empty, (final, next) => final += $"'{next}', ").Trim().TrimEnd(',');

            _query += $"INSERT INTO dbo.{_table} ({columns}) VALUES ({flattenedValues})";

            return this;
        }
    }
}
