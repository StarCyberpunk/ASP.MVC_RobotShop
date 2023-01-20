using second.DAL.Interfaces;
using second.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        public Task<bool> Create(Profile entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Profile entity)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Profile>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<Profile> Update(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}
