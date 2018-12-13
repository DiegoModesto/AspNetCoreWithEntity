using System.ComponentModel.DataAnnotations;

namespace Khan.Common.ViewModel.Authorization
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
