using SeleniumCSharp.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.Tests.pom
{
    [TestClass] // Obligatorio en MSTest
    public class LoginTests : BaseTest // Heredamos de BaseTest (donde está el Setup y las páginas)
    {
        // En TestNG: @Test(groups = "e2e")
        // En MSTest: [TestMethod] + [TestCategory("e2e")]
        [TestMethod]
        [TestCategory("e2e")]
        public void LoginBlocked()
        {
            // Step 1: Login
            login.Login("locked_out_user", "secret_sauce");

            // Validacion (C# usa PascalCase para los métodos y .Contains funciona igual)
            Assert.IsTrue(login.GetErrorMessage().Contains("this user has been locked out"));
        }

        [TestMethod]
        public void IncorrectLogin()
        {
            // Step 1: Login
            login.Login("incorrect_user", "secret_sauce");

            // Validacion (Recuerda: MSTest es Esperado, Actual)
            string expectedError = "Epic sadface: Username and password do not match any user in this service";
            Assert.AreEqual(expectedError, login.GetErrorMessage());
        }

        [TestMethod]
        public void LoginSuccess()
        {
            // Asumiendo que UserData es una clase utilitaria tuya con métodos estáticos
            login.Login(UserData.GetUserName("standard"), UserData.GetPassword("standard"));

            Assert.AreEqual("Products", inventory.GetTitleText());
        }

        [TestMethod]
        public void EmptyLogin()
        {
            login.Login("", "");

            Assert.AreEqual("Epic sadface: Username is required", login.GetErrorMessage());
            Assert.IsTrue(login.GetErrorMessage().Contains("Username is required"));
        }

        [TestMethod]
        public void Logout()
        {
            // Step 1: Login
            login.Login("standard_user", "secret_sauce");

            // Step 2: Click en burger menu
            inventory.ClickBurgerManu();

            // Step 3: Click en logout
            menu.ClickAbout();
            menu.ClickLogout();

            // Verification
            Assert.AreEqual("https://www.saucedemo.com/", login.GetLoginUrl());
        }
    }
}
