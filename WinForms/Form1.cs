using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PrimeirosPassos.Domain;
using PrimeirosPassos.Data;
using System.Data.Entity;

namespace WinForms
{
    public partial class Form1 : Form
    {
        ProdutosContext dbContext;
        public Form1()
        {
            InitializeComponent();
            dbContext = new ProdutosContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loja loja = new Loja()
            {
                Nome = "Loja1",
                Descricao = "Loja de esportes americanos"
            };
            dbContext.Lojas.Add(loja);

            Produto prod = new Produto()
            {
                Nome = "Jersey Saints",
                Descricao = "Camiseta New Orlean Saints 2019",
                Valor = 299.00M,
                Loja = loja
            };
            dbContext.Produtos.Add(prod);

            Loja loja2 = new Loja()
            {
                Nome = "Loja2",
                Descricao = "Loja de Música"
            };
            dbContext.Lojas.Add(loja2);

            Produto prod2 = new Produto()
            {
                Nome = "Dark Side of the Moon",
                Descricao = "Dark side of the Moon by Pynk Floyd",
                Valor = 100.00M,
                Loja = loja2
            };
            dbContext.Produtos.Add(prod2);

            dbContext.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loja loja = dbContext.Lojas.Find(2);

            Produto newProd = new Produto()
            {
                Nome = "Jersey Patriots",
                Valor = 299.00M,
                Descricao = "Camiseta New England Patriots",
                LojaId = loja.ID
            };
            dbContext.Produtos.Add(newProd);

            dbContext.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Produto prod = dbContext.Produtos.Find(4);
            Loja j = prod.Loja;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<Produto> ProdutosIniciadoComA =
                dbContext.Produtos.Where(p => p.Nome.StartsWith("C"));

            IEnumerable<Produto> produtosLoja2 =
                dbContext.Produtos.Where(p => p.LojaId == 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Loja l = dbContext.Lojas.Find(2);
            l.Nome = "Loja 1 teste update";
            dbContext.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Loja l = dbContext.Lojas.Find(2);
            dbContext.Lojas.Remove(l);

            dbContext.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Produto p = new Produto()
            {
                Id = 2,
                Nome = "Teste 22",
                LojaId = 2,
                Descricao = "testes"
            };

            dbContext.Entry(p).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
