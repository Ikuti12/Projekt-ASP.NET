using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class Tests
    {
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Repos\molkiewicz\Projekt-ASP.NET\Selenium");
        [Test]
        public void LookElementByName()
        {
            var driver = new FirefoxDriver(service);
            var url = "http://localhost:63418/";
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var text = driver.FindElement(By.Name("Logo")).Text;
                Assert.AreEqual("Rate Your Entertainment",text);
            }catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [Test]
        public void UsernameAfterLogin()
        {
            var driver = new FirefoxDriver(service);
            var url = "http://localhost:63418/Account/Login";
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var usernameField = driver.FindElement(By.Id("UserName"));
                usernameField.Click();
                usernameField.SendKeys("Admin");
                var passwordField = driver.FindElement(By.Id("Password"));
                passwordField.Click();
                passwordField.SendKeys("S3cr3tP@ss");
                var submitButton = driver.FindElement(By.Id("Submit"));
                submitButton.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(UrlToBe("http://localhost:63418/"));
                var welcome = driver.FindElement(By.Id("Welcome")).Text;
                StringAssert.Contains(welcome, "Hi! Admin");
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [Test]
        public void SendFeedbackWorksAfterLogin()
        {
            var driver = new FirefoxDriver(service);
            var url = "http://localhost:63418/Account/Login";
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var usernameField = driver.FindElement(By.Id("UserName"));
                usernameField.Click();
                usernameField.SendKeys("Admin");
                var passwordField = driver.FindElement(By.Id("Password"));
                passwordField.Click();
                passwordField.SendKeys("S3cr3tP@ss");
                var submitButton = driver.FindElement(By.Id("Submit"));
                submitButton.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(UrlToBe("http://localhost:63418/"));
                var feedbackLink = driver.FindElement(By.LinkText("Feedback"));
                feedbackLink.Click();
                var nameField = driver.FindElement(By.Id("Name"));
                nameField.Click();
                nameField.SendKeys("Username");
                var emailField = driver.FindElement(By.Id("Email"));
                emailField.Click();
                emailField.SendKeys("TestTestTest@gmail.com");
                var msgField = driver.FindElement(By.Id("Message"));
                msgField.Click();
                msgField.SendKeys("Message");
                var contactmeField = driver.FindElement(By.Id("ContactMe"));
                contactmeField.Click();
                submitButton = driver.FindElement(By.Id("Submit"));
                submitButton.Click();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(UrlToBe("http://localhost:63418/Feedback/FeedbackComplete"));
                var welcome = driver.FindElementByClassName("special").Text;
                StringAssert.Contains(welcome, "Thank you for your feedback, we take it very seriously!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [Test]
        public void CantSendFeedbackWhenNotLogIn()
        {
            var driver = new FirefoxDriver(service);
            var url = "http://localhost:63418/";
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var feedbackLink = driver.FindElement(By.LinkText("Feedback"));
                feedbackLink.Click();
                var text = driver.FindElementByClassName("special");
                StringAssert.Contains(text.Text, "Before using the website features, you have to log in or register!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [Test]
        public void RegisterWithoutPasswordFail()
        {
            var driver = new FirefoxDriver(service);
            var url = "http://localhost:63418/Account/Register";
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var usernameField = driver.FindElement(By.Id("UserName"));
                usernameField.Click();
                usernameField.SendKeys("UserUserson");
                var passwordField = driver.FindElement(By.Id("Password"));
                passwordField.Click();
                passwordField.SendKeys("");
                var submitButton = driver.FindElement(By.Id("Register"));
                submitButton.Click();
                var registerError = driver.FindElement(By.Id("UserNameError")).Text;
                StringAssert.Contains(registerError, "User name/password not found");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
            public static Func<IWebDriver, bool> UrlToBe(string url)
        {
            return (driver) => { return driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant()); };
        }
    }
}