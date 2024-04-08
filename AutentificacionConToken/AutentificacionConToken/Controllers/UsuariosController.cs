using AutentificacionConToken.Models.Customs;
using AutentificacionConToken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutentificacionConToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;

        public UsuariosController(IAutorizacionService autorizacionService)
        {
            _autorizacionService = autorizacionService;
        }
        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar( [FromBody]AutorizacionRequest autorizacion)
         {
            var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);
            if(resultado_autorizacion == null)
                return Unauthorized();
            return Ok(resultado_autorizacion);
        }
    }
}
