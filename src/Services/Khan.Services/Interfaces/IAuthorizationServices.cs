using Khan.Common.ViewModel.Authorization;
using System;

namespace Khan.Services.Interfaces
{
    public interface IAuthorizationServices : IDisposable
    {
        LoginViewModel LoginUser(LoginViewModel model);
        LoginViewModel LoginUserAsync(LoginViewModel model);

        void LogofUser();
    }
}
