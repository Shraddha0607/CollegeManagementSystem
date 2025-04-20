using CollegeApp.Exceptions;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;
using CollegeApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo repo;
        private readonly ILogger logger;

        public DepartmentController(IDepartmentRepo repo, ILogger<DepartmentController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        public ILogger<DepartmentController> Logger { get; }

        [HttpPost]
        public async Task<ActionResult> Add(DepartmentRequest departmentRequest)
        {
            try
            {
                var response = await repo.AddAsync(departmentRequest);
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
                return BadRequest(ex.Message);
            }
        }
    }
}
