using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Game {
    internal class Program {
        static void Main(string[] args) {
            Random rand = new Random();
            int num = rand.Next(1, 101);

            Console.WriteLine("Угадай число от 1 до 100");

            while (true) {
                int userNum = 0;
                try {
                    userNum = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) {
                    Console.WriteLine("Некорректный ввод! Введите число от 1 до 100");
                    continue;
                }
                
                if (num > userNum) {
                    Console.WriteLine($"Загаданное число больше {userNum}");
                }
                else if (num < userNum) {
                    Console.WriteLine($"Загаданное число менше {userNum}");
                }
                else {
                    Console.WriteLine("Вы угадали число!");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
