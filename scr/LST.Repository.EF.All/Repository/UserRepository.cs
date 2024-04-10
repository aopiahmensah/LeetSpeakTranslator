using LST.Model.Model;
using LST.Model.Model.IRepository;
using LST.Repository.EF.All.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Repository.EF.All.Repository
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(LSTContext context) : base(context)
        {
        }

        public IQueryable<User> GetDbSetComplete()
        {
            throw new NotImplementedException();
        }

        public override string GetEntitySetName()
        {
            return "User";
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
