using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobilna
{
    public partial class MainPage : ContentPage
    {
        int gameResult = 0;

        public MainPage()
        {
            InitializeComponent();

            Dice0.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice1.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice2.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice3.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice4.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
        }

        private void DiceRoll(object sender, EventArgs e)
        {
            int[] dice = new int[5];

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {

                dice[i] = random.Next(1, 7);
            }

            Dice0.Source = ImageSource.FromResource("mobilna.Images.k6_" + dice[0] + ".png");
            Dice1.Source = ImageSource.FromResource("mobilna.Images.k6_" + dice[1] + ".png");
            Dice2.Source = ImageSource.FromResource("mobilna.Images.k6_" + dice[2] + ".png");
            Dice3.Source = ImageSource.FromResource("mobilna.Images.k6_" + dice[3] + ".png");
            Dice4.Source = ImageSource.FromResource("mobilna.Images.k6_" + dice[4] + ".png");

            int rollResult = 0;
            for (int dots = 1; dots <= 6; dots++)
            {
                int count = 0;
                for (int diceIndex = 0; diceIndex < 5; diceIndex++)
                {
                    if (dice[diceIndex] == dots)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    rollResult += dots * count;
                }
            }
            RollResultLabel.Text = "Wynik tego losowania: " + rollResult;
            gameResult += rollResult;
            GameResultLabel.Text = "Wynik gry: " + gameResult;
        }

        private void ResetGame(object sender, EventArgs e)
        {
            Dice0.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice1.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice2.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice3.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");
            Dice4.Source = ImageSource.FromResource("mobilna.Images.k6_0.png");

            gameResult = 0;
            RollResultLabel.Text = "Wynik tego losowania: 0";
            GameResultLabel.Text = "Wynik gry: " + gameResult;
        }
    }
}
