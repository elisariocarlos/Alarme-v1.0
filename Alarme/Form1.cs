using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;  // Para tocar música


namespace Alarme
{
    public partial class Form1 : Form
    {
        private int alarmHour;
        private int alarmMinute;
        private Timer timerAlarme = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Captura os valores das ComboBox
            alarmHour = Convert.ToInt32(comboBoxHour.SelectedItem);
            alarmMinute = Convert.ToInt32(comboBoxMinute.SelectedItem);

            // Iniciar o timer
            timerAlarme.Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configura o Timer para verificar a cada 1000 ms (1 segundo)
            timerAlarme.Interval = 1000;
            timerAlarme.Tick += new EventHandler(timerAlarme_Tick);
        }

        private void timerAlarme_Tick(object sender, EventArgs e)
        {
            // Verificar o horário atual
            DateTime now = DateTime.Now;

            // Verifica se a hora e minuto atuais correspondem ao definido pelo usuário
            if (now.Hour == alarmHour && now.Minute == alarmMinute)
            {
                // Parar o Timer, pois o alarme disparou
                timerAlarme.Stop();

                // Exibir a caixa de diálogo
                MessageBox.Show("Hora do alarme!", "Alarme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tocar a música (ajuste o caminho do arquivo de música)
                SoundPlayer player = new SoundPlayer(@"C:\Caminho\para\sua\musica.wav");
                player.Play();
            }
        }
    }
}
