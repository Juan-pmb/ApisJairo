using AutentificacionConToken.Models;
using AutentificacionConToken.Models.Customs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutentificacionConToken.Services
{
    public class AutorizacionServices : IAutorizacionService
    {
        private readonly DbpruebaContext _context;
        private readonly IConfiguration _configuration;

        public AutorizacionServices(DbpruebaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Task<AutorizacionResponse>DevolverToken(AutorizacionResponse autorizacion) {
            throw new NotImplementedException();
        }


        private string GenerarToken (string IdUsuario)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes (key);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, IdUsuario));
            var credenciallesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256
                );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires= DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credenciallesToken
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;
        }

        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var usuario_encontrado = _context.Usuarios.FirstOrDefault(x => 
            x.NombreUsuario == autorizacion.NombreUsuario && 
            x.Clave == autorizacion.Clave);
            if(usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);
            }
            string tokenCreado = GenerarToken(usuario_encontrado.Idusuario.ToString());
            return new AutorizacionResponse() { Token = tokenCreado,Resultado=true, Mensaje="OK" };
        }
    }

}
