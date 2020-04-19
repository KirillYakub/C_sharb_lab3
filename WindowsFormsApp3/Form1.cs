using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public int row = 3, col = 3, count = 0, count_1 = 0, A, A1, B, B1, C, C1, D, D1;

        public Form1()
        {
            InitializeComponent();
        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        { }

        public void Form1_Load(object sender, EventArgs e)
        { }

        public void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += ($"Матрица A номер {++count}");

            richTextBox1.Text += ("\n");

            Random rand = new Random();

            Matrix number = new Matrix();

            int[,] arrA = new int[row, col];

            int[,] arr_twoA = new int[row, col];

            int[,] diff_of_arr = new int[row, col];

            int[,] arrB = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrA[i, j] = rand.Next(0, 2);
                    richTextBox1.Text += ($"{arrA[i, j]}" + "  ");
                }
                richTextBox1.Text += ("\n");
            }

            richTextBox1.Text += ("\n");

            richTextBox1.Text += ("Удвоенная матрица A" + "\n");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arr_twoA[i, j] = number.TwoX_Matrix(arrA, i, j);
                    richTextBox1.Text += ($"{arr_twoA[i, j]}" + "  ");
                }
                richTextBox1.Text += ("\n");
            }

            richTextBox1.Text += ("\n" + "Выполнена операция 2*A" + "\n\n" + $"Матрица В номер {++count_1}" + "\n");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrB[i, j] = rand.Next(0, 2);
                    richTextBox1.Text += ($"{arrB[i, j]}" + "  ");
                }
                richTextBox1.Text += ("\n");
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrA[i, j] = number.Half_of_Matrix(arrA, i, j);
                }
            }

            richTextBox1.Text += ("\n" + "Выполняем операцию A + B" + "\n");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrB[i, j] = number.Sum_of_Matrix(arrA, arrB, i, j);
                    richTextBox1.Text += ($"{arrB[i, j]}" + "  ");
                }
                richTextBox1.Text += ("\n");
            }

            richTextBox1.Text += ("\n" + "Выполняем операцию 2*A*(A + B)" + "\n");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrB[i, j] = number.Product_of_Matrix(arr_twoA, arrB, i, j);
                    richTextBox1.Text += ($"{arrB[i, j]}" + "  ");
                }
                richTextBox1.Text += ("\n");
            }

            richTextBox1.Text += ("\n" + "Выполняем операцию 3*A" + "\n");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrA[i, j] = number.Three_X_Matrix(arrA, i, j);
                    richTextBox1.Text += ($"{arrA[i, j]}" + "  ");
                }
                richTextBox1.Text += ("\n");
            }

            richTextBox1.Text += ("\n" + "Выполняем вычитание (A+B)-3*A" + "\n");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    diff_of_arr[i, j] = number.Diff_of_Matrix(arrA, arrB, i, j);
                    richTextBox1.Text += ($"{diff_of_arr[i, j]}" + "  ");
                    A = diff_of_arr[0, 0]; 
                    A1 = diff_of_arr[0, 2];
                    B = diff_of_arr[2, 2];
                    B1 = diff_of_arr[2, 0];
                    C = diff_of_arr[1, 0];
                    C1 = diff_of_arr[0, 1];
                    D = diff_of_arr[1, 2];
                    D1 = diff_of_arr[2, 1];
                }
                richTextBox1.Text += ("\n");
            }

            richTextBox1.Text += ("\n");

            int count2 = 0;

            if (A == A1 && A1 == B && B == B1 && B1 == A)
            {
                if (C == C1 && C1 == D && D == D1 && D1 == C)
                {
                    count2++;
                }
            }

            if (count2 != 0)
            {
                richTextBox1.Text += ("Финальная матрица транcпонированная" + "\n\n");
            }

            else
            {
                richTextBox1.Text += ("Финальная матрица не транcпонированная" + "\n\n");
            }
        }
    }

    public class Matrix
    {
        public int TwoX_Matrix(int[,] arrA, int i, int j)
        {
            return arrA[i,j] *= 2;
        }

        public int Sum_of_Matrix(int[,] arrA, int[,] arrB, int i, int j)
        {
            return arrA[i, j] + arrB[i, j];
        }

        public int Diff_of_Matrix(int[,] arrA, int[,] arrB, int i, int j)
        {
            return arrB[i, j] - arrA[i, j];
        }

        public int Product_of_Matrix(int[,] arr_twoA, int[,] arrB, int i, int j)
        {
            return arr_twoA[i, j] * arrB[i, j];
        }

        public int Half_of_Matrix(int[,] arrA, int i, int j)
        {
            return arrA[i, j] /= 2;
        }

        public int Three_X_Matrix(int[,] arrA, int i, int j)
        {
            return arrA[i, j] *= 3;
        }

    }
}
