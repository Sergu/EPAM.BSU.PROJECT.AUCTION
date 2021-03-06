﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using DAL.Interfaces.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public UserEntity GetUserById(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }
        public UserEntity GetUserByLogin(string login)
        {
            return userRepository.GetByLogin(login).ToBllUser();
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }
        public void Create(UserEntity entity)
        {
            userRepository.Create(entity.ToDalUser());
            uow.Commit();
        }
        public void Update(UserEntity entity)
        {
            userRepository.Update(entity.ToDalUser());
            uow.Commit();
        }
        public void Delete(int id)
        {
            userRepository.Delete(id);
            uow.Commit();
        }
    }
}
