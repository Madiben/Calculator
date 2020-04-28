using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatrice
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String firstnum,secondnum = "";
        String operationPreformed = "";
        bool isOperationPreformed = false;
        float iCelsius, iFahrenheit, ikelven;
        char ioper;
        public Form1()
        {
            InitializeComponent();
            panelscientific.Visible = false;
            panelhistory.Visible = false;
            flowLayoutPanelSP.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        protected void buttonexit_Click(object sender, EventArgs e)
        {
            Button btnex = (Button)sender;
            Application.Exit();
        }

        private void buttonminimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonac_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text="0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
        }      
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            if (textBox1.Text == "0" || (isOperationPreformed))
            {
                textBox1.Clear();
            }
            isOperationPreformed = false;
            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                {
                    textBox1.Text = textBox1.Text + button.Text;
                }
            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }           
        }
        

        private void buttonoperateur_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                buttonresult.PerformClick();
                operationPreformed = button.Text;
                isOperationPreformed = true;
                labelCurrentOperation.Text = resultValue + " " + operationPreformed;
            }
            else
            {
                operationPreformed = button.Text;
                resultValue = Double.Parse(textBox1.Text);
                isOperationPreformed = true;
                labelCurrentOperation.Text = resultValue + " " + operationPreformed;
            }
            firstnum = labelCurrentOperation.Text;
        }

        private void buttonresult_Click(object sender, EventArgs e)
        {
            secondnum = textBox1.Text;
            labelCurrentOperation.Text = "";
            switch (operationPreformed)
            {
                case "+":
                    textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "×":
                    textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "÷":
                    if (textBox1.Text != "0")
                    {
                        textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                    }
                    else { textBox1.Text = "-1"; }
                    break;
                case "Mod":
                    textBox1.Text = (resultValue % Double.Parse(textBox1.Text)).ToString();
                    break;
                case "Exp":
                    double i = double.Parse(textBox1.Text);
                    double q;
                    q = (resultValue);
                    textBox1.Text = Math.Exp(i * Math.Log(q * 4)).ToString();
                    break;

                default:
                    break;
            }
            resultValue = Double.Parse(textBox1.Text);
            if (resultValue == (-1))
            {
                textBox1.Text = "Error impo div au 0";
                labelCurrentOperation.Text = "Error impos div au 0";
                richTextBoxHistory.AppendText("\n" + firstnum + "     " + secondnum + "  =  " + "\n");
                richTextBoxHistory.AppendText("\n\t Error impo div au 0 \n\n");
            }
            else
            {
                labelCurrentOperation.Text = "";
                //// 
                richTextBoxHistory.AppendText("\n" + firstnum + "     " + secondnum + "  =  " + "\n");
                richTextBoxHistory.AppendText("\n\t" + resultValue + "\n\n");
                textBox1.Clear();
            }
        }

        private void checkBoxScientific_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScientific.Checked)
            { panelscientific.Visible = true;
                if (checkBoxtemperateur.Checked == true)
                { this.Width = 988; }
                else
                {
                    this.Width = 678;
                }
            }
            else { panelscientific.Visible = false;
                if (checkBoxHistory.Checked == false && checkBoxScientificProgrammable.Checked == false && checkBoxtemperateur.Checked == false)
                {
                    this.Width = 335;
                }
                else { if(checkBoxtemperateur.Checked==true)
                    { this.Width = 988; }
                }
                 }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void labelCurrentOperation_Click(object sender, EventArgs e)
        {

        }

        private void buttoncleanhistory_Click(object sender, EventArgs e)
        {
            richTextBoxHistory.Clear();
        }

        private void checkBoxHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHistory.Checked)
            {
                panelhistory.Visible = true;
                checkBoxScientificProgrammable.Checked = false;
                if (checkBoxtemperateur.Checked == true)
                { this.Width = 988; }
                else
                {
                    this.Width = 678;
                }
            }
            else
            {
                panelhistory.Visible = false;
                if (checkBoxScientificProgrammable.Checked == false && checkBoxScientific.Checked == false && checkBoxtemperateur.Checked == false)
                {
                    this.Width = 335;
                }
                else
                {
                    if (checkBoxtemperateur.Checked == true)
                    { this.Width = 988; }
                }
            }
        }

        private void checkBoxScientificProgrammable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScientificProgrammable.Checked)
            {
                flowLayoutPanelSP.Visible = true;
                checkBoxHistory.Checked = false;
                if (checkBoxtemperateur.Checked == true)
                { this.Width = 988; }
                else
                {
                    this.Width = 678;
                }
            }
            else
            {
                flowLayoutPanelSP.Visible = false;
                if(checkBoxHistory.Checked==false && checkBoxScientific.Checked==false && checkBoxtemperateur.Checked == false)
                {
                    this.Width = 335;
                }
                else
                {
                    if (checkBoxtemperateur.Checked == true)
                    { this.Width = 988; }
                }
            }
        }

        private void checkBoxtemperateur_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxtemperateur.Checked==true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                checkBoxmulti.Checked = false;
                
                this.Width = 988;
            }
            else
            {
                groupBox1.Visible = false;
                if (checkBoxHistory.Checked == false && checkBoxScientific.Checked == false && checkBoxScientificProgrammable.Checked == false)
                {
                    this.Width = 335;
                }
                else { this.Width = 678; }
            }
            
        }

        private void checkBoxmulti_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxmulti.Checked == true)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                checkBoxtemperateur.Checked = false;
                this.Width = 988;
            }
            else
            {
                groupBox2.Visible = false;
                if (checkBoxHistory.Checked == false && checkBoxScientific.Checked == false && checkBoxScientificProgrammable.Checked == false)
                {
                    this.Width = 335;
                }
                else { this.Width = 678; }
            }
        }

        private void buttonrtrn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text== "")
            {
                textBox1.Text = "0";
            }
        }

        private void buttonpi_Click(object sender, EventArgs e)
        {
            double a;
            a = Math.PI;
            textBox1.Text = System.Convert.ToString( a);
        }

        
        private void buttonlog_Click(object sender, EventArgs e)
        {
            double ilog = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("log" + "(" + (textBox1.Text) + ")");
            ilog = Math.Log10(ilog);
            textBox1.Text = System.Convert.ToString(ilog);
        }

        private void buttoncosh_Click(object sender, EventArgs e)
        {
            double acosh = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("Cosh" + "(" + (textBox1.Text) + ")");
            acosh = Math.Cosh(acosh);
            textBox1.Text = System.Convert.ToString(acosh);
        }

        private void buttoncos_Click(object sender, EventArgs e)
        {
            double acos = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("Cos" + "(" + (textBox1.Text) + ")");
            acos = Math.Cos(acos);
            textBox1.Text = System.Convert.ToString(acos);
        }

        private void buttonsinh_Click(object sender, EventArgs e)
        {
            double asinh = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("Sinh" + "(" + (textBox1.Text) + ")");
            asinh = Math.Sinh(asinh);
            textBox1.Text = System.Convert.ToString(asinh);
        }

        private void buttonsin_Click(object sender, EventArgs e)
        {
            double asin = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("Sin" + "(" + (textBox1.Text) + ")");
            asin = Math.Cosh(asin);
            textBox1.Text = System.Convert.ToString(asin);
        }

        private void buttontanh_Click(object sender, EventArgs e)
        {
            double atanh = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("Tanh" + "(" + (textBox1.Text) + ")");
            atanh = Math.Tanh(atanh);
            textBox1.Text = System.Convert.ToString(atanh);
        }

        private void buttontan_Click(object sender, EventArgs e)
        {
            double atan = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("Tan" + "(" + (textBox1.Text) + ")");
            atan = Math.Tan(atan);
            textBox1.Text = System.Convert.ToString(atan);
        }

        private void buttonbin_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(i, 2);
        }

        private void buttonOct_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(i, 8);
        }

        private void buttondec_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(i);
        }

        private void buttonHex_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(i, 16);
        }

        private void buttonxcare_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(textBox1.Text)* Convert.ToDouble(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void buttonoC_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "(";
        }

        private void buttonoD_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text+")";
        }

        private void buttonxtriple_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button1ax_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(1.0/ Convert.ToDouble(textBox1.Text));
            textBox1.Text = System.Convert.ToString(a);
        }

        private void buttonxamili_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(textBox1.Text);
            int i = Convert.ToInt32(textBox1.Text);
            if (i > 1)
            {
                while (i > 1)
                {
                    a = a * (i - 1);
                    i = i - 1;
                }
                textBox1.Text = System.Convert.ToString(a);
            }
            else { textBox1.Text ="1"; }
        }

        private void buttonPercnt_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(textBox1.Text) / Convert.ToDouble(100);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button10x_Click(object sender, EventArgs e)
        {
            double a;
            a = Math.E;
            textBox1.Text = System.Convert.ToString(a);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ioper = 'C';
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ioper = 'F';
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ioper = 'K';
        }

        private void buttonconvetemp_Click(object sender, EventArgs e)
        {
            switch(ioper)
            {
                case 'C':
                    //Celsius to Fahrenheit
                    iCelsius = float.Parse(textBoxvaluetemp.Text);
                    textBoxresulttemp.Text = ((((9 * iCelsius) / 5) + 32).ToString());

                    break;
                case 'F':
                    //Fahrenheit to Celsius
                    iFahrenheit = float.Parse(textBoxvaluetemp.Text);
                    textBoxresulttemp.Text = ((((iFahrenheit-32) * 5) / 9).ToString());
                    break;
                case 'K':
                    //Convert to Kelven
                    ikelven= float.Parse(textBoxvaluetemp.Text);
                    textBoxresulttemp.Text = (((((9* ikelven) / 5) +32)+273.15).ToString());
                    break;
                default:
                    textBoxresulttemp.Text = "Error please Pick a type of conversation";
                    break;

            }
        }

        private void buttonresettemp_Click(object sender, EventArgs e)
        {
            textBoxresulttemp.Clear();
            textBoxvaluetemp.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void buttonmultiplication_Click_1(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(textBoxnumro.Text);
            for (int i = 1; i < 20; i++)
            {
                listBoxmultiplication.Items.Add(i + " × " + a + "=" + i * a);
            }
        }

        private void buttonreset_Click_1(object sender, EventArgs e)
        {
            textBoxnumro.Clear();
            listBoxmultiplication.Items.Clear();
        }

        private void listBoxmultiplication_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxnumro_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Opera", "http://meeedy.blogspot.com");
        }

        private void buttonlnx_Click(object sender, EventArgs e)
        {
            double ilog = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("ln" + "(" + (textBox1.Text) + ")");
            ilog = Math.Log(ilog);
            textBox1.Text = System.Convert.ToString(ilog);
        }

        private void buttonichra_Click(object sender, EventArgs e)
        {
            double a;
            a = double.Parse(textBox1.Text);
            if (a > 0)
            {
                textBox1.Text = System.Convert.ToString(a*(-1));
            }
            else
            {
                textBox1.Text = System.Convert.ToString(a * (-1));
            }
        }

        private void buttonsqrt_Click(object sender, EventArgs e)
        {
            double sq = double.Parse(textBox1.Text);
            labelCurrentOperation.Text = System.Convert.ToString("√" + "(" + (textBox1.Text) + ")");
            sq = Math.Sqrt(sq);
            textBox1.Text = System.Convert.ToString(sq);
        }
        
    }
}
