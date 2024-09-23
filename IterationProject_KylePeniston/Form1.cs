/*
Kyle Peniston
Iteration Project
9/16/2024
3844 - Develop Bus Appl in .Net
Brian Boyer
Description: The users attempt to guess a randomly generated number between 1 and 100. 
As users make guesses, the program provides feedback on whether their guess is too high or too low,
tracks the number of guesses made, and displays a congratulatory message with the total number of attempts
once the correct number is guessed.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IterationProject_KylePeniston
{
    public partial class Form1 : Form
    {

        //Globals
        static int guessedNumber = 0;
        static int computerNumber = 0;
        static string msg;
        static int guessCount = 0;

        public Form1()
        {
            //Program start
            InitializeComponent();
            init();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //Validate User Input
            if (!int.TryParse(textBox1.Text, out guessedNumber))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }

            //Increment guessCount
            guessCount++;

            //Compare guessedNumber
            if (guessedNumber > computerNumber)
            {
                msg = "Too high!";
                textBox1.BackColor = Color.LightPink;
                textBox1.Focus();
            }
            else if (guessedNumber < computerNumber)
            {
                msg = "Too low!";
                textBox1.BackColor = Color.LightBlue;
                textBox1.Focus();
            } 
            else
            {
                msg = $"Congratulations! It took you {guessCount} amount of tries to guess it.";
                textBox1.BackColor = Color.LightGreen;
                submitButton.Enabled = false;
            }

            //Display result message
            resultLabel.Text = msg;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            //Initialize new game
            init();
        }

        private void init()
        {
            //Game start up
            var rand = new Random();
            computerNumber = rand.Next(1, 101);
            submitButton.Enabled = true;
            textBox1.Clear();

            //Default values
            textBox1.BackColor = Color.White;
            resultLabel.Text = "";
            guessCount = 0;
        }
    }
}
