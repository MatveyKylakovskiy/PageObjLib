using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjLib.Factories;
using SeleniumExtras.WaitHelpers;

namespace PageObjLib.Pages
{
    public static class Page
    {
        private static Actions? _action;

        public static void GoUrl(string url) => Driver.GetDriver().Navigate().GoToUrl(url);
        public static IWebElement GetElement(By locator)
        {
            return Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static List<IWebElement> GetListOfElements(By locator)
        {
            return Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).ToList();

        }
        public static Dictionary<string, IWebElement> GetDictionaryOfElements(By locator)
        {
            var elements = Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).DistinctBy(a => a.Text).ToList();
            return elements.ToDictionary(p => p.Text, p => p);
        }
        public static Actions GetActions() => _action ??= new Actions(Driver.GetDriver());
        public static void QuitActions()
        {
            _action = null;
        }
    }
}