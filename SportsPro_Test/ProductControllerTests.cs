using System;
using Xunit;
using Moq;
using SportsPro.Models;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace SportsPro_Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void List_Returns_ViewAction()
        {
            //Arrange
            var repo = new Mock<IRepository<Product>>();
            var controller = new ProductController(repo.Object);

            //Act
            var result = controller.List();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_Returns_ViewResult()
        {
            //Arrange
            var repo = new Mock<IRepository<Product>>();
            var controller = new ProductController(repo.Object);

            //Act
            var result = controller.Add();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Edit_Returns_ViewResult()
        {
            //Arrange
            var repo = new Mock<IRepository<Product>>();
            var controller = new ProductController(repo.Object);
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
            var repo = new Mock<IRepository<Product>>();
            var controller = new ProductController(repo.Object);
            controller.ModelState.AddModelError("", "TestError");

            //Act
            var result = controller.Edit( new Product());

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void EditPost_ReturnsActionResult_valid()
        {
            //Arrange
            var repo = new Mock<IRepository<Product>>();
            var controller = new ProductController(repo.Object);
            

            //Act
            var result = controller.Edit(new Product());

            Assert.IsType<ViewResult>(result);
        }
    }
}
