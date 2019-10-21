using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeirosPassos.Domain
{
    [Table("Produtos")]  //Data Annotation para definir o nome da tabela no banco de dados
    public class Produto
    {
        //Se a classe possui um atributo ID. O Entity framework automaticamente o define como PK. 
        //Então o uso é opcional nesse caso
        [Key] 
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(2000)]
        public string Descricao { get; set; }

        //Não existe uma Annotation para definir a precisão de um Decimal, então é usado o atributo Range
        [Range(-999999999999.999, 999999999999.999)] //12 casas antes da virgula e 3 depois
        [Required]
        public decimal Valor { get; set; }

        [ForeignKey("Loja")] //LojaId está linkado com a prop virtual Loja
        public int LojaId { get; set; }

        //Ao carregar o produto o EF já traz a loja
        public virtual Loja Loja { get; set; }


    }
}
