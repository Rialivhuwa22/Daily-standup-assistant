using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    // This attribute marks this class as a Web API controller
    [ApiController]
    
    // This sets the URL route for this controller; e.g., "api/report"
    [Route("api/[controller]")]
    
    public class ReportController : ControllerBase
    {
        // Holds an instance of the ParaphrasingServices class to use in this controller
        private readonly ParaphrasingServices _paraphrasingService;

        // Constructor receives the ParaphrasingServices via dependency injection and stores it
        public ReportController(ParaphrasingServices paraphrasingService)
        {
            _paraphrasingService = paraphrasingService;
        }
        /// This method handles POST requests sent to "api/report"
        [HttpPost]
        public async Task<IActionResult> GenerateReport([FromBody] NotesInput input)
        {
            //check if the input notes are empty or only spaces
            if (string.IsNullOrWhiteSpace(input.Notes))
                //Return a 400 Bad request response if notes are empty
                return BadRequest("Notes cannot be empty.");

            //call the paraphrasing service asynchronously to rewrite the notes 
            var result = await _paraphrasingService.ParaphraseAsync(input.Notes);
            
            // Return a 200 OK response with the paraphrased report wrapped in an object
            return Ok(new { generatedReport = result });
        }
    }
}