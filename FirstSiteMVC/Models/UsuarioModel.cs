using FirstSiteMVC.Enums;
using FirstSiteMVC.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSiteMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do usuário.")]
        [EmailAddress(ErrorMessage ="O e-mail não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário.")]
        public PerfilEnum? Perfil { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; } // ? => informa que campo pode ser nulo

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();

            return novaSenha;
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
