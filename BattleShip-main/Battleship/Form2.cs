using BattleShipLibrary;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship

{
    public partial class Form2 : Form
    {
        SoundPlayer music = new SoundPlayer(@"C:\Users\Steven\Desktop\MSSA\BattleShipGame\Battleship\Sound\form2.wav");
        bool audioPlaying = true;
        List<Button> playerButtonList;
        bool result;

        List<string> WS = new List<string>();
        List<string> DS = new List<string>();
        List<string> CS = new List<string>();
        List<string> TK = new List<string>();
        List<string> UB = new List<string>();

        public Form2()
        {
            InitializeComponent();
            ButtonLoad();
        }

      

        private void btnCreateShips_Click(object sender, EventArgs e)
        {
     
            /*List<string> WS = new List<string>() { txtWS1.Text, txtWS2.Text, txtWS3.Text, txtWS4.Text, txtWS5.Text };
            List<string> DS = new List<string>() { txtDS1.Text, txtDS2.Text, txtDS3.Text, txtDS4.Text };
            List<string> CS = new List<string>() { txtCS1.Text, txtCS2.Text, txtCS3.Text };
            List<string> TK = new List<string>() { txtTK1.Text, txtTK2.Text };
            List<string> UB = new List<string>() { txtUB1.Text };*/

            result = ValidateUserChoices();

            if (result == true)
            {
                SetUserChoices();
                //Corrects the Names of the locations and Invokes Capitalization
                AC = UpdatePlayerList(AC);
                DS = UpdatePlayerList(DS);
                WS = UpdatePlayerList(WS);
                SM = UpdatePlayerList(SM);

                //Method call to create player ships
                CreatePlayerShips(AC, DS, WS, SM);

                //Method call to create enemy ships
                CreateEnemyShips();

                Form2.ActiveForm.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }

            else if(result == false)
            {
                MessageBox.Show("Please enter valid choices. Choices entered must be one letter and one number per box and no more than two charecters long. EX: A1, B2");
            }
        }

        public bool ValidateUserChoices()
        {
            List<string> tempList = new List<string>();
            tempList.Add(txtWS1.Text);
            tempList.Add(txtWS2.Text);
            tempList.Add(txtWS3.Text);
            tempList.Add(txtWS4.Text);
            tempList.Add(txtWS5.Text);

            tempList.Add(txtDS1.Text);
            tempList.Add(txtDS2.Text);
            tempList.Add(txtDS3.Text);
            tempList.Add(txtDS4.Text);

            tempList.Add(txtCS1.Text);
            tempList.Add(txtCS2.Text);
            tempList.Add(txtCS3.Text);

            tempList.Add(txtTK1.Text);
            tempList.Add(txtTK2.Text);

            tempList.Add(txtUB1.Text);

            List<string> AlphaList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            List<string> numList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            List<string> locations = new List<string>();
            int counter = 1;
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


            for(int i = 0; i < tempList.Count; i++)
            {
                if (!locations.Contains(tempList[i].ToUpper()))
                {
                    return false;
                }
            }

            sb.Clear();
            return true;
        }
    
        private void SetUserChoices()
        {
            WS.Add(txtWS1.Text);
            WS.Add(txtWS2.Text);
            WS.Add(txtWS3.Text);
            WS.Add(txtWS4.Text);
            WS.Add(txtWS5.Text);

            DS.Add(txtDS1.Text);
            DS.Add(txtDS2.Text);
            DS.Add(txtDS3.Text);
            DS.Add(txtDS4.Text);

            CS.Add(txtCS1.Text);
            CS.Add(txtCS2.Text);
            CS.Add(txtCS3.Text);

            TK.Add(txtTK1.Text);
            TK.Add(txtTK2.Text);

            UB.Add(txtUB1.Text);

        }

        private void ClearTextBoxes()
        {
            txtWS1.Clear();
            txtWS2.Clear();
            txtWS3.Clear();
            txtWS4.Clear();
            txtWS5.Clear();

            txtDS1.Clear();
            txtDS2.Clear();
            txtDS3.Clear();
            txtDS4.Clear();

            txtCS1.Clear();
            txtCS2.Clear();
            txtCS3.Clear();

            txtTK1.Clear();
            txtTK2.Clear();

            txtUB1.Clear();
        }

        private void CreatePlayerShips(List<string> WS, List<string> DS, List<string> CS, List<string> TK, List<string> UB)
        {

            //---Player Models Below---//

            //Creates and sets Warship object for player
            PlayerShip warShip = new PlayerShip();
            warShip.Name = "Warship";
            warShip.Location = WS;
            warShip.HitPoints = 5;
            PlayerShip.GetWarShip(warShip);

            //Creates and sets Destroyer object for player
            PlayerShip destroyer = new PlayerShip();
            destroyer.Name = "Destroyer";
            destroyer.Location = DS;
            destroyer.HitPoints = 4;
            PlayerShip.GetDestroyer(destroyer);

            //Creates and sets Cruiser object for player
            PlayerShip cruiser = new PlayerShip();
            cruiser.Name = "Cruiser";
            cruiser.Location = CS;
            cruiser.HitPoints = 3;
            PlayerShip.GetCruiser(cruiser);

            //Creates and sets Tanker object for player
            PlayerShip tanker = new PlayerShip();
            tanker.Name = "Tanker";
            tanker.Location = TK;
            tanker.HitPoints = 2;
            PlayerShip.GetTanker(tanker);

            //Creates and sets UBoat object for player
            PlayerShip uBoat = new PlayerShip();
            uBoat.Name = "UBoat";
            uBoat.Location = UB;
            uBoat.HitPoints = 1;
            PlayerShip.GetUBoat(uBoat);
        }

        private void CreateEnemyShips()
        {
            //---Enemy Models Below---//

            //---Creates and sets Warship object for enemy
            EnemyShips enemyWarShip = new EnemyShips();
            enemyWarShip.Name = "Enemy Warship";
            enemyWarShip.HitPoints = 5;
            EnemyShips.GetEnemyLocations(enemyWarShip, enemyWarShip.HitPoints);
            EnemyShips.GetWarShip(enemyWarShip);

            //Creates and sets Destroyer object for enemy
            EnemyShips enemyDestroyer = new EnemyShips();
            enemyDestroyer.Name = "Enemy Destroyer";
            enemyDestroyer.HitPoints = 4;
            EnemyShips.GetEnemyLocations(enemyDestroyer, enemyDestroyer.HitPoints);
            EnemyShips.GetDestroyer(enemyDestroyer);

            //Creates and sets Cruiser object for player
            EnemyShips enemyCruiser = new EnemyShips();
            enemyCruiser.Name = "Enemy Cruiser";
            enemyCruiser.HitPoints = 3;
            EnemyShips.GetEnemyLocations(enemyCruiser, enemyCruiser.HitPoints);
            EnemyShips.GetCrusier(enemyCruiser);

            //Creates and sets Tanker object for enemy
            EnemyShips enemyTanker = new EnemyShips();
            enemyTanker.Name = "Enemy Tanker";
            enemyTanker.HitPoints = 2;
            EnemyShips.GetEnemyLocations(enemyTanker, enemyTanker.HitPoints);
            EnemyShips.GetTanker(enemyTanker);

            //Creates and sets UBoat object for player
            EnemyShips enemyUBoat = new EnemyShips();
            enemyUBoat.Name = "Enemy UBoat";
            enemyUBoat.HitPoints = 1;
            EnemyShips.GetEnemyLocations(enemyUBoat, enemyUBoat.HitPoints);
            EnemyShips.GetUBoat(enemyUBoat);
        }

        public List<string> UpdateEnemyList(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            List<string> newList = new List<string>();

            foreach(String s in list)
            {
                sb.Append("E");
                sb.Append(s.ToUpper());
                newList.Add(sb.ToString());
                sb.Clear();
            }

            return newList;
        }

        public List<string> UpdatePlayerList(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            List<string> newList = new List<string>();

            foreach (String s in list)
            {
                sb.Append("P");
                sb.Append(s.ToUpper());
                newList.Add(sb.ToString());
                sb.Clear();
            }

            return newList;
        }



        public void ButtonLoad()
        {
            List<string> AlphaList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            playerButtonList = new List<Button>();

            var counter = 1;
            var letterPlaceholder = 0;

            foreach (Control c in gbTempPlayerSpace.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Text = "";
                    //c.Text = "P" + AlphaList[letterPlaceholder] + counter;
                    c.Name = "P" + AlphaList[letterPlaceholder] + counter;
                }

                if (counter <= 8)
                {
                    counter++;
                }

                if (counter > 8)
                {
                    counter = 1;
                    letterPlaceholder++;
                }
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void ReloadApp()
        {
            
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnAudioToggle_Click(object sender, EventArgs e)
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void txtWS1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
