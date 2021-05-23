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

       
        
    }
}
