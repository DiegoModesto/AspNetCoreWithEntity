using Khan.Common.Entities;
using System;

namespace Khan.DataBase.Repository.Interfaces
{
    interface IUserRepository : IRepository<UserEntity>
    {
        bool CheckUserExistByName(string name);
        bool CheckUserIsACtive(Guid Id);
    }
}
