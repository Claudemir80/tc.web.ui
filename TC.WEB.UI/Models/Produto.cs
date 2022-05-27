using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TC.WEB.UI.Models
{
    public class Produto
    {
        public Produto()
        {
            this.Categorias = new HashSet<Categoria>();
        }

        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Esse Campo Descrição é de preenchimento Obrigatório")]
        [Column(TypeName = "nvarchar(250)")]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Esse Campo Preço é de preenchimento Obrigatório")]
        [Display(Name = "Preço")]
        public string Preco { get; set; }

        //[Required(ErrorMessage = "Esse Campo Estoque é de preenchimento Obrigatório")]
        [Display(Name = "Estoques")]
        public string? Estoque { get; set; }

        [Required(ErrorMessage = "Esse Campo Data de Cadastro é de preenchimento Obrigatório")]
        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "{0 : dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DataCadastro { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}
