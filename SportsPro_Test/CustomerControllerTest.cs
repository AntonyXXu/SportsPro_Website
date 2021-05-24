using System;
using Xunit;
using Moq;
using SportsPro.Models;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace SportsPro_Test
{
    public class CustomerControllerTest
    {
        [Fact]
        public void List_Returns_ViewAction()
        {
            //Arrange
            var unit = new Mock<ISportsUnitWork>();
            var custs = new Mock<IRepository<Customer>>();
            unit.Setup(r => r.Customers).Returns(custs.Object);
            var controller = new CustomerController(unit.Object);
            

            //Act
            var result = controller.List();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_Returns_ViewResult()
        {
            //Arrange
            var unit = new Mock<ISportsUnitWork>();
            var custs = new Mock<IRepository<Customer>>();
            var countries = new Mock<IRepository<Country>>();
            unit.Setup(r => r.Customers).Returns(custs.Object);
            unit.Setup(r => r.Countries).Returns(countries.Object);
            var controller = new CustomerController(unit.Object);


            //Act
            var result = controller.Add();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Edit_Returns_ViewResult()
        {
            //Arrange
            var unit = new Mock<ISportsUnitWork>();
            var custs = new Mock<IRepository<Customer>>();
            var countries = new Mock<IRepository<Country>>();
            unit.Setup(r => r.Customers).Returns(custs.Object);
            unit.Setup(r => r.Countries).Returns(countries.Object);
            var controller = new CustomerController(unit.Object);
            int id = 1;

            //Act
            var result = controller.Edit(id);

            //Assert
            Assert.IsType<ViewResult>(result);
        }


    }
}
