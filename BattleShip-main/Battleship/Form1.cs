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
using BattleShipLibrary;
using System.Media;

namespace Battleship
{
    public partial class Form1 : Form
    {

        //Holds button list for reference
        List<Button> enemyButtonList;
        List<Button> playerButtonList;

        //Variables to prevent repeat messages for player
        bool playerAircraftCarrierMessageDisplayed = false;
        bool playerDestroyerMessageDisplayed = false;
        bool playerWarShipMessageDisplayed = false;
        bool playerSubmarineMessageDisplayed = false;

        //Variables to prevent repeat messages for enemy
        bool enemyAircraftCarrierMessageDisplayed = false;
        bool enemyDestroyerMessageDisplayed = false;
        bool enemyWarShipMessageDisplayed = false;
        bool enemySubmarineMessagedDisplayed = false;


        //Tracks game over
        bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
     
        private void Form1_Load(object sender, EventArgs e)
        {
            
            lbEnemyStatus.Visible = false;
            btnPlayAgain.Visible = false;
            GameBoardLoad();
            PlayerLoad();
            EnemyLoad();
            
        }

        //Updates the button names with a custom Algo
        private void GameBoardLoad()
        {

            List<string> AlphaList = new List<string>() { "Α", "Β", "Γ", "Δ", "Ε", "Ζ", "Η", "Θ", "Ι", "Κ" };
            playerButtonList = new List<Button>();
            enemyButtonList = new List<Button>();

            int counter = 1;
            int letterPlaceholder = 0;

            foreach (Control c in gbEnemySpace.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Text = "";
                    //c.Text = "E" + AlphaList[letterPlaceholder] + counter;
                    c.Name = "E" + AlphaList[letterPlaceholder] + counter;
                }

                if (counter <= 10)
                {
                    counter++;
                }

                if (counter > 10)
                {
                    counter = 1;
                    letterPlaceholder++;
                }
            }

            counter = 1;
            letterPlaceholder = 0;

            foreach (Control c in gbPlayerSpace.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Text = "";
                    //c.Text = "P" + AlphaList[letterPlaceholder] + counter;
                    c.Name = "P" + AlphaList[letterPlaceholder] + counter;
                }

                if (counter <= 10)
                {
                    counter++;
                }

                if (counter > 10)
                {
                    counter = 1;
                    letterPlaceholder++;
                }
            }

            foreach (Control b in gbEnemySpace.Controls)
            {
                if (b.GetType() == typeof(Button))
                {
                    enemyButtonList.Add((Button)b);
                }


            }

