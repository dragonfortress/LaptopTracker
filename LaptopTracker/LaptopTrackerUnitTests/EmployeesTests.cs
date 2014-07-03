using System;
using System.Web.Mvc;
using LaptopTracker.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LaptopTrackerUnitTests
{
    [TestClass]
    public class EmployeesTests
    {
        [TestMethod]
        public void EmployeesControllerExistence()
        {
            var controller = new EmployeesController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
