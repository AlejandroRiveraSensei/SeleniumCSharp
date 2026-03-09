using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    // Usamos los dos puntos ':' para heredar de BasePage
    public class CartPage : BasePage
    {
        // El llamado a super(driver) en C# se hace con : base(driver) en la firma
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        // --- WebElements (Locators) ---
        // Java: private final By ...
        // C#:   private readonly By ...
        private readonly By checkoutButton = By.Id("checkout");

        // --- Actions/Methods ---
        public void ClickCheckoutButton()
        {
            // Llamamos al método Click() heredado de BasePage (que ya maneja los waits)
            Click(checkoutButton);
        }
    }
}
