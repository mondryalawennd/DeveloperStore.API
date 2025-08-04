
using System;

namespace DeveloperStore.Common.Security
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Cria hash de uma senha em texto simples usando o algoritmo BCrypt.
        /// </summary>
        /// <param name="password">A senha em texto simples para hash.</param>
        /// <returns>a senha com hash do BCrypt.</returns>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifica se uma senha de texto simples corresponde a uma senha com hash do BCrypt.
        /// </summary>
        /// <param name="password">A senha em texto simples para verificar.</param>
        /// <param name="hash">A senha com hash do BCrypt para comparação.</param>
        /// <returns>Verdadeiro se a senha corresponder ao hash, falso caso contrário.</returns>
        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}