using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroBolt.Stock.Bolts.Dto;
using MicroBolt.Stock.Models;
using MicroBolt.Stock.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBolt.Stock.Web.Controllers
{
    [Route("api/Bolts")]
    public class BoltsController : Controller
    {
        private readonly IBoltService boltService;
        private readonly IMapper mapper;

        public BoltsController(IBoltService boltService,
            IMapper mapper)
        {
            this.boltService = boltService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await this.boltService.Get<GetBoltDto>(id);

            return Ok(result);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateBoltDto dto)
        {
            var model = this.mapper.Map<BoltModel>(dto);
            await this.boltService.Create(model);

            return NoContent();
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Update(string id, [FromBody] CreateOrUpdateBoltDto dto)
        {
            var model = this.mapper.Map<BoltModel>(dto);
            model.Id = id;

            await this.boltService.Update(model);

            return NoContent();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            await this.boltService.Delete(id);

            return Ok();
        }
    }
}