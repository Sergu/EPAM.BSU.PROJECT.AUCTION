﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByLogin(string login);
        DalUser TEntity GetById(int key);
    }
}
