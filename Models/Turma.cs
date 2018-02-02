using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUniversidade.Models
{
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int IdTurma { get; set; }

        [Required]
        [Column(Order=1)]
        public int IdCurso { get; set; }
        
        [Required]
        [Column(Order=2)]
        public DateTime DataInicio { get; set; }
        
        [Required]
        [Column(Order=3)]
        public DateTime DataFinal { get; set; }
        
        [Required]
        [Column(Order=4)]
        public DateTime HoraInicio { get; set; }
        
        [Required]
        [Column(Order=5)]
        public DateTime HoraFinal { get; set; }
        
        [Required]
        [Column(Order=6)]
        public string Dias { get; set; }
        
        [Column(Order=7)]
        public Curso Curso {get;set;}
    }
}