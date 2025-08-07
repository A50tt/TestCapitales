using System;
using System.Drawing;
using System.Windows.Forms;


namespace TestAboutCapitals
{
    public partial class Test_Form2 : Form
    {
        string AIRHORN_SOUND_PATH = "assets\\music\\Airhorn.wma";
        string CORRECT_ANSWER_SOUND_PATH = "assets\\music\\CorrectAnswer.wma";
        string INCORRECT_ANSWER_SOUND_PATH = "assets\\music\\Bruh.wma";
        string RECORD_ENTRY_SONG_PATH = "assets\\music\\VictoryDream.wma";

        public Test_Form2()
        {
            InitializeComponent();
            Operations.Randomize();
            InsertOptionsInterface();
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic*100)+"%";
        }

        public void InsertOptionsInterface()
        {
            this.CountryAskedLabel.Text = Convert.ToString(Program.QuestionNum + ". " + Program.FourCountries[0]);
            this.buttonOption1.Text = Program.FourCapitals[Program.RandomOrder[0]];
            this.buttonOption2.Text = Program.FourCapitals[Program.RandomOrder[1]];
            this.buttonOption3.Text = Program.FourCapitals[Program.RandomOrder[2]];
            this.buttonOption4.Text = Program.FourCapitals[Program.RandomOrder[3]];
        }

        //Option 1 clicked
        private void buttonOption1_Click(object sender, EventArgs e)
        {
            if (Program.buttonReady == true)
            {
                checkIfCorrectAnswer(Program.FourCapitals[Program.RandomOrder[0]], 1);
            }

        }
        //Option 2 clicked
        private void buttonOption2_Click(object sender, EventArgs e)
        {
            if (Program.buttonReady == true)
            {
                checkIfCorrectAnswer(Program.FourCapitals[Program.RandomOrder[1]], 2);
            }
        }
        //Option 3 clicked
        private void ButtonOption3_Click(object sender, EventArgs e)
        {
            if (Program.buttonReady == true)
            {
                checkIfCorrectAnswer(Program.FourCapitals[Program.RandomOrder[2]], 3);
            }
        }
        //Option 4 clicked
        private void buttonOption4_Click(object sender, EventArgs e)
        {
            if (Program.buttonReady == true)
            {
                checkIfCorrectAnswer(Program.FourCapitals[Program.RandomOrder[3]], 4);
            }
        }

        public void checkIfCorrectAnswer(string answer, int buttonNum)
        {
            //If it's the correct answer
            if (answer == Program.FourCapitals[0])
            {
                Program.playSimpleSound(CORRECT_ANSWER_SOUND_PATH, Program.volumeMusic);
                switch (buttonNum)
                {
                    case 1:
                        this.buttonOption1.BackColor = Color.LimeGreen;
                        break;
                    case 2:
                        this.buttonOption2.BackColor = Color.LimeGreen;
                        break;
                    case 3:
                        this.buttonOption3.BackColor = Color.LimeGreen;
                        break;
                    case 4:
                        this.buttonOption4.BackColor = Color.LimeGreen;
                        break;
                }
                Program.currentMultiplicator += Program.additionalMultiplicator;
                double baseScorePlusTiming = this.timerBar.Value / 500.00;
                int currentAddingScore = Convert.ToInt32(Program.PointsEveryCorrectAnswer * ( baseScorePlusTiming + 1.00 ) * Program.currentMultiplicator);
                Program.ActualScore += currentAddingScore;
                UpdatePointsMarker();
                this.plusLastAnswer.Text = "+" + Convert.ToString(currentAddingScore) + "";
                if (Program.currentMultiplicator >= 2)
                {
                    this.comboLabel.Text = "Combo!!";
                    this.comboNumberlabel.Text = "x" + Program.currentMultiplicator + "";
                }
                Application.DoEvents();
                testTimer.Stop();
                Program.WaitSomeTimeAndUpdate(750);
            }
            //If it's an incorrect answer
            else
            {
                Program.playSimpleSound(INCORRECT_ANSWER_SOUND_PATH, Program.volumeMusic);
                switch (buttonNum)
                {
                    case 1:
                        this.buttonOption1.BackColor = Color.Red;
                        break;
                    case 2:
                        this.buttonOption2.BackColor = Color.Red;
                        break;
                    case 3:
                        this.buttonOption3.BackColor = Color.Red;
                        break;
                    case 4:
                        this.buttonOption4.BackColor = Color.Red;
                        break;
                }

                if (this.buttonOption1.Text == Program.FourCapitals[0])
                {
                    this.buttonOption1.BackColor = Color.LimeGreen;
                }

                else if (this.buttonOption2.Text == Program.FourCapitals[0])
                {
                    this.buttonOption2.BackColor = Color.LimeGreen;
                }

                else if (this.buttonOption3.Text == Program.FourCapitals[0])
                {
                    this.buttonOption3.BackColor = Color.LimeGreen;
                }

                else if (this.buttonOption4.Text == Program.FourCapitals[0])
                {
                    this.buttonOption4.BackColor = Color.LimeGreen;
                }
                Application.DoEvents();
                testTimer.Stop();
                Program.WaitSomeTimeAndUpdate(Program.waitTimeAfterAnswer);

                Program.currentMultiplicator = 0;
                this.comboLabel.Text = "";
                this.comboNumberlabel.Text = "";
                this.plusLastAnswer.Text = "";
            }
            ReturnAllColorsOfOptions();
        }
        //Returning back the color of the showed correct and cinorrect options
        public void ReturnAllColorsOfOptions()
        {
            this.buttonOption1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOption2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOption3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOption4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOption1.UseVisualStyleBackColor = true;
            this.buttonOption2.UseVisualStyleBackColor = true;
            this.buttonOption3.UseVisualStyleBackColor = true;
            this.buttonOption4.UseVisualStyleBackColor = true;
            this.timerBar.Value = Program.maximumTimerBar;
            Application.DoEvents();
            NextQuestion();
        }
        //Preparation for next question. Clearing respective lists or if no triesLeft, finish with maybe RECORD
        public void NextQuestion()
        {
            Program.TriesLeft--;
            Program.QuestionNum += 1;
            if (Program.TriesLeft != 0)
            {
                Program.RandomOrder.Clear();
                Program.RandomIDs.Clear();
                Program.FourCountries.Clear();
                Program.FourCapitals.Clear();
                Operations.Randomize();
                this.InsertOptionsInterface();
                testTimer.Start();
            }

            else
            {
                AllInvisibleTimeOut();
                this.TimeOutLabel.Visible = true;
                Program.playSimpleSound(AIRHORN_SOUND_PATH, Program.volumeMusic);
                Application.DoEvents();
                Program.WaitSomeTimeAndUpdate(1350);
                switch (Program.GameMode)
                {
                    case 10:
                        if (Program.ActualScore > Program.BestScore10[2])
                        {
                            this.TimeOutLabel.Visible = false;
                            this.newRecord1Label.Visible = true;
                            this.newRecord2Label.Visible = true;
                            Application.DoEvents();
                            Program.WaitSomeTimeAndUpdate(1500);
                        }
                        break;
                    case 20:
                        if (Program.ActualScore > Program.BestScore20[2])
                        {
                            this.TimeOutLabel.Visible = false;
                            this.newRecord1Label.Visible = true;
                            this.newRecord2Label.Visible = true;
                            Application.DoEvents();
                            Program.WaitSomeTimeAndUpdate(1500);
                        }
                        break;
                    case 30:
                        if (Program.ActualScore > Program.BestScore30[2])
                        {
                            this.TimeOutLabel.Visible = false;
                            this.newRecord1Label.Visible = true;
                            this.newRecord2Label.Visible = true;
                            Application.DoEvents();
                            Program.WaitSomeTimeAndUpdate(1500);
                        }
                        break;
                }
                Program.currentMultiplicator = 0;
                RecordEntry form3 = new RecordEntry();
                Program.ChangeSourceMusic(RECORD_ENTRY_SONG_PATH);
                this.Hide();
            }
        }

