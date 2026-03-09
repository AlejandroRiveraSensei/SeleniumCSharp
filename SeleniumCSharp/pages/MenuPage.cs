using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    public class MenuPage : BasePage
    {
        // Constructor heredando de BasePage
        public MenuPage(IWebDriver driver) : base(driver)
        {
        }

        // --- WebElements (Locators) ---
        // 'final' -> 'readonly'
        // By.xpath -> By.XPath, By.id -> By.Id
        private readonly By logoutLink = By.XPath("//*[@data-test = 'about-sidebar-link']/following::a");
        private readonly By aboutLink = By.Id("about_sidebar_link");

        // --- Methods/Actions de MenuPage ---

        // Convención C#: PascalCase (Mayúscula inicial)
        public void ClickLogout()
        {
            // Llama al método Click heredado de BasePage
            Click(logoutLink);
        }

        public void ClickAbout()
        {
            Click(aboutLink);
        }
    }
}
