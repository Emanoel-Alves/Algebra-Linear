using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlgebraLinear
{
    class CalculosMatrizes
    {
        #region Operação Somar
        public static float[,] SomarMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    matrizResultante[x, y] = matriz1[x, y] += matriz2[x, y];
                }
            }
            return matrizResultante;
        }
        #endregion

        #region Operação Subtrair
        public static float[,] SubtrairMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    matrizResultante[x, y] = matriz1[x, y] -= matriz2[x, y];
                }
            }
            return matrizResultante;
        }
        #endregion

        #region Operação Multiplicar
        public static float[,] MultiplicarMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz1.GetLength(0), matriz2.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    for (int n = 0; n < matriz2.GetLength(0); n++)
                    {
                        string i = "" + matriz1[x, n];
                        matrizResultante[x, y] += matriz1[x, n] * matriz2[n, y];
                    }
                }
            }
            return matrizResultante;
        }
        #endregion

        #region Operação Multiplicação Escalar Para Matrizs
        public static float[,] MultiplicarMatrizPorEscalar(float[,] matriz, float constante)
        {
            float[,] matrizResultante = new float[matriz.GetLength(0), matriz.GetLength(1)];

            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    matrizResultante[x, y] += matriz[x, y] * constante;
                }
            }
            return matrizResultante;
        }
        #endregion

        #region Operação Transposição
        public static float[,] GerarTransposta(float[,] matriz)
        {
            float[,] matrizTransposta = new float[matriz.GetLength(1), matriz.GetLength(0)];

            for (int x = 0; x < matrizTransposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizTransposta.GetLength(1); y++)
                {
                    matrizTransposta[x, y] += matriz[y, x];
                }
            }
            return matrizTransposta;
        }
        #endregion

        #region Operação Potenciação
        public static float[,] PotenciaMatrizes(float[,] matriz, int potencia)
        {
            float[,] matrizResultante = new float[matriz.GetLength(0), matriz.GetLength(1)];
            matrizResultante = matriz;

            if(potencia == 0)
            {
                for (int x = 0; x < matrizResultante.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultante.GetLength(1); y++)
                    {
                        if (x == y)
                        {
                            matrizResultante[x, y] = 1;
                        }
                        else
                        {
                            matrizResultante[x, y] = 0;
                        }
                    }
                }
                return matrizResultante;
            }

            for (int i = 1; i < potencia; i++)
            {
                matrizResultante = MultiplicarMatrizes(matrizResultante, matriz);
            }

            return matrizResultante;
        }
        #endregion

        #region Operação Determinantes

        #region Determinate Da matriz
        public static float Determinante(float[,] matriz)
        {
            float determinante = 0;

            if (matriz.GetLength(0) ==2 && matriz.GetLength(1) == 2)
            { 
                return determinante = matriz[0, 0] * matriz[1, 1] - (matriz[0, 1] * matriz[1, 0]);
            }
            else
            {
                for (int i = 0; i < matriz.GetLength(0) ; i++)
                {
                    determinante += Exp(-1, i) * matriz[0, i] * Determinante(MenorComplementar(matriz, 0, i));
                }
            }

            return determinante;
        }
        #endregion

        #region Menor Complementar Para Determinante
        public static float[,] MenorComplementar(float[,] matriz, int linha, int coluna)
        {

            float[,] novaMatriz = new float[matriz.GetLength(0) - 1, matriz.GetLength(1) - 1];
            int lin = -1;

            for(int i = 0; i < matriz.GetLength(0); i++)
            {

                if (i == linha)
                {
                    continue;
                }
                lin++;

                int col = -1;
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if(j == coluna)
                    {
                        continue;
                    }

                    novaMatriz[lin, ++col] = matriz[i, j];
                } 
            }

            return novaMatriz;
        }

        #endregion

        #region Cofatora
        public static float[,] CoFator(float[,] matriz)
        {

            float[,] matrizCofatora = new float[matriz.GetLength(0), matriz.GetLength(1)];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matrizCofatora[i,j] =  Exp(-1, (i+j)) * Determinante(MenorComplementar(matriz, i, j));
                }
            }

            return matrizCofatora;
        }

        #endregion

        #region Adjunta
        public static float[,] Adjunta(float[,] matriz)
        {

            float[,] matrizAdjunta = new float[matriz.GetLength(0), matriz.GetLength(1)];
            float[,] matrizCofatora = new float[matriz.GetLength(0), matriz.GetLength(1)];

            matrizCofatora = CoFator(matriz);
            matrizAdjunta = GerarTransposta(matrizCofatora);

            return matrizAdjunta;
        }

        #endregion

        #region Operação da Inversa
        public static float[,] Inversa(float[,] matriz)
        {

            float[,] matrizAdjunta = new float[matriz.GetLength(0), matriz.GetLength(1)];
            float[,] matrizCofatora = new float[matriz.GetLength(0), matriz.GetLength(1)];
            float[,] matrizInversa = new float[matriz.GetLength(0), matriz.GetLength(1)];

            float determinante = 0;
            determinante = Determinante(matriz);

            matrizCofatora = CoFator(matriz);
            matrizAdjunta = GerarTransposta(matrizCofatora);

            for (int i = 0; i < matrizAdjunta.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAdjunta.GetLength(1); j++)
                {
                    matrizInversa[i, j] = (1/determinante) * matrizAdjunta[i,j];
                }
            }

            return matrizInversa;
        }
        #endregion

        #endregion

        static float Exp(int x, int y)
        {
            float resultado = 1;

            for (int i = 1; i <= y; i++)
            {
                resultado = resultado * x;
            }
            return resultado;
        }
    }
}
