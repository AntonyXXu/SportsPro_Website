using System;
using Xunit;
using Moq;
using SportsPro.Models;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace SportsPro_Test
{
    public class TechnicianControllerTest
    {
        [Fact]
        public void List_Returns_ViewAction()
        {
            //Arrange
            var repo = new Mock<IRepository<Technician>>();
            var controller = new TechnicianController(repo.Object);

            //Act
            var result = controller.List();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_Returns_ViewResult()
        {
            //Arrange
            var repo = new Mock<IRepository<Technician>>();
            var controller = new TechnicianController(repo.Object);

            //Act
            var result = controller.Add();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Edit_Returns_ViewResult()
        {
            //Arrange
            var repo = new Mock<IRepository<Technician>>();
            var controller = new TechnicianController(repo.Object);
            int id = 1;

            //Act
            var result = controller.Edit(id);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditPost_ReturnsViewResult_Invalid()
        {
            //Arrange
            var repo = new Mock<IRepository<Technician>>();
            var controller = new TechnicianController(repo.Object);
            controller.ModelState.AddModelError("", "TestError");
            int test = 1;

            //Act
            var result = controller.Edit( test);

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void EditPost_ReturnsActionResult_valid()
        {
            //Arrange
            var repo = new Mock<IRepository<Technician>>();
            var controller = new TechnicianController(repo.Object);
            int test = 1;

            //Act
            var result = controller.Edit(test);

            Assert.IsType<ViewResult>(result);
        }
    }
}
