using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlgebraLinear
{
    public partial class Sistemas : Form
    {

        private TextBox[,] Sistema;
        int linha1, coluna1;

        public Sistemas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gerarSistema_Click(object sender, EventArgs e)
        {
            groupBoxSistema.Controls.Clear();
            MessageBox.Show("Atenção!\nAs operações com sistemas só será \npossível na proxima atualização 2.0", "Atualização");
            return;

            int.TryParse(variaveis.Text, out coluna1);
            int.TryParse(equacoes.Text, out linha1);

            if (!int.TryParse(variaveis.Text, out coluna1) || coluna1 == 0)
            {
                MessageBox.Show("O total de variáveis é 0.", "Erro");
                variaveis.Controls.Clear();
                return;
            }
            if (!int.TryParse(equacoes.Text, out linha1) || linha1 == 0)
            {
                MessageBox.Show("O total de equações é 0.", "Erro");
                equacoes.Controls.Clear();
                return;
            }
            if (linha1 > 6 || coluna1 > 5)
            {
                MessageBox.Show("Dimensão não permitida", "Erro");
                return;
            }

            Sistema = new TextBox[linha1, coluna1];
            Label[] labels = new Label[coluna1];

            int TamanhoText = groupBoxSistema.Width /coluna1;
            int TamanhoTextAltura  = groupBoxSistema.Height / linha1;
            for (int x = 0; x < Sistema.GetLength(0); x++)
            {
                for (int y = 0; y < Sistema.GetLength(1); y++)
                {
                    Sistema[x, y] = new TextBox();
                    Sistema[x, y].Text = "X" + y;
                    Sistema[x, y].Top = (x * Sistema[x, y].Height) + 30;
                    Sistema[x, y].Left = y * TamanhoText + 1;
                    Sistema[x, y].Multiline = true;
                    Sistema[x, y].Width = TamanhoText;
 
                    groupBoxSistema.Controls.Add(Sistema[x, y]);
                }
            }
        }
    }
}
