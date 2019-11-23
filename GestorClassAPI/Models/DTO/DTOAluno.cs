using System;
using System.ComponentModel.DataAnnotations;

namespace GestorClassAPI.Models.DTO
{
    public class DTOAluno
    {
        [Key]
        public int Id { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "O nome do aluno é requerido.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        #endregion
        public string Nome { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "A data de nascimento do aluno é requerido.")]
        #endregion
        public DateTime Data_Nascimento { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "O email do aluno é requerido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        #endregion
        public string Email { get; set; }
    }
}