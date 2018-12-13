using AutoMapper;
using Khan.Common.ViewModel;
using Khan.Common.ViewModel.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Khan.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;

        #region ViewModels
        public LoginViewModel _userPasswordVM;
        #endregion

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel value)
        {
            
            return Ok();
        }
    }
}