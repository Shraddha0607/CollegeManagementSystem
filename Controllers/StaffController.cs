using CollegeApp.Exceptions;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using CollegeApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepo repo;
        private readonly ILogger logger;

        public StaffController(IStaffRepo repo, ILogger<StaffController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet("/get/{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var staff = await repo.GetByIdAsync(id);
                return Ok(staff);
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
                return BadRequest("Error Occurred!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StaffRequest staffRequest)
        {
            try
            {
                var response = await repo.AddAsync(staffRequest);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest("Error Occurred!");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var staffs = await repo.GetAllAsync();
                return Ok(staffs);
            }
            catch (CustomException ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest("Error Occurred!");
            }
        }
    }
}