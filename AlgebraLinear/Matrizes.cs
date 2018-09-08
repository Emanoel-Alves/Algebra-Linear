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
    public partial class Matrizes : Form
    {
        private TextBox[,] Matriz1;
        private TextBox[,] Matriz2;
        private TextBox[,] MatrizResultante;

        int linha1, coluna1;
        int linha2, coluna2;

        public Matrizes()
        {
            InitializeComponent();
        }

        private void fecharFormularioMatrizes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Gerar Matriz 1
        private void gerarMatriz1_Click_1(object sender, EventArgs e)
        {
            groupBoxMatriz1.Controls.Clear();

            if (!int.TryParse(textBox1.Text, out linha1))
            {
                MessageBox.Show("A linha da matriz 1 é nula.", "Erro");
                return;
            }
            if (!int.TryParse(textBox2.Text, out coluna1))
            {
                MessageBox.Show("A coluna da matriz 1 é nula.", "Erro");
                return;
            }

            Matriz1 = new TextBox[linha1, coluna1];
            int TamanhoText = groupBoxMatriz1.Width / coluna1;
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = "0";
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    //Matriz1[x, y].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }

        }


        #endregion

        #region Gerar Matriz 2
        private void gerarMatriz2_Click(object sender, EventArgs e)
        {
            groupBoxMatriz2.Controls.Clear();

            if (!int.TryParse(textBox3.Text, out linha2))
            {
                MessageBox.Show("A linha da matriz 2 é nula.", "Erro");
                return;
            }
            if (!int.TryParse(textBox4.Text, out coluna2))
            {
                MessageBox.Show("A coluna da matriz 2 é nula.", "Erro");
                return;
            }

            int TamanhoText = groupBoxMatriz2.Width / coluna2;
            Matriz2 = new TextBox[linha2, coluna2];
            TamanhoText = groupBoxMatriz2.Width / coluna2;

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = "0";
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    //Matriz2[x, y].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion
           
        #region Btn Subtrair
        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a subtracao de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                    //tempMatriz1[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                    //tempMatriz2[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.SubtrairMatrizes(tempMatriz1, tempMatriz2);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 1;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }
        }


        #endregion

        #region Btn Multiplicar
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(1) != tempMatriz2.GetLength(0))
            {
                MessageBox.Show("So e possivel a multiplicacao de matrizes onde a coluna da matriz 1 e igual a linha da matriz 2  !", "Erro - Multiplicacao Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                    //tempMatriz1[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                    //tempMatriz2[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.MultiplicarMatrizes(tempMatriz1, tempMatriz2);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 1;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }
        }

        private void groupBoxMatrizResultante_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region Btn Somar
        private void btnSomar_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                    //tempMatriz1[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                    //tempMatriz2[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.SomarMatrizes(tempMatriz1, tempMatriz2);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 1;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }

        }
        #endregion

        private void Matrizes_Load(object sender, EventArgs e)
        {

        }
    }
}
