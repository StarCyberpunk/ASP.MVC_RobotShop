﻿using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext appDbCon;
        public ProfileRepository(ApplicationDbContext a)
        {
            appDbCon = a;
        }
        public async Task<bool> Create(Profile entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Profile entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> Get(int id)
        {
            return await appDbCon.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<List<Profile>> Select()
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> Update(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}