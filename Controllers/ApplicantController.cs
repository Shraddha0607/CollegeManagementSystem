using AutoMapper;
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
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepo repo;
        private readonly ILogger logger;

        public ApplicantController(IApplicantRepo repo, ILogger<ApplicantController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> add([FromBody] ApplicantRequest request)
        {
            try
            {
                var response = await repo.AddAsync(request);
                return Ok(response);
            }
            catch(CustomException ex){
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError("Error occured!");
                return BadRequest(new MessageResponse { Message = "Error occured!" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var applicants = await repo.GetAllAsync();
                return Ok(applicants);
            }
            catch(CustomException ex){
                logger.LogError(ex.StackTrace);
                logger.LogError(ex.Message);
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                logger.LogError("Error occured!");
                return BadRequest(new MessageResponse { Message = "Error occured!" });
            }
        }
    }
}