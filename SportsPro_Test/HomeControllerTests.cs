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
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
