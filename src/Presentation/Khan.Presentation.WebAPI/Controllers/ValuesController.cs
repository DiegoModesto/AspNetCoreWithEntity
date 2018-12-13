using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AutoMapper;
using Khan.Common.ViewModel.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khan.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /*private readonly IMapper _mapper;
        private readonly LoginViewModel _userPasswordVM;

        public ValuesController(IMapper mapper)
        {
            this._mapper = mapper;

            this._userPasswordVM = new LoginViewModel()
            {
                UserName = "Diego",
                Password = "Teste",
                RememberMe = false
            };
        }

        // GET api/values
        [HttpGet]
        public ActionResult<LoginViewModel> Get()
        {
            return _mapper.Map<LoginViewModel>(_userPasswordVM);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var teste = new LoginViewModel() { UserName = id.ToString() };
            var mapeado = this._mapper.Map<LoginViewModel>(teste);

            return "value";
        }*/

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
