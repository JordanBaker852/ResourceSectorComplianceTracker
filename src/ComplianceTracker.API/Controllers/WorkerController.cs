using ComplianceTracker.Application.DTOs;
using ComplianceTracker.Application.Workers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComplianceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController(IMediator mediatr) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDto>>> GetActiveWorkers()
        {
            var response = await mediatr.Send(new GetWorkersQuery());
            return Ok(response.ToList());
        }
    }
}