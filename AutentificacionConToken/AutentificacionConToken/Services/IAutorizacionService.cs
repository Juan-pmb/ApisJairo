using AutentificacionConToken.Models.Customs;

namespace AutentificacionConToken.Services
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);
    }
}
