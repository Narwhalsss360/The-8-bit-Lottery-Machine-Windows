using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace The_Lottery_Machine
{
    public partial class Form1 : Form
    {
        bool autoReset = false;
        byte picks;
        byte draw;

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            initButtonColors();
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
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.BackColor = Color.OrangeRed;
            disableButtons();
            draw = (byte)random.Next(0, 255);
            setDrawColors();
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
            string caption = "Winner!";
            string message = "You won the lottery!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (autoReset) reset();
        }

        private void loseScenario()
        {
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
            autoResetButton.Enabled = false;
            pickOne.Enabled = false;
            pickTwo.Enabled = false;
            pickThree.Enabled = false;
            pickFour.Enabled = false;
            pickFive.Enabled = false;
            pickSix.Enabled = false;
            pickSeven.Enabled = false;
            pickEight.Enabled = false;
        }

        private void enableButtons()
        {
            playButton.Enabled = true;
            autoResetButton.Enabled = true;
            pickOne.Enabled = true;
            pickTwo.Enabled = true;
            pickThree.Enabled = true;
            pickFour.Enabled = true;
            pickFive.Enabled = true;
            pickSix.Enabled = true;
            pickSeven.Enabled = true;
            pickEight.Enabled = true;
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
            autoReset = false;
            draw = 0;
            picks = 0;
            resetColors();
            enableButtons();
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
