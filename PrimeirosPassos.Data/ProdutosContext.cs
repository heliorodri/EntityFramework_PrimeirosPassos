using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PrimeirosPassos.Domain;   

namespace PrimeirosPassos.Data
{
    public class ProdutosContext : DbContext
    { 
        //Inicializar o DataBase e cria-lo, caso não exista
        public ProdutosContext() : base("Name=TestBase")
        {      
            Database.SetInitializer<ProdutosContext>(
                new CreateDatabaseIfNotExists<ProdutosContext>());
            Database.Initialize(false); //Será executado somente uma vez
        }

        //mapeamento das duas entidades
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Loja> Lojas { get; set; }

    }
}
