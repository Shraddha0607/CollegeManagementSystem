using CollegeApp.Exceptions;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepo repo;
    private readonly ILogger logger;

    public TransactionController(ITransactionRepo repo,
        ILogger<TransactionController> logger)
    {
        this.repo = repo;
        this.logger = logger;
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var transaction = await repo.GetByIdAsync(id);
            return Ok(transaction);
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
            return BadRequest("Error Occured while getting transaction!");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] TransactionRequest transactionRequest)
    {
        try
        {
            var response = await repo.AddAsync(transactionRequest);
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
            return BadRequest("Error Occured while getting transaction!");
        }
    }
}