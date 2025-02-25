using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SEW_Game.Game
{
    public class MainGame
    {
        public MainGame() { }

        public char zeichen = '0';

        public bool running = true;

        public string pacman = "C";

        public void Eingabe()
        {
            ConsoleKeyInfo ein;

            while (zeichen != 'x')
            {
                ein = Console.ReadKey(true);
                zeichen = ein.KeyChar;
            }
        }
        public void Game(string[] args)
        {

            int x = 20; // lokale Variable
            int y = 5;

            const int MAX_X = 40;
            const int MAX_Y = 10;

            // parallele Methode zum Einlesen des Tastendrucks
            var myThread = new System.Threading.Thread(Eingabe);
            myThread.Start();

            while (zeichen != 'x')
            {
                // "alte" Position => löschen
                Console.SetCursorPosition(x, y);
                Console.WriteLine("   ");

                switch (zeichen)
                {
                    case 'w':
                        y--;
                        break;
                    case 'a':
                        x--;
                        break;
                    case 's':
                        y++;
                        break;
                    case 'd':
                        x++;
                        break;
                }

                if (x < 0) x = 0;
                if (y < 0) y = 0;
                if (x > MAX_X - 3) x = MAX_X - 3;
                if (y > MAX_Y - 3) y = MAX_Y - 3;

                Console.SetCursorPosition(x, y);
                Console.WriteLine(pacman);
                System.Threading.Thread.Sleep(200);

            } // END while (zeichen != 'x')

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(MAX_X / 2 - 5, MAX_Y / 2);
            Console.WriteLine("Game over!!");
            Console.ReadLine();
        }



        public string[] MapLayout { get; set; } = {
                "############################",
                "#............##............#",
                "#.####.#####.##.#####.####.#",
                "#.####.#####.##.#####.####.#",
                "#.####.#####.##.#####.####.#",
                "#..........................#",
                "#.####.##.########.##.####.#",
                "#.####.##.########.##.####.#",
                "#......##....##....##......#",
                "######.##### ## #####.######",
                "     #.##### ## #####.#     ",
                "     #.##          ##.#     ",
                "     #.## ###--### ##.#     ",
                "######.## #      # ##.######",
                "      .   #      #   .      ",
                "######.## #      # ##.######",
                "     #.## ######## ##.#     ",
                "     #.##          ##.#     ",
                "     #.## ######## ##.#     ",
                "######.## ######## ##.######",
                "#............##............#",
                "#.####.#####.##.#####.####.#",
                "#.####.#####.##.#####.####.#",
                "#...##................##...#",
                "###.##.##.########.##.##.###",
                "#......##....##....##......#",
                "#.##########.##.##########.#",
                "#.##########.##.##########.#",
                "#..........................#",
                "############################"
            };


        public void PrintMap(string[] map)
        {
            Console.Clear();

            string fileContent = Program.GetFile().ReadToEnd();
            Console.WriteLine("Score: ");
            Console.WriteLine("Highscore: " + fileContent);
            Console.WriteLine();
            Console.WriteLine();

            foreach (string line in map)
            {
                int windowWidth = Console.WindowWidth;
                int textLength = map.Length;
                int leftPadding = (windowWidth - textLength) / 2;

                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(line);
            }
        }
    }
}
