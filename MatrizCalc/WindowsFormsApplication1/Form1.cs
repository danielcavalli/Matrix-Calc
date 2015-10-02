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
        float[,] M1 = new float[2, 3] { { 2, 3, 4}, { 6, 8, 1} };
        float[,] M2 = new float[2,2] {{1,3},{2,1}};
        public Form1()
        {
            InitializeComponent();
            Sim(M1);
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

       
        /*public float[,] Mult2dArray(float[,] A, float[,] B)
        {
            float[,] R;
            if (A.GetLength(1) == B.GetLength(0))
            {
                R = new float[A.GetLength(0), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        R[i, j] = A[i, j] - B[i, j];
                    }
                }
            }
            else
            {
                R = new float[0, 0];
                return R;
            }
        }*/

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

       /* public float[,] ArrayGem(int L, int C)
        {
            float[,] R = new float[L, C];
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    
                }
            }

            return R;
        }*/
    }
}
