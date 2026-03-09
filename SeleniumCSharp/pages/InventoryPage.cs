using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    public class InventoryPage : BasePage
    {
        // Constructor heredando con ': base(driver)'
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        // --- WebElements (Locators) ---
        // 'final' -> 'readonly'
        // By.className -> By.ClassName
        // By.id -> By.Id
        // By.xpath -> By.XPath
        private readonly By prodLabel = By.ClassName("title");
        private readonly By burgerManu = By.Id("react-burger-menu-btn");
        private readonly By addBackPack = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By removeBackPack = By.Id("remove-sauce-labs-backpack");
        private readonly By cardBadgeCounter = By.ClassName("shopping_cart_badge");
        private readonly By firstProd = By.ClassName("inventory_item_name");
        private readonly By firstProdDetails = By.XPath("//*[@data-test = 'inventory-item-desc']");
        private readonly By shoppingCart = By.ClassName("shopping_cart_link");

        // --- Methods/Actions ---
        // Métodos en PascalCase, 'String' -> 'string', 'boolean' -> 'bool'

        public string GetTitleText()
        {
            return GetText(prodLabel);
        }

        public void ClickBurgerManu() // Nota: dejé "Manu" como estaba en tu código original, pero podrías cambiarlo a Menu
        {
            Click(burgerManu);
        }

        public void ClickAddBackPack()
        {
            Click(addBackPack);
        }

        public string GetBadgeCounter()
        {
            return GetText(cardBadgeCounter);
        }

        public void ClickRemoveBackPack()
        {
            Click(removeBackPack);
        }

        public bool IsBadgeCounterVisible()
        {
            return IsElementDisplayed(cardBadgeCounter);
        }

        public void ClickFirstProd()
        {
            Click(firstProd);
        }

        public string GetFirstProdText()
        {
            return GetText(firstProdDetails);
        }

        public void ClickShoppingCart()
        {
            Click(shoppingCart);
        }
    }
}
