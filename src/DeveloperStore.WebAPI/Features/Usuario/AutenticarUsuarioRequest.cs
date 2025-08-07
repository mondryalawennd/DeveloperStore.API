namespace DeveloperStore.WebAPI.Features.Usuario
{
    public class AutenticarUsuarioRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
