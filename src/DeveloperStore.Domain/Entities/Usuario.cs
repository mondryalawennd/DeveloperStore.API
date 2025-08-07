using DeveloperStore.Common.Security;
using DeveloperStore.Common.Validation;
using DeveloperStore.Domain.Common;
using DeveloperStore.Domain.Enum;
using DeveloperStore.Domain.Validator;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace DeveloperStore.Domain.Entities
{
    public class Usuario : BaseEntity, IUsuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public UsuarioStatus Papel { get; set; }
        public string Password { get; set; } = string.Empty;
        public UsuarioStatus Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        string IUsuario.Id => Id.ToString();

        string IUsuario.Nome => Nome;

        string IUsuario.Papel => Papel.ToString();

        public Usuario()
        {
            DataCriacao = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UsuarioValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Ativo()
        {
            Status = UsuarioStatus.Ativo;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void Desativado()
        {
            Status = UsuarioStatus.Desconhecido;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void Suspenso()
        {
            Status = UsuarioStatus.Suspenso;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
    }