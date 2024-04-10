using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Infrastructure.Domain
{
    public interface IWriteRepository<T,TId> : IReadOnlyRepository<T,TId>
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
