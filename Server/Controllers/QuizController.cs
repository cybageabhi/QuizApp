using Microsoft.AspNetCore.Mvc;
using IrepoQuizAppp.Model;
using IrepoQuizAppp.Services;
using IrepoQuizAppp.Factories;

namespace IrepoQuizAppp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly RepositoryFactory _repositoryFactory;

        public QuizController(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("GetQuestions")]
        public async Task<IActionResult> GetQuestions([FromQuery] string dataSource)
        {
            try
            {
               
                var repository = _repositoryFactory.CreateRepository<QuizQuestion>(dataSource);
                var questions = await repository.GetAllAsync();
                return Ok(questions);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