        public void UpdatePointsMarker()
        {
            this.Points.Text = Convert.ToString(Program.ActualScore);
            Application.DoEvents();
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            if (this.timerBar.Value > 0)
            {
                this.timerBar.Value -= 5;
                Application.DoEvents();
            }
            else if (this.timerBar.Value <= 0 && Program.TriesLeft > 0)
            {
                this.testTimer.Stop();
                NoTimeAlready();
                this.plusLastAnswer.Text = "";
                Program.WaitSomeTimeAndUpdate(Program.waitTimeAfterAnswer);
                ReturnAllColorsOfOptions();
            }
            else if (this.timerBar.Value <= 0 && Program.TriesLeft == 0)
            {
                this.testTimer.Stop();
                NoTimeAlready();
                NextQuestion();
            }

        }

        private void AllInvisibleTimeOut()
        {
            this.label1.Visible = false;
            this.CountryAskedLabel.Visible = false;
            this.buttonOption1.Visible = false;
            this.buttonOption2.Visible = false;
            this.buttonOption3.Visible = false;
            this.buttonOption4.Visible = false;
            this.label2.Visible = false;
            this.Points.Visible = false;
            this.comboLabel.Visible = false;
            this.comboNumberlabel.Visible = false;
            this.plusLastAnswer.Visible = false;
            this.timerBar.Visible = false;
            this.muteVolumeButton.Visible = false;
            this.minusVolumeBut.Visible = false;
            this.plusVolumeBut.Visible = false;
            this.volumeLevel.Visible = false;
        }

        private void NoTimeAlready()
        {
            Program.playSimpleSound(INCORRECT_ANSWER_SOUND_PATH, Program.volumeMusic);
            NoTimeJustShowMe(this.buttonOption1);
            NoTimeJustShowMe(this.buttonOption2);
            NoTimeJustShowMe(this.buttonOption3);
            NoTimeJustShowMe(this.buttonOption4);
            Application.DoEvents();
        }

        private void NoTimeJustShowMe(System.Windows.Forms.Button button)
        {
            if (button.Text == Program.FourCapitals[0])
            {
                button.BackColor = Color.LimeGreen;
            }
            else
            {
                button.BackColor = Color.Red;
            }
        }

        private void Test_Form2_Shown(object sender, EventArgs e)
        {
            checkTimer.Start();

        }

        private void checkTimer_Tick(object sender, EventArgs e)
        {
            if (this.timerBar.Value == Program.maximumTimerBar)
            {
                this.testTimer.Start();
                this.checkTimer.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Test_Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();
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
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic*100)+"%";
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
                this.volumeLevel.Text = Convert.ToString(Program.volumeMusic*100)+"%";
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
            this.volumeLevel.Text = Convert.ToString(Program.volumeMusic * 100) + "%";
        }
    }
}
