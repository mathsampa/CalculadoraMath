using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        private decimal total = 0;
        private decimal valor1 = 0;
        private decimal valor2 = 0;
        private string operacao = "";
        private bool finalizado = false;

        #region Numeros

        public frmCalculadora()
        {
            InitializeComponent();
        }
        //Função dos botões.
        private void btn1_Click(object sender, EventArgs e)
        {
            displayNumber("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            displayNumber("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            displayNumber("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            displayNumber("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            displayNumber("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            displayNumber("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            displayNumber("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            displayNumber("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            displayNumber("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            displayNumber("0");
        }

        #endregion

        #region Teclas especiais

        private void btnCE_Click(object sender, EventArgs e)
        {
            LimpaTela();
            total = 0;
            valor1 = 0;
            valor2 = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.ToString().Contains(",") == false && txtDisplay.Text.Length > 0)
            {
                displayNumber(",");
            }
        }
        private void btnPi_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.ToString().Contains("3.14159265359") == false)
            {
                displayNumber("3.14159265359");
            }
        }

        #endregion

        #region Operações

        private void btnEqual_Click(object sender, EventArgs e)
        {
            // se nao tiver valor em 2 quando apertar o igual 
            // recebemos o display e colocamos em 2
            if (valor2 <= 0)
            {
                valor2 = decimal.Parse(txtDisplay.Text);
            }

            if (operacao == "+")
            {
                total = valor1 + valor2;
            }
            else if (operacao == "-")
            {
                total = valor1 - valor2;
            }
            else if (operacao == "/")
            {
                if (valor2 > 0)
                {
                    total = valor1 / valor2;
                }
                else
                {
                    MessageBox.Show("Não pode dividir por zero!", ":: Erro ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operacao == "*")
            {
                total = valor1 * valor2;
            }
            else if (operacao == "%")
            {
                total = valor1 / 100 * valor2;
            }
            else if (operacao == "+/-")
            {
                total = valor1 * -1;
            }
            else if (operacao == "√")
            {
                total = ((decimal)Math.Sqrt(Convert.ToDouble(valor1)));
            }

            else if (operacao == "x²")
            {
                total = (decimal)Math.Pow(Convert.ToDouble(valor1), Convert.ToDouble(valor2));
            }

            #endregion

        #region Display

            txtDisplay.Text = total.ToString();

            total = 0;
            valor1 = 0;
            valor2 = 0;
            finalizado = true;
        }

        #endregion

        #region Sinais

        private void btnPlus_Click(object sender, EventArgs e)
        {
            addNumber("+");
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            addNumber("-");
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            addNumber("*");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            addNumber("/");
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            addNumber("%");
        }

        private void btnPlusToLess_Click(object sender, EventArgs e)
        {
            addNumber("+/-");
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            addNumber("√");
            valor2 = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNumber("x²");
        }

        #endregion

        #region LimpaTela

        private void addNumber(string operacao)
        {
            this.operacao = operacao;

            if (valor1 <= 0)
            {
                valor1 = decimal.Parse(txtDisplay.Text);
                LimpaTela();
            }
            else
            {
                // preencher somente se o valor de 1 existir
                // quaramos o dsiplay em 2
                valor2 = decimal.Parse(txtDisplay.Text);
                LimpaTela();
            }
        }

        private void displayNumber(string number)
        {

            // quando a conta estiver finalizada entao
            // limpamos o display antes de inserir 
            // novos numeros.
            if (finalizado)
            {
                finalizado = false;
                LimpaTela();
            }

            txtDisplay.Text += number;
        }

        private void LimpaTela()
        {
            txtDisplay.Text = "";
        }

        #endregion    

        #region Teclado

        private void frmCalculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char tecla = e.KeyChar;

            if (numeros.Contains(tecla))
            {
                displayNumber(tecla.ToString());
            }
            else if (tecla == '\b')
            {
                btnBack.Focus();
                btnBack_Click(sender, e);
            }
            else if (tecla == '\u001b')
            {
                btnCE.Focus();
                btnCE_Click(sender, e);
            }
            else if (tecla == ',')
            {
                if (txtDisplay.Text.ToString().Contains(",") == false && txtDisplay.Text.Length > 0)
                {
                    displayNumber(",");
                }

                #endregion
           
           }
        }
    }
}