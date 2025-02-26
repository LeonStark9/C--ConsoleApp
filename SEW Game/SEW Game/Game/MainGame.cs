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

        private char zeichen = '0';

        private bool running = true;

        private string pacman = "C";

        private int leftPadding = 0;
        private int topPadding  = 5;

        private int score = 0;
        const int MAX_X = 27;
        const int MAX_Y = 29;

        public void Eingabe()
        {
            ConsoleKeyInfo ein;

            while (zeichen != 'x')
            {
                ein = Console.ReadKey(true);
                zeichen = ein.KeyChar;
            }
        }
        public void Game()
        {

            int x = 1; // lokale Variable
            int y = 1;

            
            // parallele Methode zum Einlesen des Tastendrucks
            var myThread = new System.Threading.Thread(Eingabe);
            myThread.Start();

            while (zeichen != 'x')
            {
                // "alte" Position => löschen
                ZeichenXYAusgeben(" ", x, y);

                switch (zeichen)
                {
                    case 'w':
                        if (!checkCollision(x, y - 1)) y--;
                        break;
                    case 'a':
                        if (!checkCollision(x - 1, y)) x--;
                        break;
                    case 's':
                        if (!checkCollision(x, y + 1)) y++;
                        break;
                    case 'd':
                        if (!checkCollision(x + 1, y)) x++;
                        break;
                }

                if (x < 0) x = MAX_X;
                if (y < 0) y = 0;
                if (x > MAX_X) x = 0;
                if (y > MAX_Y) y = MAX_Y;
                ZeichenXYAusgeben(pacman, x, y);
                //Console.SetCursorPosition(x, y);
                //Console.WriteLine(pacman);
                System.Threading.Thread.Sleep(100);

            } // END while (zeichen != 'x')

            Console.ForegroundColor = ConsoleColor.Red;
            ZeichenXYAusgeben("Game over!!", MAX_X / 2 - 5, MAX_Y / 2);
            //Console.SetCursorPosition(MAX_X / 2 - 5, MAX_Y / 2);
            //Console.WriteLine("Game over!!");
            Console.ReadLine();
        }

        private void ZeichenXYAusgeben(string zeichen, int x, int y)
        {
            Console.SetCursorPosition(leftPadding + x, topPadding + y);
            Console.Write(zeichen);

        }
       
        public bool checkCollision(int x, int y)
        {
            x = (x + MAX_X+1) % (MAX_X+1);
            if (MapLayout[y][x] == '#')
            {
                return true;
            }
            if (MapLayout[y][x] == '.')
            {
                score++;
                return false;
            }
            return false;
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

            int windowWidth = Console.WindowWidth;
            int textLength = map[0].Length;
            leftPadding = (windowWidth - textLength) / 2;

            foreach (string line in map)
            {
                
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(line);
            }
        }
    }
}
