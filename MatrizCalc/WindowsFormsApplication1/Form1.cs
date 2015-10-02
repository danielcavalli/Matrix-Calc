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
        float[,] M1 = new float[2, 2] { { 4, 3} ,{ 2, 4} };
        float[,] M2 = new float[2, 2] { { 0.4f,-0.3f}, { -0.2f,0.4f}};

        Calcs calc = new Calcs();
        public Form1()
        {
            InitializeComponent();
            calc.Inversa(M1);
        }
    }
}
