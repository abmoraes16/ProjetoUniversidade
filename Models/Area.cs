using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUniversidade.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int IdArea { get; set; }
        
        [Required(ErrorMessage="O preenchimento do Nome é obrigatório!")]
        [StringLength(100,MinimumLength=5,ErrorMessage="O tamanho de Nome deve variar entre 5 e 100 caracteres")]
        [Column(Order=1)]
        public string Nome { get; set; }

        [Column(Order=2)]
        public ICollection<Curso> Curso { get; set; }
    }
}