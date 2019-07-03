using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender.lib.Service;

namespace MailSender.Lib.Tests.Service
{
    /// <summary> Класс модулных тестов для StringEncryptor </summary>
    [TestClass]
    public class StringEncryptorTests
    {
        public StringEncryptorTests()
        {
            // TODO: добавьте здесь логику конструктора
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void EncriptMethod_On_ASD_Return_BTE_WithKey_1()
        {
            // AAA
            // Arrange
            const string str = "ASD";
            const string expected_result = "BTE";
            const int key = 1;

            // Act
            var actual_result = MailSender.lib.Service.StringEncryptor.Encrypt(str, key);

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void DecriptMethod_On_BTE_Return_ASD_WithKey_1()
        {
            // AAA
            // Arrange
            const string str = "BTE";
            const string expected_result = "ASD";
            const int key = 1;

            // Act
            var actual_result = MailSender.lib.Service.StringEncryptor.Decrypt(str, key);

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

    }
}
