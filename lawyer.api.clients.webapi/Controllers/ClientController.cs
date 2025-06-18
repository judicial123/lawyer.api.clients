using lawyer.api.clients.application.DTO;
using lawyer.api.clients.application.UseCases.Client.Get;
using lawyer.api.clients.application.UseCases.Client.Create;
using lawyer.api.clients.application.UseCases.Client.Update;
using lawyer.api.clients.application.UseCases.Client.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace lawyer.api.clients.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> Get()
        {
            var clients = await _mediator.Send(new GetClientsQuery());
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> Get(int id)
        {
            var client = await _mediator.Send(new GetClientQuery(id));
            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody] CreateClientCommand command)
        {
            var id = await _mediator.Send(command);
            var url = Url.Action(nameof(Get), new { id });
            return Created(url, id);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Put([FromBody] UpdateClientCommand command)
        {
            if (command.Id <= 0)
                return BadRequest("The provided ID is not valid.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteClientCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}