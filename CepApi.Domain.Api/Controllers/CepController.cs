﻿using CepApi.Domain.Api.Utils;
using CepApi.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace CepApi.Domain.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly HttpConnection _connection;
        private readonly IDistributedCache _distributedCache;

        public CepController(HttpConnection connection, IDistributedCache distributed)
        {
            _connection = connection;
            _distributedCache = distributed;
        }

        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult<GenericCommandResult>> GetCep([FromBody] CepSearchCommand command)
        {
            var cacheKey = $"cep_${command.Cep}";
            var cachedCep = await _distributedCache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedCep))
            {
                return Ok(new GenericCommandResult("Returned from cache", cachedCep, true));
            }

            var cep = await _connection.GetAsync($"/ws/{command.Cep}/json");

            await _distributedCache.SetStringAsync(cacheKey, cep, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return Ok(new GenericCommandResult("Returned from api", cep, true));
        }
    }
}
