using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    public class CheckoutCompletePage : BasePage
    {
        // Constructor: Llama al constructor de la clase base usando ': base(driver)'
        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
        }

        // --- WebElements (Locators) ---
        // Java: private final By ... By.className()
        // C#:   private readonly By ... By.ClassName()
        private readonly By orderCompleteText = By.ClassName("complete-header");

        // --- Actions/Methods ---
        // Convención C#: PascalCase para el nombre del método y 'string' en minúscula
        public string GetCompleteText()
        {
            // Llama al método GetText heredado de tu BasePage
            return GetText(orderCompleteText);
        }
    }
}
