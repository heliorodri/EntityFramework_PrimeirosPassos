using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeirosPassos.Domain
{
    [Table("Lojas")]
    public class Loja
    {
        public Loja()
        {
            Produtos = new List<Produto>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
            
        [MaxLength(2000)]
        public string Descricao { get; set; }

        //Ao carregar a loja o EF já traz os produtos
        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
