using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    public class CheckoutPage : BasePage
    {
        // Constructor con herencia (: base)
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        // --- WebElements (Locators) ---
        // 'final' en Java -> 'readonly' en C#
        // By.id -> By.Id
        private readonly By firstNameInput = By.Id("first-name");
        private readonly By lastNameInput = By.Id("last-name");
        private readonly By postalCodeInput = By.Id("postal-code");
        private readonly By continueBtn = By.Id("continue");
        private readonly By finishBtn = By.Id("finish");

        // --- Actions/Methods ---
        // Convención C#: Métodos en PascalCase (Mayúscula inicial), 'String' -> 'string'
        public void FillCheckOut(string name, string lastname, string postalCode)
        {
            // Usamos el método Type() heredado de BasePage
            Type(firstNameInput, name);
            Type(lastNameInput, lastname);
            Type(postalCodeInput, postalCode);
        }

        public void ClickContinue()
        {
            Click(continueBtn);
        }

        public void ClickFinishBtn()
        {
            Click(finishBtn);
        }
    }
}
