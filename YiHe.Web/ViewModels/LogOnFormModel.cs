using System.ComponentModel.DataAnnotations;


namespace YiHe.Web.ViewModels
{
    public class LogOnFormModel
    {
        [Required(ErrorMessage = "请输入用户名")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }
    }
}