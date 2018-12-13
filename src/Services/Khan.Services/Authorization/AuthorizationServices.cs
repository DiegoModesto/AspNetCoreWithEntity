using Khan.Common.ViewModel.Authorization;
using Khan.EntityFrameworkCore;
using Khan.Services.Interfaces;
using System;

namespace Khan.Services.Authorization
{
    public class AuthorizationServices : IAuthorizationServices
    {
        #region Constructor and Properties
        

        public AuthorizationServices()
        {
            
        }
        #endregion

        public LoginViewModel LoginUser(LoginViewModel model)
        {
            //Verifica usuário existente

            //Verifica senha de usuário

            //Verifica validade e/ou anormalidades

            //Buscar ROLES de usuário
            throw new NotImplementedException();
        }

        public LoginViewModel LoginUserAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public void LogofUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dispose this class after use.
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
