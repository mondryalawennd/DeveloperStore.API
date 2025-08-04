using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Common.Security
{
    public interface IPasswordHasher
    {
        /// <summary>
        /// Cria hash de uma senha em texto simples usando um algoritmo de hash seguro.
        /// </summary>
        /// <param name="password">A senha em texto simples para hash.</param>
        /// <returns>A senha com hash.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifica se uma senha em texto simples corresponde a uma senha com hash.
        /// </summary>
        /// <param name="password">A senha em texto simples para verificar.</param>
        /// <param name="hash">A senha com hash para comparação.</param>
        /// <returns>Verdadeiro se a senha corresponder ao hash, falso caso contrário.</returns>
        bool VerifyPassword(string password, string hash);
    }
}