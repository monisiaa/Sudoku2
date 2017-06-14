using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public TextBox[] plansza_sudoku;
        private void Form1_Load(object sender, EventArgs e)
        {
            plansza_sudoku = new TextBox[81]; //zapisuje planszę jako tablicę

#region przypisanie textbox-ow
            plansza_sudoku[0] = t11;
            plansza_sudoku[1] = t12;
            plansza_sudoku[2] = t13;
            plansza_sudoku[3] = t14;
            plansza_sudoku[4] = t15;
            plansza_sudoku[5] = t16;
            plansza_sudoku[6] = t17;
            plansza_sudoku[7] = t18;
            plansza_sudoku[8] = t19;
            plansza_sudoku[9] = t21;
            plansza_sudoku[10] = t22;
            plansza_sudoku[11] = t23;
            plansza_sudoku[12] = t24;
            plansza_sudoku[13] = t25;
            plansza_sudoku[14] = t26;
            plansza_sudoku[15] = t27;
            plansza_sudoku[16] = t28;
            plansza_sudoku[17] = t29;
            plansza_sudoku[18] = t31;
            plansza_sudoku[19] = t32;
            plansza_sudoku[20] = t33;
            plansza_sudoku[21] = t34;
            plansza_sudoku[22] = t35;
            plansza_sudoku[23] = t36;
            plansza_sudoku[24] = t37;
            plansza_sudoku[25] = t38;
            plansza_sudoku[26] = t39;
            plansza_sudoku[27] = t41;
            plansza_sudoku[28] = t42;
            plansza_sudoku[29] = t43;
            plansza_sudoku[30] = t44;
            plansza_sudoku[31] = t45;
            plansza_sudoku[32] = t46;
            plansza_sudoku[33] = t47;
            plansza_sudoku[34] = t48;
            plansza_sudoku[35] = t49;
            plansza_sudoku[36] = t51;
            plansza_sudoku[37] = t52;
            plansza_sudoku[38] = t53;
            plansza_sudoku[39] = t54;
            plansza_sudoku[40] = t55;
            plansza_sudoku[41] = t56;
            plansza_sudoku[42] = t57;
            plansza_sudoku[43] = t58;
            plansza_sudoku[44] = t59;
            plansza_sudoku[45] = t61;
            plansza_sudoku[46] = t62;
            plansza_sudoku[47] = t63;
            plansza_sudoku[48] = t64;
            plansza_sudoku[49] = t65;
            plansza_sudoku[50] = t66;
            plansza_sudoku[51] = t67;
            plansza_sudoku[52] = t68;
            plansza_sudoku[53] = t69;
            plansza_sudoku[54] = t71;
            plansza_sudoku[55] = t72;
            plansza_sudoku[56] = t73;
            plansza_sudoku[57] = t74;
            plansza_sudoku[58] = t75;
            plansza_sudoku[59] = t76;
            plansza_sudoku[60] = t77;
            plansza_sudoku[61] = t78;
            plansza_sudoku[62] = t79;
            plansza_sudoku[63] = t81;
            plansza_sudoku[64] = t82;
            plansza_sudoku[65] = t83;
            plansza_sudoku[66] = t84;
            plansza_sudoku[67] = t85;
            plansza_sudoku[68] = t86;
            plansza_sudoku[69] = t87;
            plansza_sudoku[70] = t88;
            plansza_sudoku[71] = t89;
            plansza_sudoku[72] = t91;
            plansza_sudoku[73] = t92;
            plansza_sudoku[74] = t93;
            plansza_sudoku[75] = t94;
            plansza_sudoku[76] = t95;
            plansza_sudoku[77] = t96;
            plansza_sudoku[78] = t97;
            plansza_sudoku[79] = t98;
            plansza_sudoku[80] = t99;
#endregion
        }

        private void sprawdza_liczba(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "")
            {
                if((sender as TextBox).Text[0] < '0' || (sender as TextBox).Text[9] >'9')
                {
                    MessageBox.Show("Można wpisac tylko cyfry.");
                    (sender as TextBox).Clear();
                }
            }
        }

        private void bWyczysc_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in plansza_sudoku)
            {
                t.Text = "";
                t.Enabled = true;
                t.BackColor = Color.White; 
            }
        } //czyści całą planszę

        private void bSprawdz_Click(object sender, EventArgs e)
        {
            czy_poprawnie_rozwiazane();
        }

        private int czy_pole_wypelnione() //sprawdza czy wszystkie pola sa wypełnione
        {
            for (int i=0; i < 81; i++)
            {
                if (plansza_sudoku[i].Text == "")
                {
                    return 0;
                }
            }
            return 1;
        }

        private void czy_poprawnie_rozwiazane()
        {
            if (czy_pole_wypelnione() == 1)
            {
                int[,] wiersze = new int[9, 9];
                for (int i=0, pomoc; i < 9; i++)
                {
                    for (int l=0; l < 9; l++)
                    {
                        pomoc = (9 * i) + i;
                        if (plansza_sudoku[pomoc].Text != "")
                            {
                                wiersze[i, l] = Convert.ToInt32(plansza_sudoku[pomoc].Text);
                            }
                        else
                            {
                                wiersze[i, l] = 0;
                            }
                    }
                }

                int[,] kolumny = new int[9, 9];
                for (int i=0, pomoc; i<9; i++)
                {
                    for (int k=0; k<9; k++)
                    {
                        pomoc = (9 * i) + k;
                        if (plansza_sudoku[pomoc].Text != "")
                        {
                            kolumny[i, k] = Convert.ToInt32(plansza_sudoku[pomoc].Text);
                        }
                        else
                        {
                            kolumny[i, k] = 0;
                        }
                    }
                }

                int[,] kwadraty = new int[9, 9];
                for (int i=0, pomoc; i<9; i++)
                {
                    for (int kw=0; kw < 9; kw++)
                    {
                        pomoc = ((int)((i / 3) * 27)) + 3 * (i % 3) + (kw % 3) + ((int)((kw / 3) * 9));
                        if (plansza_sudoku[pomoc].Text != "")
                        {
                            kwadraty[i, kw] = Convert.ToInt32(plansza_sudoku[pomoc].Text);
                        }
                        else
                        {
                            kwadraty[i, kw] = 0;
                        }
                    }
                }

                int[] zmienna_linie = new int[9];
                int[] zmienna_kolumny = new int[9];
                int[] zmienna_kwadraty = new int[9];
                int koniec = 0;
                for (int i=0; i<9; i++)
                {
                    for (int k=0; k<9; k++)
                    {
                        zmienna_linie[k] = wiersze[i, k];
                        zmienna_kolumny[k] = kolumny[i, k];
                        zmienna_kwadraty[k] = kwadraty[i, k];
                    }
                    //sortowanie tablic
                    Array.Sort(zmienna_linie);
                    Array.Sort(zmienna_kolumny);
                    Array.Sort(zmienna_kwadraty);
                    for (int j=0; j<9; j++)
                    {
                        if((zmienna_linie[j] != j+1)  || (zmienna_kolumny[j] != j+1) || (zmienna_kwadraty[j] != j+1))
                        {
                            MessageBox.Show("Sudoku jest źle rozwiązane!!! Popraw!!!");
                            koniec = 1;
                            break;
                        }
                        if(koniec == 1)
                        {
                            break;
                        }
                    }
                    if (koniec != 1)
                    {
                        MessageBox.Show("Udało Ci się! Gratuluję Ci! Sudoku rozwiązane porawnie!!!");
                    }         
                }
            }
            else
            {
                MessageBox.Show("Rozwiąż Sudoku do końca i potem Sprawdź!");
            }
        }

        private void bNowa_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in plansza_sudoku)
            {
                t.Text = "";
                t.Enabled = true;
                t.BackColor = Color.White;
            } //czyści planszę

        }
    }
}
