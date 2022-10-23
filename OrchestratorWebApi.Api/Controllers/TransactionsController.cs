using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrchestratorWebApi.Application.UseCases.GetTransactions;

namespace OrchestratorWebApi.Controllers;

[ApiController]
[Route("v1/transactions")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet(Name = "GetTransactions")]
    public async Task<IActionResult> Get([FromQuery(Name = "user-identity-id")] string userIdentityId,
        [FromQuery(Name = "from-date")] string fromDate,
        [FromQuery(Name = "to-date")] string toDate,
        CancellationToken cancellationToken)
    {
        var request = new GetTransactionsQuery
        {
            FromDate = DateOnly.Parse(fromDate),
            ToDate = DateOnly.Parse(toDate),
            UserIdentityId = userIdentityId
        };
        var response = await _mediator.Send(request, cancellationToken);
        return new OkObjectResult(response);
    }
}