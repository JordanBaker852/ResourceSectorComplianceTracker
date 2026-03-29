using ComplianceTracker.API.DTOs;
using ComplianceTracker.Application.DTOs;
using ComplianceTracker.Application.Workers.Commands;
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
        public async Task<ActionResult<IEnumerable<WorkerSummaryDto>>> GetActiveWorkers()
        {
            var response = await mediatr.Send(new GetWorkersQuery());
            return Ok(response.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<WorkerSummaryDto>> CreateWorker([FromBody] CreateWorkerRequest request)
        {
            var response = await mediatr.Send(new CreateWorkerCommand(
                request.FirstName,
                request.Surname,
                request.JobTitle,
                request.SiteId
            ));

            return Ok(response);
        }
    }
}