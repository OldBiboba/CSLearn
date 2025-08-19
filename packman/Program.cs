using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packman {

    public class Point {

        public int x = 0, y = 0;

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Point(Point p) {
            this.x = p.x;
            this.y = p.y;
        }

        public bool Equals(Point p) {
            return (this.x == p.x && this.y == p.y);
        }

    }

        internal class Program {
        static void Main(string[] args) {

            char[,] map = getMap("../../map.txt");
            drawMap(map);
            

            Point playerPos = new Point(10, 1);
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.Write("@");

            Point enemyPos = new Point(36, 11);


            bool gameIsActive = true;
            while (gameIsActive) {
                Point targetPlayerPos = new Point(playerPos);

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar) {
                    case 'w':
                        targetPlayerPos.y--;
                        break;
                    case 's':
                        targetPlayerPos.y++;
                        break;
                    case 'a':
                        targetPlayerPos.x--;
                        break;
                    case 'd':
                        targetPlayerPos.x++;
                        break;
                    case (char)27:
                        gameIsActive = false;
                        break;
                }

                Console.Clear();
                drawMap(map);

                if (map[targetPlayerPos.x, targetPlayerPos.y] != '#') {
                    playerPos = targetPlayerPos;
                }

                Console.SetCursorPosition(playerPos.x, playerPos.y);
                Console.Write("@");

                Random rand = new Random();
                int movement = rand.Next(0, 3) - 1;
                

                

            }



            Console.Clear();
            Console.WriteLine("Игра окончена");
            Console.ReadKey();
        }


        static char[,] getMap(string path) {
            string[] mapStr = File.ReadAllLines(path);


            char[,] map = new char[mapStr[0].Length, mapStr.Length];
            for (int y = 0; y < mapStr.Length; y++) {
                for (int x = 0; x < mapStr[0].Length; x++) {
                    map[x, y] = mapStr[y][x];
                }
            }



            return map;
        }

        static void drawMap(char[,] map) {
            Console.Clear();
            Console.CursorVisible = false;

            int xMax = map.GetLength(0);
            int yMax = map.GetLength(1);
            for (int y = 0; y < yMax; y++) {
                for (int x = 0; x < xMax; x++) {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
        }

        

    }
}
