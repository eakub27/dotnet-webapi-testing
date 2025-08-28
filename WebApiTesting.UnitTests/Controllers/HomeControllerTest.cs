using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.APIs.Controllers;

namespace WebApiTesting.UnitTests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsHelloWorld()
        {
            // Arrange
            var controller = new HomeController();
            var expected = "Hello World!";

            // Act
            var result = controller.Index();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
