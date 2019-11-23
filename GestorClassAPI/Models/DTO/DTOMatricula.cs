using System;
using System.ComponentModel.DataAnnotations;

namespace GestorClassAPI.Models.DTO
{
    public class DTOMatricula
    {
        [Key]
        public int Id { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "O curso da matrícula é requerido.")]
        [StringLength(100, ErrorMessage = "O curso deve ter no máximo 60 caracteres.")]
        #endregion
        public string Curso { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "A série da matrícula é requerida.")]
        [StringLength(10, ErrorMessage = "A série deve ter no máximo 10 caracteres.")]
        #endregion
        public string Serie { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "A turma da matrícula é requerida.")]
        [StringLength(100, ErrorMessage = "A turma da matrícula deve ter no máximo 50 caracteres.")]
        #endregion
        public string Turma { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "A data inicial da matrícula é requerida.")]
        #endregion
        public DateTime Data_Inicial { get; set; }
        public DateTime? Data_Final { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "O status da matrícula é requerido.")]
        [StringLength(50, ErrorMessage = "O status da matrícula deve ter no máximo 50 caracteres.")]
        #endregion
        public string Status { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "O código do aluno é requerido.")]
        #endregion
        public int Id_Aluno { get; set; }
    }
}