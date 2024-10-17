using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fimble
{
    public partial class Form1 : Form
    {

        public int remainingTime = 60; // Initial time set to 60 seconds
        //private int score = 0;

        public Form1(string selectedTopic)
        {
            InitializeComponent();
            // Set category label text based on the selected category
            //label1.Text = "Category: " + category;
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            /*textBox1.Parent = pictureBox1;
            textBox1.BackColor = Color.Transparent;*/

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hintCounter == 0)
            {
                MessageBox.Show("First letter of the word: " + currentWord[0]);
            }
            else if (hintCounter == 1)
            {
                MessageBox.Show("Last letter of the word: " + currentWord[currentWord.Length - 1]);
            }
            else if (hintCounter == 2)
            {
                MessageBox.Show("Definition of the word: " + currentDefinition);
            }
            else
            {
                MessageBox.Show("No more hints remaining.");
            }

            hintCounter++;
        }

        private void UpdateTimerLabel()
        {
            // Update timer label text
            label3.Text = "Time: " + remainingTime.ToString() + "s";
        }

        private void UpdateScoreLabel()
        {
            // Update score label text
            label4.Text = "Score: " + score.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Timer tick event
            remainingTime--; // Decrease remaining time by 1 second
            UpdateTimerLabel();

            if (remainingTime == 0)
            {
                // Game over logic (if timer reaches 0)
                timer1.Stop(); // Stop the timer
                MessageBox.Show("Time's up! Game Over!"); // Display message to the user
                // Additional game over logic
            }
        }
        
        private void InitializeGame()
        {
            // Select a random word from the dictionary
            Random rnd = new Random();
            int index = rnd.Next(0, wordsDictionary.Count);
            currentWord = wordsDictionary.Keys.ElementAt(index);
            currentDefinition = wordsDictionary[currentWord];

            // Scramble the word
            ScrambleWord(currentWord);

            // Reset hint counter
            hintCounter = 0;
        }
        private void ScrambleWord(string word)
        {
            char[] charArray = word.ToCharArray();
            Random rnd = new Random();

            // Fisher-Yates shuffle algorithm
            for (int i = charArray.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                char temp = charArray[i];
                charArray[i] = charArray[j];
                charArray[j] = temp;
            }

            // Update the label to display the scrambled word
            label2.Text = new string(charArray);
        }

        private void CheckGuess(string guess)
        {
            if (guess == currentWord)
            {
                MessageBox.Show("Correct! " + currentWord + " : " + currentDefinition);
                score++; // Increase score for correct guess
                // Update score label
                label4.Text = "Score: " + score;

                // Move to the next word or end the game
                //InitializeGame();
            }
            else
            {
                MessageBox.Show("Incorrect guess. Try again!");
                // Deduct points or time
                // Provide feedback to the user
            }
        }
       

        private Dictionary<string, string> wordsDictionary = new Dictionary<string, string>();
        private string currentWord;
        private string currentDefinition;
        private int score;
        private int timeRemaining;
        private int hintCounter;

        public void LoadWordsDictionary(string selectedTopic)
        {
            string filePath = selectedTopic + ".txt"; // Assuming file names match topic names
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        wordsDictionary.Add(parts[0], parts[1]);
                    }
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }
        }
    }
}
