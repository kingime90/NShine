using NShine.Core.Valid;

namespace WebApp.Demo.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginModel : ModelValid<UserLoginModel>
    {
        public UserLoginModel()
        {
            StringType(s => s.Username).SetRequired();
            StringType(s => s.Password).SetRequired().SetMinLength(6);
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}