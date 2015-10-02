using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        float[,] M1 = new float[2, 2] { { 2, 3}, { 6, 8} };
        float[,] M2 = new float[4, 4] { { 0,0,1,0.5f }, { 1,2,1,-2 }, {0,-1,3,0} ,{0,-2,4,-4}};
        public Form1()
        {
            InitializeComponent();
            Determinante(M2);
        }

        public float[,] Add2dArray(float[,] A, float[,] B)
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

        public float[,] Sub2dArray(float[,] A, float[,] B)
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

       
        public float[,] Mult2dArray(float[,] A, float[,] B)
        {
            float[,] R = new float[A.GetLength(0),B.GetLength(1)];

            if (A.GetLength(1) == B.GetLength(0))
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        for (int n = 0; n < A.GetLength(1); n++)
                        {
                            R[i,j] += A[i,n]*B[n,j];
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lines of Matrix2 must be equals of columns of Matrix1");
            }
            
            
            return R;
        }

        public float[,] Mult2dArraybyRealNumb(float[,] A, float B)
        {
            float[,] R = new float[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    R[i, j] = A[i, j] *B;
                }
            }

            return R;
        }

        public float[,] Transp2dArray(float[,] A)
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

        public bool Sim(float[,] A)
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

        public float Determinante(float[,] A)
        {
            float r = 0;
            float m = 1;
            float m2 = 1;

            if (A.GetLength(1) == A.GetLength(0))
            {
                if(A.GetLength(0) == 1)
                {
                    r = A[0, 0];
                }

                else if(A.GetLength(0) == 2)
                {
                    r = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
                }

                else if (A.GetLength(0) == 3)
                {
                    r = A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[0, 2] * A[1, 0] * A[2, 1]
                      - A[0, 2] * A[1, 1] * A[2, 0] - A[0, 0] * A[1, 2] * A[2, 1] - A[0, 1] * A[1, 0] * A[2, 2];
                }

                else
                {
                    bool isZero = true;
                    float[] L = new float[A.GetLength(1)];

                    for (int i = 0; i < A.GetLength(0); i++ )
                    {
                        if(A[i,0] > 0)
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
    }
}
