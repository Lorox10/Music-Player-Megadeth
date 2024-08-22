using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using AxWMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace El_Rincon_de_Megadeth
{
    public partial class Menu : Form
    {
        private WindowsMediaPlayer reproductor;

        public Menu()
        {
            InitializeComponent();
            reproductor = new WindowsMediaPlayer();
            

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Bienvenida bienvenida = new Bienvenida();
            bienvenida.Show();
            this.Close();
            
        }

        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctDave_Click(object sender, EventArgs e)
        {

        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            reproductor.controls.stop();
            panelVideo.Visible = true;
            btnMenu.Visible = true;
            btnVideo.Visible = false;
            btnMusica.Visible = true;
            btnCreditos.Visible = true;
            btnGaleria.Visible = true;
            panelMusica.Visible = false;
            panelGaleria.Visible=false;
            panelCreditos.Visible = false;

        }

        private void btnMusica_Click(object sender, EventArgs e)
        {
            VideoPlay.Ctlcontrols.stop();
            panelMusica.Visible = true;
            btnMenu.Visible = true;
            btnMusica.Visible = false;
            btnCreditos.Visible = true;
            btnGaleria.Visible = true;
            btnVideo.Visible = true;
            panelVideo.Visible = false;
            panelGaleria.Visible = false;
            panelCreditos.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            panelMusica.Visible=false;
            btnGaleria.Visible = true;
            btnVideo.Visible = true;
            btnMusica.Visible = true;
            btnCreditos.Visible = true;
            btnMenu.Visible = false;
            panelVideo.Visible = false;
            panelGaleria.Visible = false;
            panelCreditos.Visible = false;


        }

        private void btnGaleria_Click(object sender, EventArgs e)
        {
            panelGaleria.Visible=true;
            btnMenu.Visible = true;
            btnGaleria.Visible = false;
            btnVideo.Visible = true;
            btnMusica.Visible = true;
            btnCreditos.Visible = true;
            panelMusica.Visible = false;
            panelVideo.Visible = false;
            panelCreditos.Visible = false;

        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            if (VideoPlay != null)
            {
                VideoPlay.Ctlcontrols.stop(); 
            }
            if (reproductor != null)
            {
                reproductor.controls.stop(); 
            }
            if (ReproductorCreditos != null)
            {
                LoadVideo(Properties.Resources.Devil_Island_Cover);
                ReproductorCreditos.Ctlcontrols.play();
            }
            btnMenu.Visible = true;
            btnCreditos.Visible = false;
            btnGaleria.Visible = true;
            btnVideo.Visible = true;
            btnMusica.Visible = true;

            panelMusica.Visible = false;
            panelVideo.Visible = false;
            panelGaleria.Visible = false;
            panelCreditos.Visible = true;
        }

        private double volumen = 50;
        private void btnPausar_Click(object sender, EventArgs e)
        {
            pctElectric1.Visible = false;
            pctElectric2.Visible = false;
            pctElectric3.Visible = false;
            if (reproductor != null && reproductor.playState == WMPPlayState.wmppsPlaying)
            {
                posicionDeReproduccion = reproductor.controls.currentPosition;
                volumen = reproductor.settings.volume;

                reproductor.controls.pause();

                reproduccionPausada = true;
            }
        }

        private double posicionDeReproduccion = 0;
        private bool reproduccionPausada = false;

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            btnReproducir.BackgroundImageLayout = ImageLayout.Stretch;
            string cancion = comboMusica.Text;
            reproductor.settings.volume = 50;
            switch (cancion)
            {
                case "In My Darkest Hour":
                case "Symphony Of Destruction":
                case "The Killing Road":
                case "Five Magics":
                case "Family Tree":
                case "Time The Beginning":
                    if (reproductor != null)
                    {
                        reproductor.controls.stop();
                        reproductor.close();
                    }
                    reproductor = new WindowsMediaPlayer();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        if (cancion == "In My Darkest Hour")
                        {
                            Properties.Resources.In_My_Darkest_Hour.CopyTo(ms);
                        }
                        else if (cancion == "Symphony Of Destruction")
                        {
                            Properties.Resources.Symphony_Of_Destruction.CopyTo(ms);
                        }

                        else if (cancion == "The Killing Road")
                        {
                            Properties.Resources.The_Killing_Road.CopyTo(ms);
                        }

                        else if (cancion == "Five Magics")
                        {
                            Properties.Resources.Five_Magics.CopyTo(ms);
                        }

                        else if (cancion == "Family Tree")
                        {
                            Properties.Resources.Family_Tree.CopyTo(ms);
                        }

                        else if (cancion == "Time The Beginning")
                        {
                            Properties.Resources.Time_The_Beginning.CopyTo(ms);
                        }

                        byte[] audioBytes = ms.ToArray();

                        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), ".mp3");
                        File.WriteAllBytes(tempFile, audioBytes);

                        reproductor.URL = tempFile;
                    }

                    reproductor.controls.currentPosition = posicionDeReproduccion;
                    reproductor.controls.play();
                    reproduccionPausada = false;
                    break;
                default:
                   
                    break;
            }
            pctElectric1.Visible = true;
            pctElectric2.Visible = true;
            pctElectric3.Visible = true;


        }


        private void btnDetener_Click(object sender, EventArgs e)
        {
            pctElectric1.Visible = false;
            pctElectric2.Visible = false;
            pctElectric3.Visible = false;
            if (reproductor != null)
            {
                reproductor.controls.stop();
                reproductor.close();
                reproduccionPausada = false; 
                posicionDeReproduccion = 0;
                reproductor.settings.volume = 50;
            }
        }

        public void ActualizarDatosTrack()
        {

        }

        private void TrackVolumen_Scroll(object sender, EventArgs e)
        {
            if (reproductor != null && TrackVolumen != null)
            {
                int volumen = TrackVolumen.Value;
                reproductor.settings.volume = volumen;
            }
        }

        private void panelMusica_Paint(object sender, PaintEventArgs e)
        {

        }
            
         private void pctAlbum_Click(object sender, EventArgs e)
         {
           
         }

        private void comboMusica_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboMusica.Text== "")
            {
                btnReproducir.Visible = false;
            }
            else
            {
                btnReproducir.Visible = true;
            }
            switch (comboMusica.Text)
            {
                case "In My Darkest Hour":
                    pctAlbum.Visible = true;
                    pctAlbum.Image = Properties.Resources.giphy;
                    txtCuriosidades.Visible = true;
                    txtCuriosidades.Text = "\"In My Darkest Hour\" fue grabada en un momento particularmente difícil para Megadeth. Durante la producción del álbum \"So Far, So Good... So What!\", la banda estaba luchando con problemas personales y adicciones. La canción misma refleja este período turbulento, con letras que expresan sentimientos de dolor y desesperación. A pesar de estas dificultades, \"In My Darkest Hour\" se convirtió en uno de los éxitos más duraderos de Megadeth y ha sido aclamada como una de sus mejores composiciones.\r\n";

                    break;
                case "Symphony Of Destruction":
                    pctAlbum.Visible = true;
                    pctAlbum.Image = Properties.Resources.giphy__1_;
                    txtCuriosidades.Visible = true;
                    txtCuriosidades.Text = "\"Symphony of Destruction\" fue inspirada por la política y la corrupción en el gobierno. Las letras de la canción, escritas por Dave Mustaine, abordan temas como el abuso de poder y la manipulación de masas. A pesar de su crítica social, la canción se convirtió en uno de los mayores éxitos comerciales de Megadeth.";

                    break;
                case "The Killing Road":
                    pctAlbum.Visible = true;
                    pctAlbum.Image = Properties.Resources._8tXl;
                    txtCuriosidades.Visible = true;
                    txtCuriosidades.Text = "\"The Killing Road\" fue escrita por Dave Mustaine durante un período en el que estaba reflexionando sobre su vida en la carretera como músico. La canción aborda los desafíos y peligros asociados con giras extensas, incluyendo la soledad, el agotamiento y las tentaciones. Aunque es una canción menos conocida en comparación con otros éxitos de Megadeth, sigue siendo una favorita entre los fanáticos por su poderosa energía y letras introspectivas.";

                    break;
                case "Family Tree":
                    pctAlbum.Visible = true;
                    pctAlbum.Image= Properties.Resources._8tXl;
                    txtCuriosidades.Visible = true;
                    txtCuriosidades.Text = "\r\n\"Family Tree\" trata sobre la historia personal de Dave Mustaine y su relación con su familia. En la letra, Mustaine reflexiona sobre su infancia, las experiencias difíciles que enfrentó y cómo estas influenciaron su vida y carrera. Es una canción introspectiva que ofrece una mirada más profunda al lado personal del líder de Megadeth.";

                    break;
                case "Five Magics":
                    pctAlbum.Visible= true;
                    pctAlbum.Image = Properties.Resources.CZpF;
                    txtCuriosidades.Visible = true;
                    txtCuriosidades.Text = "\"Five Magics\" está inspirada en la película \"The Sword and the Sorcerer\" (\"La espada y el hechicero\"). La película, lanzada en 1982, presenta elementos de fantasía y magia, y parece haber influido en la temática de la canción. \"Five Magics\" explora la idea de dominar cinco formas diferentes de magia y fue parte del álbum \"Rust in Peace\", que es considerado uno de los mejores trabajos de Megadeth.";

                    break;
                case "Time The Beginning":
                    pctAlbum.Visible = true;
                    pctAlbum.Image = Properties.Resources.I08L;
                    txtCuriosidades.Visible = true;
                    txtCuriosidades.Text = "\"Time: The Beginning\" es una canción del álbum \"Risk\" de Megadeth, lanzado en 1999. Esta canción marca un cambio en el sonido de la banda hacia un estilo más experimental y orientado al rock alternativo. Aunque \"Risk\" fue un álbum controvertido entre los fanáticos debido a su desviación del sonido thrash metal característico de Megadeth, \"Time: The Beginning\" destaca por su atmósfera melódica y letras introspectivas sobre el paso del tiempo y la nostalgia.";
                    break;

                default:
                    
                    break;
            }
        }

        private void panelVideo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                LoadVideo(Properties.Resources.Wake_Up_Dead);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                LoadVideo(Properties.Resources.In_My_Darkest_Hour1);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                LoadVideo(Properties.Resources.Holy_Wars);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
                LoadVideo(Properties.Resources.Sweating_Bullets);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                LoadVideo(Properties.Resources.Almost_Honest);
            }
        }

        private void LoadVideo(byte[] videoBytes)
        {
            string tempVideoPath = Path.GetTempFileName();
            File.WriteAllBytes(tempVideoPath, videoBytes);
            VideoPlay.URL = tempVideoPath;
            ReproductorCreditos.URL = tempVideoPath;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void panelGaleria_Paint(object sender, PaintEventArgs e)
        {
            pctPrincipal.Image = Properties.Resources.A1;
            pct1.Image = Properties.Resources._12;
            pct2.Image = Properties.Resources._1;
            pct3.Image = Properties.Resources._13;
            pct4.Image = Properties.Resources._2;
            pct5.Image = Properties.Resources._3;
            pct6.Image = Properties.Resources._4;
            pct7.Image = Properties.Resources._5;
            pct8.Image = Properties.Resources._6;
            pct9.Image = Properties.Resources._7;
            pct10.Image = Properties.Resources._8;
            pct11.Image = Properties.Resources._9;
            pct12.Image = Properties.Resources._11;
        }

        private void movimiento(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._12;
        }

        private void pct2_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._1;
        }

        private void pct3_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._13;
        }

        private void pct4_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._2;
        }

        private void pct5_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._3;
        }

        private void pct6_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._4;
        }

        private void pct7_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._5;
        }

        private void pct8_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._6;
        }

        private void pct9_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._7;
        }

        private void pct10_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._8;
        }

        private void pct11_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._9;
        }

        private void pct12_MouseHover(object sender, EventArgs e)
        {
            pctPrincipal.Image = Properties.Resources._11;
        }

        private void panelCreditos_Paint(object sender, PaintEventArgs e)
        {
            LoadVideo(Properties.Resources.Devil_Island_Cover);
            ReproductorCreditos.Ctlcontrols.play();
            txtNombre.Text = "Desarrollado Por Lorenzo Vargas Sala - Programador";
        }

        private void ReproductorCreditos_Enter(object sender, EventArgs e)
        {
            
        }
       
    }
}
