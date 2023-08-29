using Microsoft.AspNetCore.Mvc;

namespace Week35.Controllers

{
    [ApiController]
    public class apiController : ControllerBase
    {
        [Route("/api/feed")]
        [HttpGet]
        public IActionResult getFeed()
        {
            return Ok("OK");            
        }

        [Route("/api/articles")]
        [HttpGet]
        public IActionResult getArticles()
        {
            return Ok("OK");
        }

        [Route("/api/articles")]
        [HttpPost]
        public IActionResult setArticles()
        {
            return Ok("OK");
        }

    }
}
