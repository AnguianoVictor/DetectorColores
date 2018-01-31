using System;

using System.Windows.Forms;

namespace Colores
{
    public partial class Init : Form
    {
        Puerto p = new Puerto();

        public Init()
        {
            InitializeComponent();
        }

        private void Init_Load(object sender, EventArgs e)
        {
            
        }

        private void Init_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p._Number=Valor.Text;
            Form1 fr = new Form1(p._Number);
            fr.Show();
        }
        private void Valor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true;
                p._Number = Valor.Text;
                Form1 fr = new Form1(p._Number);
                fr.Show();
            }
        }
    }
}
