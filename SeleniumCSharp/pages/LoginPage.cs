using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    public class LoginPage : BasePage
    {
        // Constructor heredando de BasePage
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // --- Web Elements de la LoginPage ---
        // 'final' -> 'readonly'
        // By.id -> By.Id, By.xpath -> By.XPath
        private readonly By userNameInput = By.Id("user-name");
        private readonly By passwordInput = By.Id("password");
        private readonly By loginBtn = By.Id("login-button");
        private readonly By errorContainer = By.XPath("//*[@data-test = 'error']");

        // --- Los metodos de la LoginPage ---

        // Convención C#: PascalCase (Mayúscula inicial), 'String' -> 'string'
        public void Login(string username, string password)
        {
            // Llama a los métodos encapsulados en tu BasePage
            Type(userNameInput, username);
            Type(passwordInput, password);
            Click(loginBtn);
        }

        public string GetErrorMessage()
        {
            return GetText(errorContainer);
        }

        public string GetLoginUrl()
        {
            return GetCurrentUrl();
        }
    }
}
