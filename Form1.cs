using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace The_Lottery_Machine
{
    public partial class Form1 : Form
    {
        bool autoResetPicks = false;
        bool autoReset = false;
        byte picks;
        byte draw;
        bool soundEnabled = false;
        int timesPlayed = 0;
        int timesWon = 0;

        Random random = new Random();
        DateTime dt = new DateTime();
        SoundPlayer lossSound = new SoundPlayer("lossSound.wav");
        SoundPlayer winSound = new SoundPlayer("winSound.wav");

        public Form1()
        {
            InitializeComponent();
            initButtonColors();
            getSave();
        }

        void initButtonColors()
        {
            pickOne.BackColor = Color.SlateGray;
            pickTwo.BackColor = Color.SlateGray;
            pickThree.BackColor = Color.SlateGray;
            pickFour.BackColor = Color.SlateGray;
            pickFive.BackColor = Color.SlateGray;
            pickSix.BackColor = Color.SlateGray;
            pickSeven.BackColor = Color.SlateGray;
            pickEight.BackColor = Color.SlateGray;
            drawOne.BackColor = Color.SlateGray;
            drawTwo.BackColor = Color.SlateGray;
            drawThree.BackColor = Color.SlateGray;
            drawFour.BackColor = Color.SlateGray;
            drawFive.BackColor = Color.SlateGray;
            drawSix.BackColor = Color.SlateGray;
            drawSeven.BackColor = Color.SlateGray;
            drawEight.BackColor = Color.SlateGray;
            playButton.BackColor = Color.SlateGray;
            autoResetButton.BackColor = Color.SlateGray;
            resetButton.BackColor = Color.Red;
        }

        void resetColors()
        {
            if (autoResetPicks)
            {
                pickOne.BackColor = Color.SlateGray;
                pickTwo.BackColor = Color.SlateGray;
                pickThree.BackColor = Color.SlateGray;
                pickFour.BackColor = Color.SlateGray;
                pickFive.BackColor = Color.SlateGray;
                pickSix.BackColor = Color.SlateGray;
                pickSeven.BackColor = Color.SlateGray;
                pickEight.BackColor = Color.SlateGray;
            }
            drawOne.BackColor = Color.SlateGray;
            drawTwo.BackColor = Color.SlateGray;
            drawThree.BackColor = Color.SlateGray;
            drawFour.BackColor = Color.SlateGray;
            drawFive.BackColor = Color.SlateGray;
            drawSix.BackColor = Color.SlateGray;
            drawSeven.BackColor = Color.SlateGray;
            drawEight.BackColor = Color.SlateGray;
            playButton.BackColor = Color.SlateGray;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            timesPlayed++;
            timesPlayedLabel.Text = timesPlayed.ToString();
            soundEnabled = soundCheckBox.Checked;
            autoResetPicks = autoResetPicksCheckBox.Checked;
            playButton.BackColor = Color.OrangeRed;
            disableButtons();
            draw = (byte)random.Next(0, 255);
            setDrawColors();
            drawIntegerLabel.Text = draw.ToString();
            picksIntegerLabel.Text = picks.ToString();
            if(draw == picks)
            {
                winScenario();
            }
            else
            {
                loseScenario();
            }
        }

        private void winScenario()
        {
            timesWon++;
            timesWonLabel.Text = timesWon.ToString();
            if(soundEnabled) winSound.Play();
            dt = DateTime.Now;
            lastWinLabel.Text = dt.ToString();
            string caption = "Winner!";
            string message = "You won the lottery!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (autoReset) reset();
        }

        private void loseScenario()
        {
            if(soundEnabled) lossSound.Play();
            string caption = "You lose...";
            string message = "You've lost :/. Try again!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) Application.Exit();
            if (autoReset) reset();
        }

        private void disableButtons()
        {
            playButton.Enabled = false;
            pickOne.Enabled = false;
            pickTwo.Enabled = false;
            pickThree.Enabled = false;
            pickFour.Enabled = false;
            pickFive.Enabled = false;
            pickSix.Enabled = false;
            pickSeven.Enabled = false;
            pickEight.Enabled = false;
            autoResetButton.Enabled = false;
        }

        private void enableButtons()
        {
            playButton.Enabled = true;
            pickOne.Enabled = true;
            pickTwo.Enabled = true;
            pickThree.Enabled = true;
            pickFour.Enabled = true;
            pickFive.Enabled = true;
            pickSix.Enabled = true;
            pickSeven.Enabled = true;
            pickEight.Enabled = true;
            autoResetButton.Enabled = true;
        }

        private void pickOne_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(0);
            if (picks.IsBitSet(0))
            {
                pickOne.BackColor = Color.OrangeRed;
            }
            else
            {
                pickOne.BackColor = Color.SlateGray;
            }
        }

        private void pickTwo_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(1);
            if (picks.IsBitSet(1))
            {
                pickTwo.BackColor = Color.OrangeRed;
            }
            else
            {
                pickTwo.BackColor = Color.SlateGray;
            }
        }

        private void pickThree_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(2);
            if (picks.IsBitSet(2))
            {
                pickThree.BackColor = Color.OrangeRed;
            }
            else
            {
                pickThree.BackColor = Color.SlateGray;
            }
        }

        private void pickFour_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(3);
            if (picks.IsBitSet(3))
            {
                pickFour.BackColor = Color.OrangeRed;
            }
            else
            {
                pickFour.BackColor = Color.SlateGray;
            }
        }

        private void pickFive_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(4);
            if (picks.IsBitSet(4))
            {
                pickFive.BackColor = Color.OrangeRed;
            }
            else
            {
                pickFive.BackColor = Color.SlateGray;
            }
        }

        private void pickSix_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(5);
            if (picks.IsBitSet(5))
            {
                pickSix.BackColor = Color.OrangeRed;
            }
            else
            {
                pickSix.BackColor = Color.SlateGray;
            }
        }

        private void pickSeven_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(6);
            if (picks.IsBitSet(6))
            {
                pickSeven.BackColor = Color.OrangeRed;
            }
            else
            {
                pickSeven.BackColor = Color.SlateGray;
            }
        }

        private void pickEight_Click(object sender, EventArgs e)
        {
            picks = picks.ToggleBit(7);
            if (picks.IsBitSet(7))
            {
                pickEight.BackColor = Color.OrangeRed;
            }
            else
            {
                pickEight.BackColor = Color.SlateGray;
            }
        }

        private void autoResetButton_Click(object sender, EventArgs e)
        {
            if (autoReset)
            {
                autoReset = false;
            }
            else
            {
                autoReset = true;
            }
            if (autoReset)
            {
                autoResetButton.BackColor = Color.OrangeRed;
            }
            else
            {
                autoResetButton.BackColor = Color.SlateGray;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            autoReset = false;
            reset();
        }

        private void setDrawColors()
        {
            if (draw.IsBitSet(0)) drawOne.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(1)) drawTwo.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(2)) drawThree.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(3)) drawFour.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(4)) drawFive.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(5)) drawSix.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(6)) drawSeven.BackColor = Color.OrangeRed;
            if (draw.IsBitSet(7)) drawEight.BackColor = Color.OrangeRed;
        }

        private void reset()
        {
            disableButtons();
            draw = 0;
            if (autoResetPicks) picks = 0;
            resetColors();
            enableButtons();
        }

        private void getSave()
        {
            try
            {
                StreamReader sr = new StreamReader("save.txt");    
                string[] linesArray = new string[6];
                string temp1 = "";
                for (int i = 0; i < 6; i++)
                {
                    linesArray[i] = sr.ReadLine();
                    //string temp = linesArray[i].Substring(linesArray[i].IndexOf("="), linesArray[i].Length);
                    temp1 = linesArray[i].Substring(linesArray[i].IndexOf("= "));
                    temp1 = temp1.Substring(temp1.IndexOf(" "));
                    if (i == 0) if (temp1 == "True") soundEnabled = true;
                    else soundEnabled = false;
                    if (i == 1) if (temp1 == "True") autoResetPicks = true;
                        else autoResetPicks = false;
                    if (i == 3) timesPlayed = Int32.Parse(temp1);
                    if (i == 4) timesWon = Int32.Parse(temp1);
                    if (i == 5) lastWinLabel.Text = temp1;
                }
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Save Successfully fetched! ", "Save", buttons);
                sr.Close();
            }
            catch (Exception err)
            {
                string caption = "An Error Has Occured Fetching Save";
                string message = err.Message;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                throw;
            }
            finally
            {
                
            }
            timesPlayedLabel.Text = timesPlayed.ToString();
            timesWonLabel.Text = timesWon.ToString();
            soundCheckBox.Checked = soundEnabled;
            autoResetPicksCheckBox.Checked = autoResetPicks;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                StreamWriter sw = new StreamWriter("save.txt");
                sw.WriteLine("SoundEnbaled = " + soundCheckBox.Enabled);
                sw.WriteLine("Auto-ResetPicks = " + autoResetPicksCheckBox.Enabled);
                sw.WriteLine("Auto-Reset = " + autoReset);
                sw.WriteLine("TimesPlayed = " + timesPlayed.ToString());
                sw.WriteLine("TimesWon = " + timesWon.ToString());
                sw.WriteLine("LastWin = " + dt.ToString());
                sw.Close();
            }
            catch (Exception err)
            {
                string caption = "An Error Has Occured Trying to Save";
                string message = err.Message;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                throw;
            }
        }
    }

    public static class byteOperations
    {
        public static byte ToggleBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (byte)(b ^ (1 << pos));
        }
        public static bool IsBitSet(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (b & (1 << pos)) != 0;
        }
    }
}
