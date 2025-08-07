

namespace DeveloperStore.Common.Security
{
    public interface IJwtTokenGenerator
    {
        string GerarToken(IUsuario usuario);
    }
}