            foreach (Control b in gbPlayerSpace.Controls)
            {
                if (b.GetType() == typeof(Button))
                {
                    playerButtonList.Add((Button)b);
                }


            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        //Loads the player ship locations to the game board
        public void PlayerLoad()
        {


            foreach (var s in PlayerShip.warShip.Location)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }

            foreach (var s in PlayerShip.destroyer.Location)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in PlayerShip.cruiser.Location)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
                tempButton.BackColor = Color.Green;
            }
            foreach (var s in PlayerShip.submarine.Location)
            {
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == s);
               tempButton.BackColor = Color.Green;
            }
           

        }

        //Loads the enemy ship locations to game board
        public void EnemyLoad()
        {


            foreach (var s in EnemyShips.warShip.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                //tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.destroyer.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                //tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.cruiser.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                //tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.tanker.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                //tempButton.BackColor = Color.Green;
            }
            foreach (var s in EnemyShips.uBoat.Location)
            {
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == s);
                //tempButton.BackColor = Color.Green;
            }

        }


        //Game Mechanics
        private void btnFire_Click(object sender, EventArgs e)
        {
            bool result = CheckPlayerChoice();

            if (result == true)
            {
                var playerAttack = txtAttackBox.Text = "E" + txtAttackBox.Text.ToUpper();
                txtAttackBox.Clear();
                TurnSwitch(playerAttack);
            }
            else if (result == false)
            {
                MessageBox.Show("An invalid choice was entered. Choices entered must be one letter and one number and no more than two charecters long. EX: A1, B2");
            }
               
        }

        private void TurnSwitch(string playerAttack)
        {
            PlayerTurn(playerAttack);
            EnemyTurn();
            CheckGameOver();
            PlayAgain();
        }

        private void PlayerTurn(string attack)
        {
            CheckEnemyHit(attack);
            CheckEnemyDead();
          
        }

        private void EnemyTurn()
        {
            var enemyAttack = EnemyAttack();
            CheckPlayerHit(enemyAttack);
            CheckPlayerDead();
             
        }


        //Handles enemy attack - currently set to random selection. 
        private string EnemyAttack()
        {
            lbEnemyStatus.Visible = true;
            //lbEnemyStatus.Text = "Enemy is now choosing it's target.";

            Random rand = new Random();
            List<String> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            var letterSelection = rand.Next(0, 7);
            var letterChoice = letters[letterSelection];
            var numberSelection = rand.Next(1, 8);
            StringBuilder attackChoice = new StringBuilder();
            attackChoice.Append("P");
            attackChoice.Append(letters[letterSelection]);
            attackChoice.Append(numberSelection);
            return attackChoice.ToString();

        }

        //---Handles the players attack on the enemy. If hit will turn red. if miss will turn purple---//
        private void CheckEnemyHit(string text)
        {
            //---Checks Warship health and sets isdead property if hitpoints fall to zero---//


            if (EnemyShips.warShip.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.warShip.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (EnemyShips.warShip.HitPoints == 0)
                {
                    EnemyShips.warShip.IsDead = true;
                }
            }

            //---Checks Destroyer health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.destroyer.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.destroyer.HitPoints--;

                //---changes isdead property when ship health falls to zero---//
                if (EnemyShips.destroyer.HitPoints == 0)
                {
                    EnemyShips.destroyer.IsDead = true;  
                }

            }

            //---Checks Cruiser health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.cruiser.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;

                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.cruiser.HitPoints--;

                //---Changes isdead property when ship health falls to zero---//
                if (EnemyShips.cruiser.HitPoints == 0)
                {
                    EnemyShips.cruiser.IsDead = true;
                }

            }

            //---Checks Tanker health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.tanker.Location.Contains(text))
            {

                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.tanker.HitPoints--;

                //---changes isdead property when ship health falls to zero---//
                if (EnemyShips.tanker.HitPoints == 0)
                {
                    EnemyShips.tanker.IsDead = true;
                }
            }


            //---Checks Tanker health and sets isdead property if hitpoints fall to zero---//
            if (EnemyShips.uBoat.Location.Contains(text))
            {

                //---Changes hit location to red---//
                Button tempButton = enemyButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                EnemyShips.uBoat.HitPoints--;

                //---changes isdead property when ship health falls to zero---//
                if (EnemyShips.uBoat.HitPoints == 0)
                {
                    EnemyShips.uBoat.IsDead = true;
                }
            }

            //---Handles missed attacks---//
            else if (!EnemyShips.warShip.Location.Contains(text) 
                     && !EnemyShips.destroyer.Location.Contains(text) 
                     && !EnemyShips.cruiser.Location.Contains(text)
                     && !EnemyShips.tanker.Location.Contains(text)
                     && !EnemyShips.uBoat.Location.Contains(text))
            {
                //---Changes miss location to purple---//
                Button tempButton = enemyButtonList.First(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Indigo;
                //playerButtonList.Remove(tempButton);
            }
        }

        //Checks enemy ship heatlh. If a ship is destroyed the player will be notified
        private void CheckEnemyDead()
        {
         
            if (EnemyShips.warShip.IsDead == true)
            {
                if (enemyWarShipMessageDisplayed == false)
                {
                    enemyWarShipMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.warShip.Name);
                }
            }

            if (EnemyShips.destroyer.IsDead == true)
            {
                if (enemyDestroyerMessageDisplayed == false)
                {
                    enemyDestroyerMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.destroyer.Name);
                }
            }

            if (EnemyShips.cruiser.IsDead == true)
            {
                
                if (enemyCruiserMessageDisplayed == false)
                {
                    enemyCruiserMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.cruiser.Name);
                }
            }

            if (EnemyShips.tanker.IsDead == true)
            {
                
                if (enemyTankerMessagedDisplayed == false)
                {
                    enemyTankerMessagedDisplayed = true;
                    DestroyedMessage("e", EnemyShips.tanker.Name);
                }
            }

            if (EnemyShips.uBoat.IsDead == true)
            {

                if (enemyUBoatMessageDisplayed == false)
                {
                    enemyUBoatMessageDisplayed = true;
                    DestroyedMessage("e", EnemyShips.uBoat.Name);
                }
            }
        }

        private bool CheckPlayerChoice()
        {
            List<string> AlphaList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            List<string> numList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            List<string> locations = new List<string>();
            StringBuilder sb = new StringBuilder();
            StringBuilder sbLocations = new StringBuilder();

            foreach (var letter in AlphaList)
            {
                foreach (var number in numList)
                {
                    sbLocations.Append(letter);
                    sbLocations.Append(number);
                    locations.Add(sbLocations.ToString());
                    sbLocations.Clear();
                }
            }
         
                if (!locations.Contains(txtAttackBox.Text.ToUpper()))
                {
                    return false;
                }
         
            sb.Clear();
            return true;
        }

        //Verfies enemy attack on player. If hit will turn red. If miss will turn purple.
        private void CheckPlayerHit(String text)
        {

            //---Checks Warship health and sets isdead property if hitpoints fall to zero---//

            if (PlayerShip.warShip.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = playerButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                PlayerShip.warShip.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (PlayerShip.warShip.HitPoints == 0)
                {
                    PlayerShip.warShip.IsDead = true;
                }

                lbEnemyStatus.Text = $"The enemy hit your {PlayerShip.warShip.Name}!";
            }

            if (PlayerShip.destroyer.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = playerButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                PlayerShip.destroyer.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (PlayerShip.destroyer.HitPoints == 0)
                {
                    PlayerShip.destroyer.IsDead = true;
                }
                lbEnemyStatus.Text = $"The enemy hit your {PlayerShip.destroyer.Name}!";
            }

            if (PlayerShip.cruiser.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = playerButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                PlayerShip.cruiser.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (PlayerShip.cruiser.HitPoints == 0)
                {
                    PlayerShip.cruiser.IsDead = true;
                }
                lbEnemyStatus.Text = $"The enemy hit your {PlayerShip.cruiser.Name}!";
            }

            if (PlayerShip.tanker.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = playerButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                PlayerShip.tanker.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (PlayerShip.tanker.HitPoints == 0)
                {
                    PlayerShip.tanker.IsDead = true;
                }
                lbEnemyStatus.Text = $"The enemy hit your {PlayerShip.tanker.Name}!";
            }

            if (PlayerShip.uBoat.Location.Contains(text))
            {
                //---Changes hit location to red---//
                Button tempButton = playerButtonList.Find(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Firebrick;
                //enemyButtonList.Remove(tempButton);

                //---Decrements enemy ship health if hit---//
                PlayerShip.uBoat.HitPoints--;

                //changes isdead property when ship health falls to zero
                if (PlayerShip.uBoat.HitPoints == 0)
                {
                    PlayerShip.uBoat.IsDead = true;
                }
                lbEnemyStatus.Text = $"The enemy hit your {PlayerShip.uBoat.Name}!";
            }

            //---Handles missed attacks---//
            if (!PlayerShip.warShip.Location.Contains(text) 
                    && !PlayerShip.destroyer.Location.Contains(text) 
                    && !PlayerShip.cruiser.Location.Contains(text) 
                    && !PlayerShip.tanker.Location.Contains(text) 
                    && !PlayerShip.uBoat.Location.Contains(text))
            {
                //---Changes miss location to purple---//
                Button tempButton = playerButtonList.First(b => b.Name.ToString() == text);
                tempButton.BackColor = Color.Indigo;
                lbEnemyStatus.Text = $"The enemy missed.";
                //playerButtonList.Remove(tempButton);
            }

        }

        //Checks player ship health. If ship is destroyed the property will be updated here.
        private void CheckPlayerDead()
        {
            if(PlayerShip.warShip.IsDead == true)
            {
                if (playerWarShipMessageDisplayed == false)
                {
                    playerWarShipMessageDisplayed = true;
                    DestroyedMessage("p", PlayerShip.warShip.Name);
                }
            }

            if (PlayerShip.destroyer.IsDead == true)
            {
                if (playerDestroyerMessageDisplayed == false)
                {
                    playerDestroyerMessageDisplayed = true;
                    DestroyedMessage("p", PlayerShip.destroyer.Name);
                }
            }
            if (PlayerShip.cruiser.IsDead == true)
            {
                if (playerCruiserMessageDisplayed == false)
                {
                    playerCruiserMessageDisplayed = true;
                    DestroyedMessage("p", PlayerShip.cruiser.Name);
                }
            }
            if (PlayerShip.tanker.IsDead == true)
            {
                if (playerTankerMessageDisplayed == false)
                {
                    playerTankerMessageDisplayed = true;
                    DestroyedMessage("p", PlayerShip.tanker.Name);
                }
            }
            if (PlayerShip.uBoat.IsDead == true)
            {
                if (playerUBoatMessageDisplayed == false)
                {
                    playerUBoatMessageDisplayed = true;
                    DestroyedMessage("p", PlayerShip.uBoat.Name);
                }
            }

        }


        //After verifying player or enemy ship health this function will display a message once the turn a ship has been destroyed
        private void DestroyedMessage(string letter, string name)
        {
            if (letter == "e")
            {
                MessageBox.Show($"You have destroyed the {name}!");
             
            }
            if (letter == "p")
            {

                MessageBox.Show($"Your {name} was destroyed!");
            }
        }


        //Handles game over
        private void CheckGameOver()
        {
            if (PlayerShip.warShip.IsDead == true && PlayerShip.destroyer.IsDead == true && PlayerShip.cruiser.IsDead == true && PlayerShip.tanker.IsDead == true && PlayerShip.uBoat.IsDead == true)
            {
                MessageBox.Show("The enemy has decimated your fleet. You lose.");
                gameOver = true;
            }

            if (EnemyShips.warShip.IsDead == true && EnemyShips.destroyer.IsDead == true && EnemyShips.cruiser.IsDead == true && EnemyShips.tanker.IsDead == true && EnemyShips.uBoat.IsDead == true)
            {
                MessageBox.Show("All the enemies ships have been destroyed. YOU WIN!!!");
                gameOver = true;
            }

        }

        private void PlayAgain()
        {
            if(gameOver == true)
            {
                btnPlayAgain.Visible = true;
                gbAttackControls.Visible = false;
            }
        }

        private void GameReset(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void txtAttackBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnToggleAudio_Click(object sender, EventArgs e)
        {
            if (audioPlaying == true)
            {
                music.Stop();
                audioPlaying = false;

            }

            else if (audioPlaying == false)
            {
                music.PlayLooping();
                audioPlaying = true;

            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            music.Stop();
            System.Windows.Forms.Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

            Application.Restart();
        }
    }
}
