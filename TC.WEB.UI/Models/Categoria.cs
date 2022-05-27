using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TC.WEB.UI.Models
{
    public class Categoria
    {
        public Categoria()
        {
            this.Produtos = new HashSet<Produto>();
        }

        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Descrição de Categoria")]
        [Required(ErrorMessage = "Esse Campo é de preenchimento Obrigatório")]
        [Column(TypeName = "nvarchar(250)")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
