using LST.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Repository.EF.All.Common
{
    public abstract class Repository<T, EntityKey> where T : class
    {
        private readonly LSTContext _context;
        public Repository(LSTContext context)
        {
            _context = context;
        }

        public LSTContext ctx
        { get { return _context; } }

        public IQueryable<T> GetDbSet()
        {
            return ctx.Set<T>();
        }

        public IEnumerable<T> GetDBSet()
        {
            return ctx.Set<T>();
        }

        public IQueryable<T> GetNoTrackingDbSet()
        {
            return ctx.Set<T>().AsNoTracking();
        }

        public abstract string GetEntitySetName();

        public T? FindBy(EntityKey Id)
        {
            return ctx.Set<T>().Find(Id);
        }


        public IEnumerable<T> FindAll()
        {
            return GetDbSet().ToList<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetDbSet().Skip(index).Take(count).ToList<T>();
        }

        public IEnumerable<T> FindBy(IQueryable<T> query)
        {
            return query.ToList<T>();
        }

        public IEnumerable<T> FindBy(IQueryable<T> query, int index, int count)
        {
            return query.Skip(index).Take(count).ToList<T>();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
