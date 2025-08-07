namespace DeveloperStore.WebAPI.Features.Usuario
{
    public class AutenticarUsuarioResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Papel { get; set; } = string.Empty;
    }
}
