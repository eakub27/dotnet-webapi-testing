using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTesting.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("index/{guessedNumber}")]
        public string Index(int guessedNumber)
        {
           if(guessedNumber<100) return "Wrong! Try a bigger number.";
           else if(guessedNumber > 100) return "Wrong! Try a smaller number.";
           else  return "You guessed Correct Number!";
        }
    }
}
