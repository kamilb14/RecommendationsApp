using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RecommendationsApp;

namespace RecommendationsApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginFormTest()
        {
            //Arrange
            LoginForm lg = new LoginForm();
            int i = 2;

            //Assert
            Assert.ThrowsException<ArgumentException>(() => lg.CheckEmail(i));
        }

        [TestMethod]
        public void RegistrationFormTest() 
        {
            //Arrange
            Registration rg = new Registration();
            string i = "Действие";

            //Assert
            Assert.AreEqual(rg.SelectedItemChange(i), 2);

        }

        [TestMethod]
        public void EmailFormTest() 
        {
            //Arrange
            Registration rg = new Registration();
            string str = null;

            //Assert
            Assert.ThrowsException<ArgumentException>(() => rg.Email(str));
        }

        [TestMethod]
        public void LoginFormTest_2()
        {
            //Arrange
            LoginForm lg = new LoginForm();
            string str = null;

            //Arrange
            Assert.ThrowsException<ArgumentException>(() => lg.Email(str));
        }

        public void LoginFormTest_3()
        {
            //Arrange
            LoginForm lg = new LoginForm();
            string str = null;

            //Arrange
            Assert.ThrowsException<ArgumentException>(() => lg.Password(str));
        }
    }
}
