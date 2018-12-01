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

        #region Formulario
        public Matrizes()
        {
            InitializeComponent();
        }

        private void fecharFormularioMatrizes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Gerar Matriz 1
        private void gerarMatriz1_Click_1(object sender, EventArgs e)
        {
            groupBoxMatriz1.Controls.Clear();

            int.TryParse(textBox1.Text, out linha1);
            int.TryParse(textBox2.Text, out coluna1);

            if (!int.TryParse(textBox1.Text, out linha1) || linha1 == 0)
            {
                MessageBox.Show("A linha da matriz 1 é nula.", "Erro");
                return;
            }
            if (!int.TryParse(textBox2.Text, out coluna1) || coluna1 == 0)
            {
                MessageBox.Show("A coluna da matriz 1 é nula.", "Erro");
                return;
            }
            if (linha1 > 9 || coluna1 > 9)
            {
                MessageBox.Show("Dimensão não permitida", "Erro");
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
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }

        }


        #endregion

        #region Gerar Matriz 2
        private void gerarMatriz2_Click(object sender, EventArgs e)
        {
            groupBoxMatriz2.Controls.Clear();

            int.TryParse(textBox3.Text, out linha2);
            int.TryParse(textBox4.Text, out coluna2);

            if (!int.TryParse(textBox3.Text, out linha2) || linha2 == 0)
            {
                MessageBox.Show("A linha da matriz 2 é nula.", "Erro");
                return;
            }
            if (!int.TryParse(textBox4.Text, out coluna2) || coluna2 == 0)
            {
                MessageBox.Show("A coluna da matriz 2 é nula.", "Erro");
                return;
            }
            if (linha2 > 9 || coluna2 > 9)
            {
                MessageBox.Show("Dimensão não permitida", "Erro");
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
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível realizar a subtração de matrizes de mesma ordem!", "Erro - Subtração Entre Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
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
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(1) != tempMatriz2.GetLength(0))
            {
                MessageBox.Show("Atenção!\n\nSó é possível realizar a multiplicação de matrizes onde a coluna da 1° matriz é igual a linha da 2° matriz!", "Erro - Multiplicação Entre Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
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

        #endregion

        #region Btn Somar
        private void btnSomar_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível realizar a soma de matrizes de mesma ordem!", "Erro - Soma Entre Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
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

        #region Multiplicação Escalar Matriz 1
        private void btnMultiplicarEscalarMatriz1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null )
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
         

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float m = 0;
                    float.TryParse(Matriz1[x, y].Text, out m);
                    tempMatriz1[x, y] = m;  
                }
            }

            float n = 0;
            float.TryParse(textBoxEscalarMatriz1.Text, out n);
            float constante = n;
            float[,] tempMatrizResultante = CalculosMatrizes.MultiplicarMatrizPorEscalar(tempMatriz1, constante);

            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];

            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(1);

            groupBoxMatriz1.Controls.Clear();

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        #endregion

        #region Multiplicação Escalar Matriz 2
        private void btnMultiplicarEscalarMatriz2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];


            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float m = 0;
                    float.TryParse(Matriz2[x, y].Text, out m);
                    tempMatriz2[x, y] = m;
                }
            }

            float n = 0;
            float.TryParse(textBoxEscalarMatriz2.Text, out n);
            float constante = n;
            float[,] tempMatrizResultante = CalculosMatrizes.MultiplicarMatrizPorEscalar(tempMatriz2, constante);

            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];

            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(1);

            groupBoxMatriz2.Controls.Clear();

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }

        #endregion

        #region Transposição da Matriz 1
        private void btnTranspostaMatriz1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(0);

            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        #endregion

        #region Transposição da Matriz 2
        private void btnTranspostaMatriz2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(0);
            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion

        #region Potenciação da Matriz 1
        private void bntPotenciaMatriz1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
                {
                    MessageBox.Show("Matriz nula!", "Error - Matriz");
                    return;
                }

            if(Matriz1.GetLength(0) != Matriz1.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível realizar potência de matrizes quadradas", "Error - Potência da Matriz");
                return;
            }

            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }

            int m = 0;
            int.TryParse(textBoxPotenciaMatriz1.Text, out m);
            int potencia = m;

            float[,] tempMatrizResultante = CalculosMatrizes.PotenciaMatrizes(tempMatriz1, potencia);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(0);

            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        #endregion

        #region Potenciação da Matriz 2
        private void bntPotenciaMatriz2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz2.GetLength(0) != Matriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível realizar potência de matrizes quadradas", "Error - Potência da Matriz");
                return;
            }

            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            int m = 0;
            int.TryParse(textBoxPotenciaMatriz2.Text, out m);
            int potencia = m;

            float[,] tempMatrizResultante = CalculosMatrizes.PotenciaMatrizes(tempMatriz2, potencia);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(0);

            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion

        #region Determinate Matricial 1

        private void DeterminanteMatriz1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz1.GetLength(0) != Matriz1.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Determinante da Matriz");
                return;
            }

            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }

            float determinante = -1111111;

            if(tempMatriz1.GetLength(0) == 1)
            {
                determinante = tempMatriz1[0,0];
            }
            else
            {
                determinante = CalculosMatrizes.Determinante(tempMatriz1);
            }
 
            Determinante1.Text = "det = " + determinante.ToString();
        }

        #endregion

        #region Determinate Matricial 2
        private void DeterminanteMatriz2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz2.GetLength(0) != Matriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Determinante da Matriz");
                return;
            }

            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float determinante = -1111111;

            if (tempMatriz2.GetLength(0) == 1)
            {
                determinante = tempMatriz2[0, 0];
            }
            else
            {
                determinante = CalculosMatrizes.Determinante(tempMatriz2);
            }

            Determinante2.Text = "det = " + determinante.ToString();
        }
        #endregion

        #region Matriz CoFatora 1
        private void MatrizCofatora_Click(object sender, EventArgs e)
        {

            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz1.GetLength(0) != Matriz1.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Determinante da Matriz");
                return;
            }

            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.CoFator(tempMatriz1);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(0);

            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        #endregion

        #region Matriz CoFatora 2
        private void MatrizCofatora2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz2.GetLength(0) != Matriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Determinante da Matriz");
                return;
            }

            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.CoFator(tempMatriz2);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(0);

            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion

        #region Matriz Adjunta 1
        private void MatrizAdjunta_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz1.GetLength(0) != Matriz1.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Determinante da Matriz");
                return;
            }

            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.Adjunta(tempMatriz1);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(0);

            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        #endregion

        #region Matriz Adjunta 2
        private void MatrizAdjunta2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz2.GetLength(0) != Matriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Determinante da Matriz");
                return;
            }

            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.Adjunta(tempMatriz2);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(0);

            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion

        #region Matriz Inversa 1
        private void MatrizInversa_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz1.GetLength(0) != Matriz1.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Matriz Inversa");
                return;
            }

            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }

            if ((CalculosMatrizes.Determinante(tempMatriz1)) == 0)
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular a inversa de matrizes\ncujo o determinante é diferente de zero.", "Error - Matriz Inversa");
                return;
            }

            float[,] tempMatrizResultante = CalculosMatrizes.Inversa(tempMatriz1);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(0);

            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 1;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        #endregion

        #region Matriz Inversa 2
        private void MatrizInversa2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula!", "Error - Matriz");
                return;
            }

            if (Matriz2.GetLength(0) != Matriz2.GetLength(1))
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular o determinante de matrizes quadradas", "Error - Matriz Inversa");
                return;
            }

            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            if ((CalculosMatrizes.Determinante(tempMatriz2)) == 0)
            {
                MessageBox.Show("Atenção!\n\nSó é possível calcular a inversa de matrizes\ncujo o determinante é diferente de zero.", "Error - Matriz Inversa");
                return;
            }

            float[,] tempMatrizResultante = CalculosMatrizes.Inversa(tempMatriz2);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(0);

            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 1;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion

        #region Funções não usaveis
        private void Matrizes_Load(object sender, EventArgs e)
        {

        }

        private void groupBoxMatrizResultante_Enter(object sender, EventArgs e)
        {

        }
        #endregion
    }

}
