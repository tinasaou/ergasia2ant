using BattleShipLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form3 : Form
    {
        SoundPlayer music = new SoundPlayer(@"C:\Users\Steven\Desktop\MSSA\BattleShipGame\Battleship\Sound\form3.wav");
        bool audioPlaying = true;
        /*Task chooseOwn = new Task (() =>
        {
            Form3.ActiveForm.Hide();
            Form2 form2 = new Form2();
            form2.Show(); 
        });
        
        Task autoChoose = new Task (() =>
        {
            Form3.ActiveForm.Close();
            Form1 form1 = new Form1();
            form1.Show(); 
        });*/

        public Form3()
        {
            InitializeComponent();
            
        }

        private void btnChooseOwn_Click(object sender, EventArgs e)
        {

            /*Form2 form2 = new Form2();
            Parallel.Invoke(() => ActiveForm.Close(), 
                            () => form2.Show());*/

            Form3.ActiveForm.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnAutoCreate_Click(object sender, EventArgs e)
        {


            //Thread interval to prevent duplicater ships
            //Thread.Sleep(10);

            /*Task playerShips = new Task(() => CreatePlayerShips());
            Task enemyships = new Task(() => CreateEnemyShips());

            playerShips.Start();
            enemyships.Start();*/

            CreatePlayerShips();
            //Thread.Sleep(20);
            CreateEnemyShips();

            music.Stop();
            Form3.ActiveForm.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void CreatePlayerShips()
        {
            //---Player Models Below---//

            //Creates and sets Aircraft Carrier object for player
            PlayerShip aircraftCarrier = new PlayerShip();
            aircraftCarrier.Name = "Aircraft Carrier";
            aircraftCarrier.HitPoints = 5;
            PlayerShip.GetWarShip(aircraftCarrier);
            PlayerShip.GetPlayerLocations(aircraftCarrier, aircraftCarrier.HitPoints);

            //Creates and sets Destroyer object for player
            PlayerShip destroyer = new PlayerShip();
            destroyer.Name = "Destroyer";
            destroyer.HitPoints = 4;
            PlayerShip.GetDestroyer(destroyer);
            PlayerShip.GetPlayerLocations(destroyer, destroyer.HitPoints);

            //Creates and sets Warship object for player
            PlayerShip warship = new PlayerShip();
            warship.Name = "Warship";
            warship.HitPoints = 3;
            PlayerShip.GetCruiser(warship);
            PlayerShip.GetPlayerLocations(warship, warship.HitPoints);

            //Creates and sets Submarine object for player
            PlayerShip submarine = new PlayerShip();
            submarine.Name = "Submarine";
            submarine.HitPoints = 2;
            PlayerShip.GetTanker(submarine);
            PlayerShip.GetPlayerLocations(submarine, submarine.HitPoints);

        }

        private void CreateEnemyShips()
        {
            //---Enemy Models Below---//

            //---Creates and sets Aircraft Carrier object for enemy
            EnemyShips enemyAircraftCarrier = new EnemyShips();
            enemyAircraftCarrier.Name = "Enemy Aircraft Carrier";
            enemyAircraftCarrier.HitPoints = 5;
            EnemyShips.GetEnemyLocations(enemyAircraftCarrier, enemyAircraftCarrier.HitPoints);
            EnemyShips.GetAircraftCarrier(enemyAircraftCarrier);

            //Creates and sets Destroyer object for enemy
            EnemyShips enemyDestroyer = new EnemyShips();
            enemyDestroyer.Name = "Enemy Destroyer";
            enemyDestroyer.HitPoints = 4;
            EnemyShips.GetEnemyLocations(enemyDestroyer, enemyDestroyer.HitPoints);
            EnemyShips.GetDestroyer(enemyDestroyer);


            //Creates and sets Warship object for player
            EnemyShips enemyWarship = new EnemyShips();
            enemyWarship.Name = "Enemy Warship";
            enemyWarship.HitPoints = 3;
            EnemyShips.GetEnemyLocations(enemyWarship, enemyWarship.HitPoints);
            EnemyShips.GetWarShip(enemyWarship);

            //Creates and sets Submarine object for enemy
            EnemyShips enemySubmarine = new EnemyShips();
            enemySubmarine.Name = "Enemy Submarine";
            enemySubmarine.HitPoints = 2;
            EnemyShips.GetEnemyLocations(enemySubmarine, enemySubmarine.HitPoints);
            EnemyShips.GetSubmarine(enemySubmarine);

        }

       
        }
    }
}
}