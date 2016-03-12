using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PairCards
{
    public partial class Form1 : Form
    {
        
        Timer hideCardsTimer = new Timer();

        int[] cards;
        List<Button> listOfPairs = new List<Button>();
        Random rnd;
        List<Button> listOfCards = new List<Button>();

        int matchingPairs = 0;
        int userGuess1;
        int userGuess2;
        bool userGuessFirst = true;
        int tries = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            listOfCards.Add(button1);
            listOfCards.Add(button2);
            listOfCards.Add(button3);
            listOfCards.Add(button4);
            listOfCards.Add(button5);
            listOfCards.Add(button6);
            listOfCards.Add(button7);
            listOfCards.Add(button8);
            listOfCards.Add(button9);
            listOfCards.Add(button10);
            listOfCards.Add(button11);
            listOfCards.Add(button12);
            listOfCards.Add(button13);
            listOfCards.Add(button14);
            listOfCards.Add(button15);
            listOfCards.Add(button16);
            hideCardsTimer.Interval = 1000;
            hideCardsTimer.Tick += new System.EventHandler(hideCards);
            resetGame();
        }

        private void hideCards(object sender, EventArgs e)
        {
            listOfCards[userGuess1].BackgroundImage = Properties.Resources.card_back;
            listOfCards[userGuess2].BackgroundImage = Properties.Resources.card_back;
            CardsEnabled(true);
            disablePairs();
            hideCardsTimer.Enabled = false;
        }

        void resetGame() {

            label_percentage.Text = "Percent correct : ";
            button17.Enabled = false;
            tries = 0;
            matchingPairs = 0;

            for (int x = 0; x < 16; x++)
            {
                listOfCards[x].Enabled = true;
                listOfCards[x].BackgroundImage = Properties.Resources.card_back;
                listOfCards[x].BackgroundImageLayout = ImageLayout.Stretch;
            }
          
            cards = new [] {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7};

            cards = ShuffleArray(cards);

            for (int x = 0; x < 16; x++)
            {
                Console.WriteLine(x + " : " + cards[x]);
            }
        }

        void gameWon() {
            percentage();
            button17.Enabled = true;
        }

        void percentage() {
            int percent = (int)Math.Round((double)(100 * 8) / tries);
            label_percentage.Text = "Percent Correct : " + percent + "%";
        }

        int[] ShuffleArray(int[] array)
        {
            rnd = new Random();
            for (int i = array.Length; i > 0; i--)
            {
                int j = rnd.Next(i);
                int k = array[j];
                array[j] = array[i - 1];
                array[i - 1] = k;
            }
            return array;
        }

        void checkUserGuesses(int guess) {

            cardFlip(cards[guess], listOfCards[guess]);
            listOfCards[guess].Enabled = false;

            if (userGuessFirst)
            {
                userGuess1 = guess;
                userGuessFirst = !userGuessFirst;
            }
            else {
                userGuess2 = guess;
                // If pair is a match
                if (cards[userGuess1] == cards[userGuess2])
                {
                    matchingPairs++;
                    listOfCards[userGuess1].Enabled = false;
                    listOfCards[userGuess2].Enabled = false;
                    listOfPairs.Add(listOfCards[userGuess1]);
                    listOfPairs.Add(listOfCards[userGuess2]);
                    if (matchingPairs >= 8) {
                        gameWon();
                    }
                }
                // If pair is not a match
                else {
                    CardsEnabled(false);
                    hideCardsTimer.Enabled = true;                    
                }
                userGuessFirst = !userGuessFirst;
                tries++;
                label_tries.Text = "Tries : " + tries;
            }
        }

        void CardsEnabled(bool value) {
            for(int x = 0; x < listOfCards.Count; x++) {
                listOfCards[x].Enabled = value;
            }
        }

        void disablePairs() {
            for (int x = 0; x < listOfPairs.Count; x++){
                listOfPairs[x].Enabled = false;
            }
        }



        void cardFlip(int cardValue, Button card) {
            switch (cardValue) {
                case 0:
                    card.BackgroundImage = Properties.Resources.ace_of_clubs;
                    break;
                case 1:
                    card.BackgroundImage = Properties.Resources.king_of_diamonds;
                    break;
                case 2:
                    card.BackgroundImage = Properties.Resources.queen_of_spades;
                    break;
                case 3:
                    card.BackgroundImage = Properties.Resources.jack_of_hearts;
                    break;
                case 4:
                    card.BackgroundImage = Properties.Resources._2_of_clubs;
                    break;
                case 5:
                    card.BackgroundImage = Properties.Resources._6_of_diamonds;
                    break;
                case 6:
                    card.BackgroundImage = Properties.Resources._10_of_hearts;
                    break;
                case 7:
                    card.BackgroundImage = Properties.Resources._7_of_spades;
                    break;
                default:               
                    break;
            }
            card.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkUserGuesses(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkUserGuesses(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkUserGuesses(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkUserGuesses(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkUserGuesses(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkUserGuesses(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkUserGuesses(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkUserGuesses(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkUserGuesses(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkUserGuesses(9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            checkUserGuesses(10);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            checkUserGuesses(11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            checkUserGuesses(12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            checkUserGuesses(13);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            checkUserGuesses(14);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            checkUserGuesses(15);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            resetGame();
        }

    }
}
