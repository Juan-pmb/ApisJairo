using System;
using System.Collections.Generic;

namespace AutentificacionConToken.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Clave { get; set; }
}
