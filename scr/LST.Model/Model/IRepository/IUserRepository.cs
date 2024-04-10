using LST.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Model.Model.IRepository
{
    public interface IUserRepository : IWriteRepository<User,int>
    {
        User GetUserById(int id);
        IQueryable<User> GetDbSetComplete();
    }
}
