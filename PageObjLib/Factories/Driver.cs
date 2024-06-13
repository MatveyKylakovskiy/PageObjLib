using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PageObjLib.Factories
{
    public static class Driver
    {
        private static IWebDriver? _driver;
        private static WebDriverWait? _wait;
        private static ChromeOptions? _chromeOptions;

        public static WebDriverWait GetWait() => _wait ??= new(_driver, TimeSpan.FromSeconds(60));
        public static IWebDriver GetDriver() => _driver ??= new ChromeDriver(GetOptions());
        public static ChromeOptions GetOptions()
        {
            if (_chromeOptions == null)
            {
                _chromeOptions = new ChromeOptions();
                _chromeOptions.AddArgument("start-maximized");
            }

            return _chromeOptions;
        }
        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
        public static void QuitWait()
        {
            _wait = null;
        }
        public static void DisposeDriver() => _driver?.Dispose();
    }
}