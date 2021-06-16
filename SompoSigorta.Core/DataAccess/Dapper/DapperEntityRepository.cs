using Dapper;
using SompoSigorta.Core.DataAccess.Dapper.Context;
using SompoSigorta.Core.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SompoSigorta.Core.DataAccess.Dapper
{
    public class DapperEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : IDapperConnectContext, new()
    {
        public List<TEntity> GetAll(string query)
        {
            using (SqlConnection sqlConnection = new TContext().sqlConnection())
            {
                List<TEntity> data = (List<TEntity>)sqlConnection.Query<TEntity>(query);

                if (data.Count == 0)
                {
                    return new List<TEntity>();
                }

                return data;
            }
        }

        public TEntity Get(string query)
        {
            using (SqlConnection sqlConnection = new TContext().sqlConnection())
            {
                TEntity data = (TEntity)sqlConnection.Query<TEntity>(query).FirstOrDefault();

                if (data == null)
                {
                    return new TEntity();
                }

                return data;
            }
        }

        public int Insert(string query)
        {
            using (SqlConnection sqlConnection = new TContext().sqlConnection())
            {
                int data = sqlConnection.QuerySingle<int>(query);

                return data;
            }
        }

        public int Update(string query)
        {
            using (SqlConnection sqlConnection = new TContext().sqlConnection())
            {
                int data = sqlConnection.Execute(query);

                if (data == 0)
                {
                    return 0;
                }

                return data;
            }
        }

        public int Delete(string query)
        {
            using (SqlConnection sqlConnection = new TContext().sqlConnection())
            {
                int data = sqlConnection.Execute(query);

                if (data == 0)
                {
                    return 0;
                }

                return data;
            }
        }

    }
}
