using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoTests.Driver
{
    public class DriverFactory
    {
        public static TimeSpan DefaultImplicitWait = TimeSpan.FromSeconds(4); //let's make it faster, actual default is 3s.
        public static TimeSpan DefaultPageLoadWait = TimeSpan.FromSeconds(4); //let's make it faster, actual default is 3s.

        private static DriverFactory instance;
        private IWebDriver driver;


        private DriverFactory()
        {
        }

        public static DriverFactory Instance => instance ?? (instance = new DriverFactory());

        public IWebDriver getDriver()
        {
            if (this.driver == null)
            {

                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                driver = new ChromeDriver(chromeOptions);
                driver.Manage().Timeouts().PageLoad = DefaultPageLoadWait;
                driver.Manage().Timeouts().ImplicitWait = DefaultImplicitWait;
                return driver;
            }
            else
            {
                return driver;
            }
        }

        public void setDriverNull()
        {
            this.driver = null;
        }

        public static void StopDriver()
        {
            IWebDriver driverSession = Instance.getDriver();
            try
            {
                driverSession?.Close();
            }
            catch (Exception)
            {
                // do nothing
            }
            try
            {
                driverSession?.Quit();
            }
            catch (Exception)
            {
                // do nothing
            }
            Instance.setDriverNull();
        }
    }
}