using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeirosPassos.Domain;
using PrimeirosPassos.Data;

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


            dbContext.SaveChanges();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loja loja = dbContext.Lojas.Find(1);

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
            Produto prod = dbContext.Produtos.Find(1);
            Loja j = prod.Loja;
        }
    }
}
