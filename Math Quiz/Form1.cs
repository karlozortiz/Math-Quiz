using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        // Create an intance of the class Random
        Random randomizer = new Random ();
        int addend1, addend2;

        // These integer variables store the numbers
        //for the substraction problem
        int leftminus, rightminus;

        //This integer variable keeps track of the remaining time
        int timeLeft;

        /**
         * Start the quiz by assinging random numbers,
         * starting the timer, and setting result to zero. This is fun!
         * */
        public void StartTheQuiz()
        {
            // Assign random number 
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // -SUBSTRACTION-
            leftminus = randomizer.Next(1, 101);
            rightminus = randomizer.Next(1, leftminus);
            minusLeftLabel.Text = leftminus.ToString();
            minusRightLabel.Text = rightminus.ToString();
            difference.Value = 0;


            // Time to set up counter!! :D
            timeLeft = 20;
            timeLabel.Text = "20 seconds";
            timer1.Start();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void plusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkAnswer())
            {
                // if the anwer is correct, then stop timer
                // and display a congratulations window
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // display the new time left by updating the Time Left label
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If time is over, show a MessageBox
                // and fill in the answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = leftminus - rightminus;
                startButton.Enabled = true;
            }
        }

        private bool checkAnswer()
        {
            if (addend1 + addend2 == sum.Value &&
                leftminus - rightminus == difference.Value)
                return true;
            else
                return false;
        }


        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole answer in the NumericUpDown control
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void dividedLeftLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
