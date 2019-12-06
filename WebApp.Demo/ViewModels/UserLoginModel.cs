using System.Web.Http.ModelBinding;

namespace WebApp.Demo.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginModel
    {
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