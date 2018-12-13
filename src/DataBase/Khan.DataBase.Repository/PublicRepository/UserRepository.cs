using System;
using System.Linq;
using Khan.Common.Entities;
using Khan.Common.Extensions;
using Khan.DataBase.Repository.Interfaces;
using Khan.EntityFrameworkCore;

namespace Khan.DataBase.Repository.PublicRepository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        #region [Properties]
        public Khontext Khontext
        {
            get { return _context as Khontext; }
        }

        public UserRepository(Khontext context) : base(context) { }
        #endregion

        #region [Methods]
        public bool CheckUserExistByName(string name)
        {
            return Khontext.Users.FirstOrDefault(x => x.FirstName.ClearAccent().PhaseLike(name)) != null;
        }

        public bool CheckUserIsACtive(Guid Id)
        {
            return Khontext.Users.Find(Id).Active;
        }
        #endregion
    }
}
