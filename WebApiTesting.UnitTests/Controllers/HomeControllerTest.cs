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
        public void HomeController_Index_ReturnsWrongMessage_ForHighGuess()
        {
            // Arrange
            var controller = new HomeController();
            int guessedNumber = 120;
            var expected = "Wrong! Try a smaller number.";

            // Act
            var result = controller.Index(guessedNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HomeController_Index_ReturnsWrongMessage_ForLowGuess()
        {
            // Arrange
            var controller = new HomeController();
            int guessedNumber = 80;
            var expected = "Wrong! Try a bigger number.";

            // Act
            var result = controller.Index(guessedNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HomeController_Index_ReturnsCorrectMessage_ForCorrectGuess()
        {
            // Arrange
            var controller = new HomeController();
            int guessedNumber = 100;
            var expected = "You guessed Correct Number!";
            // Act
            var result = controller.Index(guessedNumber);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
