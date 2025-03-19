using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAboutCapitals
{
    public partial class Initialize : Form {

        string MAIN_MENU_SONG_PATH = "\\assets\\music\\GustyGarden.wma";
        string FIRST_LEVEL_SONG_PATH = "\\assets\\music\\TryTryAgain.wma";
        string SECOND_LEVEL_SONG_PATH = "\\assets\\music\\Rooftop.wma";
        string THIRD_LEVEL_SONG_PATH = "\\assets\\music\\TheMoonOrchestraEdit.wma";
    
        public Initialize()
        {
            InitializeComponent();
            if (Program.alreadyRetrievedCapitals == false)
            {
                Operations.RetrieveAllData();
            }

            Operations.GetScoreboard();
            UpdateScoresInEntryForm();

            if (Program.isPrimeMusicOn == false)
            {
                Program.SetStartMedia(MAIN_MENU_SONG_PATH, Program.volumeMusic);
                Program.isPrimeMusicOn = true;
            }
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic * 100) + "%";
        }

        public void UpdateScoresInEntryForm()
        {
            int start10 = 0;
            int at10 = 0;
            int start20 = 0;
            int at20 = 0;
            int start30 = 0;
            int at30 = 0;
            Program.BestScore10.Clear();
            Program.BestScore20.Clear();
            Program.BestScore30.Clear();


            foreach (int gmode in Program.AllGameModesScoreboard)
            {
                if (gmode == 10)
                {
                    at10 = Program.AllGameModesScoreboard.IndexOf(gmode, start10);
                    Program.BestScore10.Add(Program.AllScoreScoreboard[at10]);
                    start10 = at10 + 1;
                }
                if (gmode == 20)
                {
                    at20 = Program.AllGameModesScoreboard.IndexOf(gmode, start20);
                    Program.BestScore20.Add(Program.AllScoreScoreboard[at20]);
                    start20 = at20 + 1;
                }
                if (gmode == 30)
                {
                    at30 = Program.AllGameModesScoreboard.IndexOf(gmode, start30);
                    Program.BestScore30.Add(Program.AllScoreScoreboard[at30]);
                    start30 = at30 + 1;
                }
                Program.BestScore10.Sort();
                Program.BestScore10.Reverse();
                Program.BestScore20.Sort();
                Program.BestScore20.Reverse();
                Program.BestScore30.Sort();
                Program.BestScore30.Reverse();
            }



            //Update the labels on the interface with its values on dbo.Scoreboard

            //Updating every UserName
            this.label12.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore10[0])];    //GM 10
            this.label13.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore10[1])];
            this.label14.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore10[2])];
            this.label15.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore20[0])];    //GM 20
            this.label16.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore20[1])];
            this.label17.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore20[2])];
            this.label18.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore30[0])];    //GM 30
            this.label19.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore30[1])];
            this.label20.Text = Program.AllUserScoreboard[Program.AllScoreScoreboard.IndexOf(Program.BestScore30[2])];

            //Updating every Score
            this.label21.Text = Convert.ToString(Program.BestScore10[0]);
            this.label22.Text = Convert.ToString(Program.BestScore10[1]);
            this.label23.Text = Convert.ToString(Program.BestScore10[2]);
            this.label24.Text = Convert.ToString(Program.BestScore20[0]);
            this.label25.Text = Convert.ToString(Program.BestScore20[1]);
            this.label26.Text = Convert.ToString(Program.BestScore20[2]);
            this.label27.Text = Convert.ToString(Program.BestScore30[0]);
            this.label28.Text = Convert.ToString(Program.BestScore30[1]);
            this.label29.Text = Convert.ToString(Program.BestScore30[2]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.GameMode = 10;
            Program.TriesLeft = Program.GameMode;
            this.Hide();
            Program.isPrimeMusicOn = false;
            Program.DisappearTheMedia();
            GettingStarted_Form4 form4 = new GettingStarted_Form4();
            Program.SetStartMedia(FIRST_LEVEL_SONG_PATH, Program.volumeMusic);
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.GameMode = 20;
            Program.TriesLeft = Program.GameMode;
            this.Hide();
            Program.isPrimeMusicOn = false;
            Program.DisappearTheMedia();
            GettingStarted_Form4 form4 = new GettingStarted_Form4();
            Program.SetStartMedia(SECOND_LEVEL_SONG_PATH, Program.volumeMusic);
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.GameMode = 30;
            Program.TriesLeft = Program.GameMode;
            this.Hide();
            Program.isPrimeMusicOn = false;
            Program.DisappearTheMedia();
            GettingStarted_Form4 form4 = new GettingStarted_Form4();
            Program.SetStartMedia(THIRD_LEVEL_SONG_PATH, Program.volumeMusic);
            form4.Show();
        }

        private void Initialize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rules_Form5 form5 = new Rules_Form5();
            this.Hide();
            form5.Show();
        }

        private void plusvolumeBut_Click(object sender, EventArgs e)
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
        }
    }
}
