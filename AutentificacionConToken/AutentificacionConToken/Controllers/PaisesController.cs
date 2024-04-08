﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutentificacionConToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("Lista")]

        public async Task<ActionResult> Lista()
        {
            var ListaPaises = await Task.FromResult(new List<string> { "Colombia", "Dinamarca","suecia", "Mexico"});
            return Ok(ListaPaises);
        }


    }
}
