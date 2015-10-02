using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Calcs
    {
        public float[,] Add2dArray(float[,] A, float[,] B)//função de soma de duas matrizes
        {
            float[,] R = new float[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    R[i, j] = A[i, j] + B[i, j];
                }
            }

            return R;
        }

        public float[,] Sub2dArray(float[,] A, float[,] B)//função de subtração de duas matrizes
        {
            float[,] R = new float[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    R[i, j] = A[i, j] - B[i, j];
                }
            }

            return R;
        }


        public float[,] Mult2dArray(float[,] A, float[,] B)//função de multiplicação de duas matrizes
        {
            float[,] R = new float[A.GetLength(0), B.GetLength(1)];

            //if (A.GetLength(1) == B.GetLength(0))
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        for (int n = 0; n < A.GetLength(1); n++)
                        {
                            R[i, j] += A[i, n] * B[n, j];
                        }
                    }
                }
            }
            return R;
        }

        public float[,] Mult2dArraybyRealNumb(float[,] A, float B)//função de multiplicação de matriz por numero real
        {
            float[,] R = new float[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    R[i, j] = A[i, j] * B;
                }
            }

            return R;
        }

        public float[,] Transp2dArray(float[,] A)// função que retorna a transposta de uma matriz
        {
            float[,] R = new float[A.GetLength(1), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    R[j, i] = A[i, j];
                }
            }

            return R;
        }

        public bool Sim(float[,] A)// função que verifica se uma matriz é simétrica
        {
            float[,] transp = Transp2dArray(A);
            bool IsSim = true;

            if (A.GetLength(1) == A.GetLength(0))
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        if (transp[i, j] != A[i, j])
                        {
                            IsSim = false;
                        }
                    }
                }
                return IsSim;
            }

            else
                return false;
        }

        public float Determinante(float[,] A)// função que retorna a determinante de uma matriz quadrada 
        {
            float r = 0;
            float m = 1;
            float m2 = 1;

            if (A.GetLength(1) == A.GetLength(0))
            {
                if (A.GetLength(0) == 1)// matriz 1x1
                {
                    r = A[0, 0];
                }

                else if (A.GetLength(0) == 2)// matriz 2x2
                {
                    r = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
                }

                else if (A.GetLength(0) == 3)// matriz 3x3
                {
                    r = A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[0, 2] * A[1, 0] * A[2, 1]
                      - A[0, 2] * A[1, 1] * A[2, 0] - A[0, 0] * A[1, 2] * A[2, 1] - A[0, 1] * A[1, 0] * A[2, 2];
                }

                else// matriz nxn, por método de shió
                {
                    bool isZero = true;
                    float[] L = new float[A.GetLength(1)];

                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        if (A[i, 0] != 0)
                        {
                            isZero = false;
                            if (i > 0)
                            {
                                for (int j = 0; j < A.GetLength(1); j++)
                                {
                                    L[j] = A[i, j];
                                    A[i, j] = A[0, j];
                                    A[0, j] = L[j];
                                }
                                m2 = -1;
                            }
                            i = A.GetLength(0);
                        }
                    }

                    if (!isZero)
                    {
                        m /= A[0, 0];

                        float[,] B = new float[A.GetLength(1) - 1, A.GetLength(0) - 1];
                        for (int i = 0; i < A.GetLength(0); i++)
                        {
                            A[i, 0] *= m;
                        }

                        for (int i = 1; i < A.GetLength(0); i++)
                        {
                            for (int j = 1; j < A.GetLength(1); j++)
                            {
                                B[i - 1, j - 1] = A[i, j] - (A[0, j] * A[i, 0]);
                            }
                        }

                        r = Determinante(B);
                    }
                }

            }
            return r / m * m2;
        }
        public float Cofator(float[,] A, float L, float C)// função que retorna o cofator de um elemento de uma matriz
        {
            float[,] B = new float[A.GetLength(0) - 1, A.GetLength(1) - 1];
            int i2 = 0;
            int j2 = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (i == L) i++;

                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (j == C) j++;
                    if (i < A.GetLength(0) && j < A.GetLength(1)) B[i2, j2] = A[i, j];

                    j2++;
                }
                i2++;
                j2 = 0;
            }

            return Determinante(B);

        }

        public float[,] Adjunta(float[,] A)//função que retorna a matriz adjunta de uma matriz
        {
            float[,] R = new float[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    R[i, j] = float.Parse(Math.Pow(-1,i+j+2).ToString())*Cofator(A, i, j);
                }
            }

            return Transp2dArray(R);
        }

        public float[,] Inversa(float[,] A)//função que retorna a matriz inversa de uma matriz
        {
            return Mult2dArraybyRealNumb(Adjunta(A), (1 / Determinante(A)));
        }
    }
}
