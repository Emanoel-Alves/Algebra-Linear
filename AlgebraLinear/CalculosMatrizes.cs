using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
