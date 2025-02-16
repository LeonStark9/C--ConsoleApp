using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEW_Game.Menu;

namespace SEW_Game
{
    public class Program
    {
        static void Main(string[] args)
        {

             MainMenu menu1 = new MainMenu();
             menu1.printMenu();
                
        }

        /*public static StreamReader GetFile()
        {
            if (File.Exists("highscore.txt"))
            {
                StreamReader sr = new StreamReader("highscore.txt");
                return sr;
            }
            else 
            {
                File.Create("highscore.txt");
                StreamReader sr = new StreamReader("highscore.txt");
                return sr;
            }
        }*/
    }
}
