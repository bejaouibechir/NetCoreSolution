using WebMVCore.Controllers;
using WebMVCore.Models;

namespace WebTestXunit
{
    public class AccountTest
    {
        [Fact]
        public void LoginTest()
        {
            LoginViewModel model = new LoginViewModel
            {
                Login = "admin",
                Password = "admin",
                ConfirmPassword = "admin",
            };
            AccountController controller = new AccountController();
            controller.Login(model);

        }
    }
}