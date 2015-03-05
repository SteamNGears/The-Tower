using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheTower
{
    class Program
    {
        static void Main(string[] args)
        {
            PawnFactory fact = new PawnFactory();

            Pawn[] Party= new Pawn[4];
            Party[0] = fact.MakeWarrior("Agrias");
            Party[1] = fact.MakeWarrior("Anax");
            Party[2] = fact.MakeWarrior("Cynede");
            Party[3] = fact.MakeWarrior("Tymaret");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartGame());
            /*Form MainWindow=null;
            MainWindow = new StartGame(ref MainWindow);*/

            /*Grid Level = new Grid();
            Level.SetGrid(25,25);
            PawnFactory PFactory = new PawnFactory();
            Pawn p1 = PFactory.MakeWarrior("Agrias");
            Pawn p2 = PFactory.MakeBomb("Perfo");
            Pawn inRange = PFactory.MakeBomb("[Range]");
            Level.SetTile(p1, 5, 5);
            Level.SetTile(p2, 5, 6);
            Level.PrintGrid();
            Console.WriteLine(p1.Name+" "+p1.Health);
            Console.WriteLine(p2.Name+" "+p2.Health);
            p2.UseSpecial(p2.GetTile());
            Console.WriteLine(p1.Name+" "+p1.Health);
            Console.WriteLine(p2.Name+" "+p2.Health);
            p1.UseSpecial(p1.GetTile());
            Console.WriteLine(p1.Name + " " + p1.Health);
            Console.WriteLine(p2.Name + " " + p2.Health);
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////////////////"+
                              "/////////////////////////////////////////////////////////////////////////////////////////");*/
            /*
            Console.ReadLine();
            Level = new Grid(); Level.SetGrid(25, 25);
            Level.SetNode(p1, 10, 10);
            Level.SetNode(p2, 10, 11);
            Level.SetNode(p2, 10, 9);
            Level.SetNode(p2, 9, 10);
            Level.SetNode(p2, 11, 10);
            Level.SetNode(p2, 9, 9);
            Level.SetNode(p2, 9, 11);
            Level.SetNode(p2, 11, 11);
            Level.SetNode(p2, 11, 9);
            rangeTest(p1, inRange);
            Level.PrintGrid();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////////////////" +
                              "/////////////////////////////////////////////////////////////////////////////////////////");
            Console.ReadLine();
            Level = new Grid(); Level.SetGrid(25, 25);
            Level.SetNode(p1, 10, 10);
            Level.SetNode(p2, 10, 11);
            Level.SetNode(p2, 10, 9);
            Level.SetNode(p2, 9, 10);
            Level.SetNode(p2, 11, 10);
            Level.SetNode(p2, 11, 9);
            Level.SetNode(p2, 9, 9);
            Level.SetNode(p2, 9, 11);
            rangeTest(p1, inRange);
            Level.PrintGrid();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////////////////" +
                              "/////////////////////////////////////////////////////////////////////////////////////////");
*/
        }
        public static void rangeTest(Pawn p1, Actor inRange)
        {
            TileSet range = p1.GetTile().GetRange(p1.Speed);
            foreach (Tile o in range)
                o.AddActor(inRange);
        }
    }
}
