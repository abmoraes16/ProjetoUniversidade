using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUniversidade.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int IdCurso { get; set; }
        
        [Required(ErrorMessage="O tamanho Nome deve ser entre 5 e 100 caracteres")]
        [StringLength(100,MinimumLength=5,ErrorMessage="O tamanho Nome deve ser entre 5 e 100 caracteres")]
        [Column(Order=1)]
        public string Nome { get; set; }

        [Required]
        [Column(Order=2)]
        public int IdArea { get; set; }

        [Column(Order=3)]
        public Area Area { get; set; }

        [Column(Order=4)]
        public ICollection<Turma> Turma { get; set; }
    }
}