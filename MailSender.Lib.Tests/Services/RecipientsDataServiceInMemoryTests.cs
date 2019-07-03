using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.Lib.Tests.Services
{
    /// <summary>
    /// Сводное описание для RecipientsDataServiceInMemoryTests
    /// </summary>
    [TestClass]
    public class RecipientsDataServiceInMemoryTests
    {
        public RecipientsDataServiceInMemoryTests()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
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
        public void GetById_On_Id_2()
        {
            // Arrange
            RecipientsDataServiceInMemory recipientsDataServiceInMemory = new RecipientsDataServiceInMemory();
            Recipient expected_result = new Recipient { Id = 2, Name = "Petrov", Address = "petrov@server.net", Description = "" };
            int id = 2;

            // Act
            var actual_result = recipientsDataServiceInMemory.GetById(id);

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void Create_On_NewRecipient()
        {
            // Arrange
            RecipientsDataServiceInMemory recipientsDataServiceInMemory = new RecipientsDataServiceInMemory();
            
            List<Recipient> expected_result = new List<Recipient>
            {
                new Recipient {Id = 1, Name = "Ivanov", Address = "ivanov@server.net", Description = ""},
                new Recipient {Id = 2, Name = "Petrov", Address = "petrov@server.net", Description = ""},
                new Recipient {Id = 3, Name = "Sidorov", Address = "sidorov@server.net", Description = ""},
                new Recipient {Id = 4, Name = "Pupkin", Address = "pupkin@server.net", Description = ""},
            };

            Recipient newRecipient = new Recipient { Id = 4, Name = "Pupkin", Address = "pupkin@server.net", Description = "" };

            // Act
            recipientsDataServiceInMemory.Create(newRecipient);
            List<Recipient> actual_result = new List<Recipient>();
            actual_result.AddRange(recipientsDataServiceInMemory.GetAll());

            // Assert
            CollectionAssert.AreEqual(expected_result, actual_result);
        }
    }
}
