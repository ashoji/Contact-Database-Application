using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {

        private UserController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new UserController();
//            controller.AddUser(new User { Id = 1, Name = "Test", Email = "test@test.com" });
        }


        [TestMethod]
        public void Index()
        {

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {

            // fix
            controller.Create(new User { Id = 1, Name = "Test", Email = "test@test.com" });
            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            controller.Create(new User { Id = 1, Name = "Test", Email = "test@test.com" });

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            controller.Create(new User { Id = 1, Name = "Test", Email = "test@test.com" });

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
