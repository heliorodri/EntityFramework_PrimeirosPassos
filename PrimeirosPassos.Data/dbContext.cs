using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PrimeirosPassos.Domain;   

namespace PrimeirosPassos.Data
{
    public class dbContext : DbContext
    { 
        //Inicializar o DataBase e cria-lo, caso não exista
        public dbContext() : base("Name=TestBase")
        {      
            Database.SetInitializer<dbContext>(
                new CreateDatabaseIfNotExists<dbContext>());
            Database.Initialize(false); //Será executado somente uma vez

            Database.Log = d => System.Diagnostics.Debug.WriteLine(d);
        }

        //mapeamento das duas entidades
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Loja> Lojas { get; set; }

    }
}
