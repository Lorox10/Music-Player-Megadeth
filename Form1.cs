using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Rincon_de_Megadeth
{
    public partial class Bienvenida : Form
    {
         
        public Bienvenida()
        {
            InitializeComponent();
            timer = new Timer();
           
            
        }
        private Timer timer;
        private void btnCerrar1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            pctcargando.Visible = true;
            lblCargando.Visible = true;
            pctPerromovimiento.Visible = true;
            btnCerrar1.Visible = false;
            btnContinuar1.Visible = false;

            timer.Interval = 2400;
            timer.Tick += (s, args) =>
            {
               
                timer.Stop();
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            };

            // Iniciar el temporizador
            timer.Start();
        }
        private void Timer_Tick1(object sender, EventArgs e)
        {
            // Detener el Timer después de x segundos
            timer.Stop();

            // Ocultar o eliminar el PictureBox
            
           
             // O bien, puedes usar: Controls.Remove(pctBienvenidos);
            
            // Aquí puedes realizar otras acciones después de que la imagen se haya mostrado durante 2 segundos
            pctLogomegadeth.Visible = true;
            btnCerrar1 .Visible = true;
            btnContinuar1 .Visible = true;
            


        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
           
            timer = new Timer();
            timer.Interval = 0001; // 1000 ms = 1 segundos
            timer.Tick += Timer_Tick1; // Asociar el evento Tick al método Timer_Tick
            
            
            timer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
