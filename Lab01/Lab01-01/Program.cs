// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== GUESSING NUMBER ===");

            Random random = new Random();
            int targetNumber = random.Next(100, 999);
            string targetString = targetNumber.ToString();

            int attempt = 1, MAX_GUESS = 7;
            string guess, feedback = "";
            while (feedback != "+++" && attempt <= MAX_GUESS)
            {
                Console.Write($"Lan doan thu {attempt}: ");
                guess = Console.ReadLine();
                feedback = GetFeedback(targetString, guess);
                Console.WriteLine("Phan hoi tu may tinh: {0}", feedback);
                attempt++;
            }
            Console.WriteLine($"Nguoi choi da doan {attempt - 1} Lan. Tro choi ket thuc!");
            if (attempt > MAX_GUESS)
                Console.WriteLine($"Nguoi choi thua cuoc. So can doan la: {targetNumber}");
            else
                Console.WriteLine("Nguoi choi thang cuoc!", attempt);

            Console.ReadLine();
        }
        static string GetFeedback(string target, string guess)
        {
            string feedback = "";
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == guess[i])
                    feedback += "+";
                else if (target.Contains(guess[i].ToString()))
                    feedback += "?";
            }
            return feedback;
        }
    }
}
