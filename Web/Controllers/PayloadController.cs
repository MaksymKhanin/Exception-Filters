using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayloadController : ControllerBase
    {
        private readonly IPayloadValidationService _validationService;

        public PayloadController(IPayloadValidationService validationService) =>
           (_validationService) = (validationService);


        [HttpPost("{ticketId:guid}/send")]
        public async Task<IActionResult> Send(Guid ticketId, CancellationToken cancellationToken)
        {
            using var payload = new MemoryStream();

            await _validationService.ValidatePayload(payload);

            return Ok();
        }
    }
}
