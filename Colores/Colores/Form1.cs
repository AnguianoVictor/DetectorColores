using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Colores
{
    public partial class Form1 : Form
    {
        SerialPort Arduino;
        Puerto p = new Puerto();
        public Form1()
        {
        }

        public Form1(String puerto)
        {
            string com = puerto;
            p.com = puerto;
            try
            {
                Arduino = new SerialPort(com.ToString(), 9600);
            }
            catch (UnauthorizedAccessException er)
            {
                MessageBox.Show("El Puerto COM ya esta abierto");
                Application.Exit();
            }
            catch (ArgumentOutOfRangeException err)
            {
                MessageBox.Show("Las propiedades del puerto COM no son validas");
                Application.Exit();
            }
            catch (ArgumentException error)
            {
                MessageBox.Show("Verifica el nombre del puerto");
                Application.Exit();
            }
            catch (IOException error1)
            {
                MessageBox.Show("El puerto no existe");
                Application.Exit();
            }
            catch (InvalidOperationException error2)
            {
                MessageBox.Show("El puerto ya esta abierto");
                Application.Exit();
            }
            InitializeComponent();
            try
            {
                Arduino.DataReceived += Arduino_DataReceived;
            }
            catch (NullReferenceException e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            label1.Text = String.Format("La comunicacion se realiza en {0}", p.com.ToString());
}

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.label10.Text = String.Format("La comunicacion se realiza en {0} a 9600bps", p.com.ToString());
                Arduino.Open();
            }
            catch (UnauthorizedAccessException er)
            {
                MessageBox.Show("El Puerto COM ya esta abierto");
                Application.Exit();
            }
            catch (ArgumentOutOfRangeException err)
            {
                MessageBox.Show("Las propiedades del puerto COM no son validas");
                Application.Exit();
            }
            catch (ArgumentException error)
            {
                MessageBox.Show("Verifica el nombre del puerto");
                Application.Exit();
            }
            catch (IOException error1)
            {
                MessageBox.Show("El puerto no existe");
                Application.Exit();
            }
            catch (InvalidOperationException error2)
            {
                MessageBox.Show("El puerto ya esta abierto");
                Application.Exit();
            }
            catch (NullReferenceException error3)
            {
                MessageBox.Show("El objeto SerialPort no se ha creado");
                Application.Exit();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Application.Exit();
        }

        private void Arduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string POT = Arduino.ReadLine();
                this.BeginInvoke(new LineReceivedEvent(LineReceived), POT);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

    private delegate void LineReceivedEvent(string POT);

    private void LineReceived(string POT)
    {
        #region VariablesAux
        int voltaje;
        int aux1;
        double aux;
        string data = POT;
        string bin = data.Substring(0, 1);
        string volt = data.Substring(1, data.Length - 1);
        int binario = int.Parse(bin);
        voltaje = int.Parse(volt);
        Valor.Text = volt;
        #endregion
        #region EncendidoDeLeds
        if (binario == 0)
        {
            rojo.BackColor = Color.Transparent;
            verde.BackColor = Color.Transparent;
            azul.BackColor = Color.Transparent;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 1)
        {
            rojo.BackColor = Color.Red;
            verde.BackColor = Color.Transparent;
            azul.BackColor = Color.Transparent;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 2)
        {
            rojo.BackColor = Color.Transparent;
            verde.BackColor = Color.Green;
            azul.BackColor = Color.Transparent;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 3)
        {
            rojo.BackColor = Color.Red;
            verde.BackColor = Color.Green;
            azul.BackColor = Color.Transparent;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 4)
        {
            rojo.BackColor = Color.Transparent;
            verde.BackColor = Color.Transparent;
            azul.BackColor = Color.Blue;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 5)
        {
            rojo.BackColor = Color.Red;
            verde.BackColor = Color.Transparent;
            azul.BackColor = Color.Blue;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 6)
        {
            rojo.BackColor = Color.Transparent;
            verde.BackColor = Color.Green;
            azul.BackColor = Color.Blue;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 7)
        {
            rojo.BackColor = Color.Red;
            verde.BackColor = Color.Green;
            azul.BackColor = Color.Blue;
            blanco.BackColor = Color.Transparent;
        }
        else if (binario == 8)
        {
            rojo.BackColor = Color.Transparent;
            verde.BackColor = Color.Transparent;
            azul.BackColor = Color.Transparent;
            blanco.BackColor = Color.White;
        }
        #endregion
        #region LecturaAnalogico
        if (962 < voltaje)
        {
            button1.BackColor = Color.Black;
        }
        else if (890 < voltaje && voltaje < 900)
        {
            button1.BackColor = Color.DarkBlue;
        }
        else if (857 < voltaje && voltaje <= 888)
        {
            button1.BackColor = Color.Red;
        }
        else if (760 < voltaje && voltaje < 840)
        {
            button1.BackColor = Color.Chartreuse;
        }
        else if (670 < voltaje && voltaje < 758)
        {
            button1.BackColor = Color.Orange;
        }
        else if (610 < voltaje && voltaje < 669)
        {
            button1.BackColor = Color.Cyan;
        }
        else if (600 > voltaje)
        {
            button1.BackColor = Color.White;
        }
        #endregion
        #region Vista
        aux = voltaje * (5.0 / 1023);
        aux1 = Convert.ToInt32(aux);
        string valores = Convert.ToString(aux);
        try
        {
            string valor2dec = valores.Substring(0, 4);
            label2.Text = valor2dec + " V";
        }
        catch
        {
            label2.Text = valores + ".00 V";
        }
        try
        {
            progressBar1.Value = Convert.ToInt32((100 / 5.5) * aux1);
        }
        catch (Exception e)
        {
            MessageBox.Show("Reinicia la aplicacion", "Error de Arranque", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


    }

    private void ROJO_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void label10_Click(object sender, EventArgs e)
    {

    }
}
}
