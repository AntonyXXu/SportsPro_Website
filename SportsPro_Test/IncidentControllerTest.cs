using System;
using Xunit;
using Moq;
using SportsPro.Models;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SportsPro_Test
{
    public class IncidentControllerTest
    {
        [Fact]
        public void List_Returns_ViewAction()
        {
            //Arrange
            var unit = new Mock<ISportsUnitWork>();
            var inc = new Mock<IRepository<Incident>>();
            unit.Setup(r => r.Incidents).Returns(inc.Object);
            var http = new Mock<IHttpContextAccessor>();

            var controller = new IncidentController(unit.Object, http.Object);


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
            var inc = new Mock<IRepository<Incident>>();
            var prod = new Mock<IRepository<Product>>();
            var tech = new Mock<IRepository<Technician>>();
            var cust = new Mock<IRepository<Customer>>();
            unit.Setup(r => r.Incidents).Returns(inc.Object);
            unit.Setup(r => r.Customers).Returns(cust.Object);
            unit.Setup(r => r.Products).Returns(prod.Object);
            unit.Setup(r => r.Technicians).Returns(tech.Object);
            var http = new Mock<IHttpContextAccessor>();

            var controller = new IncidentController(unit.Object, http.Object);


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
            var inc = new Mock<IRepository<Incident>>();
            var prod = new Mock<IRepository<Product>>();
            var tech = new Mock<IRepository<Technician>>();
            var cust = new Mock<IRepository<Customer>>();
            unit.Setup(r => r.Incidents).Returns(inc.Object);
            unit.Setup(r => r.Customers).Returns(cust.Object);
            unit.Setup(r => r.Products).Returns(prod.Object);
            unit.Setup(r => r.Technicians).Returns(tech.Object);
            var http = new Mock<IHttpContextAccessor>();

            var controller = new IncidentController(unit.Object, http.Object);
            int id = 1;

            //Act
            var result = controller.Edit(id);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        //[Fact]
        //public void TechList_Returns_ViewResult()
        //{
        //    //Arrange
        //    var unit = new Mock<ISportsUnitWork>();
        //    var inc = new Mock<IRepository<Incident>>();
        //    var prod = new Mock<IRepository<Product>>();
        //    var tech = new Mock<IRepository<Technician>>();
        //    tech.Setup(t => t.Get(It.IsAny<int>())).Returns(new Technician());
        //    var cust = new Mock<IRepository<Customer>>();
        //    unit.Setup(r => r.Incidents).Returns(inc.Object);
        //    unit.Setup(r => r.Customers).Returns(cust.Object);
        //    unit.Setup(r => r.Products).Returns(prod.Object);
        //    unit.Setup(r => r.Technicians).Returns(tech.Object);
        //    var http = new Mock<IHttpContextAccessor>();
        //    var context = new DefaultHttpContext();
        //    http.Setup(m => m.HttpContext)
        //        .Returns(context);
        //    http.Setup(m => m.HttpContext.Request)
        //        .Returns(context.Request);
        //    http.Setup(m => m.HttpContext.Response)
        //        .Returns(context.Response);
        //    http.Setup(m => m.HttpContext.Request.Cookies)
        //        .Returns(context.Request.Cookies);
        //    http.Setup(m => m.HttpContext.Response.Cookies)
        //        .Returns(context.Response.Cookies);
        //    var controller = new IncidentController(unit.Object, http.Object);
        //    int id = 1;

        //    //Act
        //    var result = controller.TechList(id);

        //    //Assert
        //    Assert.IsType<ViewResult>(result);
        //}

    }
}
