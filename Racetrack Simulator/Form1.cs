using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racetrack_Simulator
{
    public partial class Form1 : Form
    {
        public Eagle[] EagleArray = new Eagle[4];
        public Guy[] GuyArray = new Guy[3];


        Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();
            //Initializing Eagles
      
            EagleArray[0] = new Eagle()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer 
            };
            EagleArray[1] = new Eagle()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };
            EagleArray[2] = new Eagle()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };
            EagleArray[3] = new Eagle()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox5.Width,
                Randomizer = MyRandomizer
            };
            //Initializing Guys
            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyBet = null,
                MyRadioButton = JoeRadioButton,
                MyLabel = joeBetLabel, 
            };
            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyBet = null,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };
            GuyArray[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyBet = null,
                MyRadioButton = AlRadioButton,
                MyLabel = alBetLabel
            };

            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].UpdateLabels();
            }
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (EagleArray[i].Run())
                {
                    timer1.Stop(); 
                    MessageBox.Show("The winner is Eagle #" + ++i + ".");
                    for (int x = 0; x < 4; x++)
                    {
                        EagleArray[x].TakeStartingPoint();
                    }
                    for (int y = 0; y < 3; y++)
                    {
                        GuyArray[y].Collect(i);
                        GuyArray[y].UpdateLabels();
            
                    }             
                }
            }
        }

        private void JoeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[1].Name;
        }

        private void AlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[2].Name;
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            int BetAmount = (int)betAmount_Numeric.Value;
            int EagleNumber = (int)eagleNumber_Numeric.Value;

            if (JoeRadioButton.Checked)
            {
                if (GuyArray[0].PlaceBet(BetAmount, EagleNumber))
                {
                    joeBetLabel.Text = GuyArray[0].MyBet.GetDescripion();
                }
                else
                {
                    MessageBox.Show(GuyArray[0].Name + " doesn't have enough money.");
                }

            }
            else if (bobRadioButton.Checked)
            {
                if (GuyArray[1].PlaceBet(BetAmount, EagleNumber))
                {
                    bobBetLabel.Text = GuyArray[1].MyBet.GetDescripion();
                }
                else
                {
                    MessageBox.Show(GuyArray[1].Name + " doesn't have enough money.");
                }
              
            }
            else if (AlRadioButton.Checked)
            {
                if (GuyArray[2].PlaceBet(BetAmount, EagleNumber))
                {
                    alBetLabel.Text = GuyArray[2].MyBet.GetDescripion();
                }
                else
                {
                    MessageBox.Show(GuyArray[2].Name + " doesn't have enough money.");
                }

            }
        }
    }
}
