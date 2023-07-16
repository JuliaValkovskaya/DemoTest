using System;

namespace TestWebClient
{
    public class LoginPage
    {
        public string userName => ".//*[@id='login_user']";
        public string password => ".//*[@id='login_pass']";
        public string login => ".//*[@id='login_button']";



        public LoginPage()
        { 
        }

        public LoginPage(string user, string password)
        {
            DriverFactory.Instance.getDriver();
        }

        public void LoginWithUser(string username, string password)
        {
            
        }
    }
}
