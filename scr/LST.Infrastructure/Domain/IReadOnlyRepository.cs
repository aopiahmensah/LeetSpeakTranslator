using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, Tid>
    {
        //T FindBy(Tid Id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(IQueryable<T> query);
        IEnumerable<T> FindBy(IQueryable<T> query, int index, int count);
        IQueryable<T> GetDbSet();
        IQueryable<T> GetNoTrackingDbSet();
    }
}
