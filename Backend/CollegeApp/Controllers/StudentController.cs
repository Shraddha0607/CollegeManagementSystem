using CollegeApp.Exceptions;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using CollegeApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo repo;
        private readonly ILogger logger;

        public StudentController(IStudentRepo repo, ILogger<StudentController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var student = await repo.GetByIdAsync(id);
                return Ok(student);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StudentRequest studentRequest)
        {
            try
            {
                var response = await repo.AddAsync(studentRequest);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = "Error Occured!" });
            }
        }

        [HttpGet("/topFive")]
        public async Task<ActionResult> GetTopFive()
        {
            try
            {
                var students = await repo.GetTopFive();
                return Ok(students);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = "Error Occurred!" });
            }
        }

        [HttpPost("/addMarks")]
        public async Task<ActionResult> AddMarks([FromQuery] int studentId, [FromQuery] double percentage)
        {
            try
            {
                var response = await repo.AddMarks(studentId, percentage);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = "Error Occurred!" });
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var students = await repo.GetAllAsync();
                return Ok(students);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = "Error Occured!" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var response = await repo.DeleteAsync(id);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = "Error Occured!" });
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] StudentRequest studentRequest)
        {
            try
            {
                var response = await repo.UpdateAsync(studentRequest);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = "Error Occured!" });
            }
        }
    }
}