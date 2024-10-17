using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fimble
{
    public partial class TopicMenu : Form
    {
        public TopicMenu()
        {
            InitializeComponent();
        }

        private void TopicMenu_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame("budgeting");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartGame("insurance");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartGame("debt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartGame("investing");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StartGame("retirement");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StartGame("saving");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StartGame("stokvel");
        }

        private void StartGame(string selectedTopic)
        {
            Form1 gameForm = new Form1(selectedTopic);
            gameForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
