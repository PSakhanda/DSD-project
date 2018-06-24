using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroBolt.Clients.Dto;
using MicroBolt.Clients.Models;
using MicroBolt.Clients.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MicroBolt.Clients.Web.Controllers
{
    [Route("api/Clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly IMapper mapper;

        public ClientController(IClientService clientService,
            IMapper mapper)
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.clientService.GetMany<GetClientDto>();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await this.clientService.Get<GetClientDto>(id);

            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result);
        }

        // [HttpPost, Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateClientDto dto)
        {
            var model = this.mapper.Map<ClientModel>(dto);
            await this.clientService.Create(model);

            return NoContent();
        }

        // [HttpPut("{id}"), Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CreateOrUpdateClientDto dto)
        {
            var model = this.mapper.Map<ClientModel>(dto);
            model.Id = id;

            await this.clientService.Update(model);

            return NoContent();
        }

        // [HttpDelete("{id}"), Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.clientService.Delete(id);

            return Ok();
        }
    }
}
