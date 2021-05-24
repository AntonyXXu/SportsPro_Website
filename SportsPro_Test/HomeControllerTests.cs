using System;
using Xunit;
using Moq;
using SportsPro.Models;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SportsPro_Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_ViewAction()
        {
            //Arrange
            var controller = new HomeController(); 

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_Returns_ViewAction()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.About();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
