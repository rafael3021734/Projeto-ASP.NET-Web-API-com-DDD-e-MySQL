using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo{1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é campo Obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo{1} caracteres.")]
        public string Email { get; set; }
    }
}
