//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorClass.Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matricula
    {
        public int Id { get; set; }
        public string Curso { get; set; }
        public string Serie { get; set; }
        public string Turma { get; set; }
        public System.DateTime Data_Inicial { get; set; }
        public Nullable<System.DateTime> Data_Final { get; set; }
        public string Status { get; set; }
        public int Id_Aluno { get; set; }
    
        public virtual Aluno Aluno { get; set; }
    }
}