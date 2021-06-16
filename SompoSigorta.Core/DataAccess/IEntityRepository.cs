using SompoSigorta.Core.Entity;
using System.Collections.Generic;

namespace SompoSigorta.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(string query);
        
        T Get(string query);

        int Insert(string query);

        int Update(string query);

        int Delete(string query);
    }
}