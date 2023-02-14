using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShipLibrary
{
    public class EnemyShips : IShip
    {

        public string Name { get; set ; }
        public List<string> Location { get; set; }
        public bool IsDead { get; set; }
        public int HitPoints { get; set; }

        public static List<string> chosenEnemyLocations = new List<string>();

        public static EnemyShips aircraftCarrier { get; set; }
        public static EnemyShips destroyer { get; set; }
        public static EnemyShips warship { get; set; }
        public static EnemyShips submarine { get; set; }

        //---used to randomize variable choices in enemy ship algo---//
        private static Random rand = new Random();

        public static void GetAircraftCarrier(EnemyShips enemyShip)
        {
            aircraftCarrier = enemyShip;
        }
        public static void GetDestroyer(EnemyShips enemyShip)
        {
            destroyer = enemyShip;
        }
        public static void GetWarShip(EnemyShips enemyShip)
        {
            warship = enemyShip;
        }
        public static void GetSubmarine(EnemyShips enemyShip)
        {
            submarine = enemyShip;
        }
        

        //Enemy Location Algo
        public static void GetEnemyLocations(EnemyShips enemyship, int size)
        {
            //---used to randomize variable choices---//
            
            //Random rand = new Random();

            //---Holds starting number---//
            int startingNumber = 0;

            //---Holds starting Letter---//
            int startingLetter = 0;
            
            //---Holds the locations for the enemy ship---//        
            List<string> locations = new List<string>();

            //---List used for selecting Letter placement---//
            List<string> AlphaList = new List<string>() { "Α", "Β", "Γ", "Δ", "Ε", "Ζ", "Η", "Θ", "Ι", "Κ" };

            //---Helps build the Location name---//
            StringBuilder sb = new StringBuilder();

            while(locations.Count < size)
            {
                //---Decides Alignment position---//
                int alignment = rand.Next(1, 10);

                //Exception happenig here - Collection was modified enumeration operation may not execute
                try
                {
                    //clears the list if the method starts again
                    foreach (var item in locations) 
                    {
                        locations.Remove(item);
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Decides Vertical positions
                if (alignment % 2 == 0)
                {


                    //---Limits the possible starting number by size of ship---//
                    switch (size)
                    {
                        case 5:
                            startingLetter = rand.Next(4, 9);
                            startingNumber = rand.Next(1, 6);
                            break;
                        case 4:
                            startingLetter = rand.Next(3, 9);
                            startingNumber = rand.Next(1, 7);
                            break;
                        case 3:
                            startingLetter = rand.Next(2, 9);
                            startingNumber = rand.Next(1, 8);
                            break;
                        case 2:
                            startingLetter = rand.Next(1, 9);
                            startingNumber = rand.Next(1, 9);
                            break;
                    }

                    string randLetter = AlphaList[startingLetter]; // Starting location of Letter
                    int counter = startingNumber; //Starting Location of Number

                    for (int i = 0; i < size; i++)
                    {
                        sb.Append("E"); //Appends enemy tag
                        sb.Append(AlphaList[startingLetter - i]);
                        sb.Append(counter);
                        if (!chosenEnemyLocations.Contains(sb.ToString()))
                        {
                            locations.Add(sb.ToString()); //Adds location to a temporary list
                        }
                        sb.Clear();
                    }
                }


                if (alignment % 2 == 1)
                {
                    //Chooses the starting letter for location
                    startingLetter = rand.Next(0, 7);

                    //---Limits the possible starting number by size of ship---//
                    switch (size)
                    {
                        case 5:
                            startingNumber = rand.Next(1, 6);
                            break;
                        case 4:
                            startingNumber = rand.Next(1, 7);
                            break;
                        case 3:
                            startingNumber = rand.Next(1, 8);
                            break;
                        case 2:
                            startingNumber = rand.Next(1, 9);
                            break;
                    }
              
                    string randLetter = AlphaList[startingLetter]; // Starting location of Letter
                    int Counter = startingNumber; //Starting Location of Number
                    for (int i = 0; i < size; i++)
                    {
                        sb.Append("E"); //Appends enemy tag
                        sb.Append(randLetter); //Adds the chosen letter
                        sb.Append(Counter); //Adds the chosen number
                        Counter++; //Increments the next locations number
                        if (!chosenEnemyLocations.Contains(sb.ToString()))
                        {
                            locations.Add(sb.ToString()); //Adds location to a temporary list
                        }
                        sb.Clear();
                    }
                }
            }
            enemyship.Location = locations; // Updates the ships location
            foreach(var l in locations)
                chosenEnemyLocations.Add(l);
        }

    }
}
