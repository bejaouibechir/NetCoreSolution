using WebMVCore.Controllers;
using WebMVCore.Models;

namespace WebTestNunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
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

        [Test]
        public void SommeTest()
        {
            int sommetest;
            int sommeattendue = 2;
            
            Calcul calcul = new Calcul
            {
                X = 1,
                Y = 1
            };
            HomeController controller = new HomeController();
            sommetest = controller.Somme(calcul);

            Assert.AreEqual(sommeattendue, sommetest);
        }

        public void Dispose()
        {

        }
   
    }
}