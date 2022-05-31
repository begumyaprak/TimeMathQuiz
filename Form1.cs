using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeMathQuiz
{
    public partial class MathQuiz : Form
    {
        public MathQuiz()
        {
            InitializeComponent();
        }

        Random randomizer = new Random();

        int addend1;
        int addend2;
        
        int minus1;
        int minus2;

        int multiply1;
        int multiply2;

        int divide1;
        int divide2;


        int timeLeft;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
          startTheQuiz();
          startButton.Enabled = false;

        }

        private void startTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();


            minus1 = randomizer.Next(1,101);
            minus2 = randomizer.Next(1,minus1);
            minusLeftLabel.Text = minus1.ToString();
            minusRightLabel.Text = minus2.ToString();

            multiply1 = randomizer.Next(1, 11);
            multiply2 = randomizer.Next(1, 11);
            multiplyLeftLabel.Text = multiply1.ToString();
            multiplyRightLabel.Text = multiply2.ToString();

            divide1 = randomizer.Next(1, 50);
            divide2 = randomizer.Next(1, divide1);
            divideLeftLabel.Text = divide1.ToString();
            divideRightLabel.Text = divide2.ToString();


            sum.Value = 0; ;
            subtraction.Value = 0;
            multiplication.Value = 0;
            division.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {

            if(addend1 + addend2 == sum.Value && minus1 - minus2 == subtraction.Value && multiply1*multiply2 == multiplication.Value && divide1/divide2 == division.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("All answers right, Congrats!");
                startButton.Enabled = true;


            }
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "second";

                if(timeLeft < 5)
                {
                    timeLabel.BackColor = Color.Red;
                }

            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You did't finish at the time :( ");
                sum.Value = addend1 + addend2;
                subtraction.Value = minus1 - minus2;
                multiplication.Value = multiply1*multiply2;
                division.Value = divide1/divide2;
                startButton.Enabled=true;
                timeLabel.BackColor = DefaultBackColor;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
              NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
               int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
