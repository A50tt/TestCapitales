using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace TestAboutCapitals
{
    public partial class RecordEntry : Form
    {
        private readonly string RECORD_ENTRY_SONG_PATH = "\\assets\\music\\RecordEntry.wma";

        public RecordEntry()
        {
            InitializeComponent();
            if (Program.muteMusic == false)
            {
                this.muteVolumeButton.ImageIndex = 0;
            }
            else
            {
                this.muteVolumeButton.ImageIndex = 1;
            }
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic * 100) + "%";
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteRecordUserRegister();
        }

        public void ExecuteRecordUserRegister()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestAboutCapitals\" + Operations.SCOREBOARD_FILE_PATH));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                DateTime date = DateTime.Now;
                file.Write((Operations.getMaxIdPlayer()+1) + "|" + this.textBox1.Text + "|" + Program.ActualScore + "|" + Program.GameMode + "|" + date + ";");
            }

            this.Hide();
            ClearAllGlobalVariables();
            Program.StopMedia();
            Initialize form1 = new Initialize();
            form1.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteRecordUserRegister();
            }
        }

        private void ClearAllGlobalVariables()
        {
            Program.BestUserName10.Clear();
            Program.BestScore10.Clear();            
            Program.BestUserName20.Clear();
            Program.BestScore20.Clear();            
            Program.BestUserName30.Clear();
            Program.BestScore30.Clear();
            Program.RandomOrder.Clear();
            Program.FourCountries.Clear();
            Program.FourCapitals.Clear();
            Program.RandomIDs.Clear();
            Program.ActualScore = 0;
            Program.TriesLeft = 0;
            Program.AlreadyCountries.Clear();
            Program.QuestionNum = 1;
        }

        private void RecordEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void muteVolumeButton_Click(object sender, EventArgs e)
        {
            //volume off
            if (this.muteVolumeButton.ImageIndex == 0)
            {
                Program.MuteMedia();
                this.muteVolumeButton.ImageIndex = 1;
                return;
            }

            //volume on
            if (this.muteVolumeButton.ImageIndex == 1)
            {
                Program.UnmuteMedia();
                this.muteVolumeButton.ImageIndex = 0;
                return;
            }
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic * 100) + "%";
        }

        private void plusVolumeBut_Click(object sender, EventArgs e)
        {
            //volume off
            if (this.muteVolumeButton.ImageIndex == 0)
            {
                if (Program.volumeMusic <= 0.9)
                {
                    Program.volumeMusic += 0.1;
                    Program.mediaElement.Volume = Program.volumeMusic;
                }
            }
            //volume on
            if (this.muteVolumeButton.ImageIndex == 1)
            {
                if (Program.recoveryVolumeMusic <= 0.9)
                {
                    Program.recoveryVolumeMusic += 0.1;
                    Program.volumeMusic += 0.1;
                }
            }
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic * 100) + "%";
        }

        private void minusVolumeBut_Click(object sender, EventArgs e)
        {
            //volume off
            if (this.muteVolumeButton.ImageIndex == 0)
            {
                if (Program.volumeMusic >= 0.1)
                {
                    Program.volumeMusic -= 0.1;
                    Program.mediaElement.Volume = Program.volumeMusic;
                }
            }
            //volume on
            if (this.muteVolumeButton.ImageIndex == 1)
            {
                if (Program.recoveryVolumeMusic >= 0.1)
                {
                    Program.recoveryVolumeMusic -= 0.1;
                    Program.volumeMusic -= 0.1;
                }
            }
            if (Program.volumeMusic == 2.7755575615628914E-17)
            {
                this.volumeLevel.Text = Convert.ToString(0) + "%";
            }
            else
            {
                this.volumeLevel.Text = Convert.ToString(Program.volumeMusic * 100) + "%";
            }
        }
    }
}
