using System;
using System.Threading;

namespace Exam
{
    class Program
    {
        static void FillArrRandom(int[] arr, int start, int finish, int size)
        {
            if (size > finish - start)
            {
                Console.WriteLine("Error: Something went wrong when filling array");
                return;
            }
            for (int i = 0; i < size;)
            {
                bool found = false;
                Random random = new Random();
                int number = random.Next(start, finish);
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] == number)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    arr[i++] = number;
                }
            }
        }
        static string ControlConsole(string[,] arr, int size, int questionIndex)
        {
            int[] randomAnswer = new int[3];
            FillArrRandom(randomAnswer, 1, 4, 3);
            bool[] isChoosenLine = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(arr[questionIndex, 0]);
                for (int i = 0; i < size; i++)
                {
                    if (isChoosenLine[i])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"{char.ConvertFromUtf32(65 + i)}.");
                    Console.WriteLine(arr[questionIndex, randomAnswer[i]]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return arr[questionIndex, randomAnswer[index]];
                }
                for (int i = 0; i < size; i++)
                {
                    isChoosenLine[i] = false;
                }
                isChoosenLine[index] = true;

            }
        }
        static void Main(string[] args)
        {
            #region Questions
            string[,] questions = new string[10, 4];
            int[] answers = new int[10];
            //0
            questions[0, 0] = "Eritrea, which became the 182nd member of the United Nations in 1993, is on the continent of";
            questions[0, 1] = "Asia";
            questions[0, 2] = "Africa";//correct
            answers[0] = 2;
            questions[0, 3] = "Europe";
            //1
            questions[1, 0] = "For which of the following disciplines is Nobel Prize awarded?";
            questions[1, 1] = "Physiology or Medicine";
            questions[1, 2] = "Literature, Peace and Economics";
            questions[1, 3] = "All of the above";//correct
            answers[1] = 3;
            //2
            questions[2, 0] = "Shell is the exclusive feature of";
            questions[2, 1] = "UNIX";//correct
            answers[2] = 1;
            questions[2, 2] = "DOS";
            questions[2, 3] = "Application software";
            //3
            questions[3, 0] = "Name the application used for creating presentations";
            questions[3, 1] = "MS Access";
            questions[3, 2] = "MS Excel";
            questions[3, 3] = "MS PowerPoint";//correct
            answers[3] = 3;
            //4       
            questions[4, 0] = "Which of the following can be considered as portable computer?";
            questions[4, 1] = "Desktop";
            questions[4, 2] = "PDA";//correct
            answers[4] = 2;
            questions[4, 3] = "Mini computer";
            //5
            questions[5, 0] = "CPU is an abbreviation for";
            questions[5, 1] = "Control processing unit";
            questions[5, 2] = "Central processing unit";//correct
            answers[5] = 2;
            questions[5, 3] = "Command processing unit";
            //6
            questions[6, 0] = "Which of the following is related to register?";
            questions[6, 1] = "Sequential circuit";//correct
            answers[6] = 1;
            questions[6, 2] = "Digital circuit";
            questions[6, 3] = "Arithmetic circuit";
            //7
            questions[7, 0] = "From which of the following the CPU chip is partially made?";
            questions[7, 1] = "Copper";
            questions[7, 2] = "Silica";//correct
            answers[7] = 2;
            questions[7, 3] = "Gold";
            //8
            questions[8, 0] = "Mechanism to protect network from outside attack is";
            questions[8, 1] = "Digital signature";
            questions[8, 2] = "Anti-virus";
            questions[8, 3] = "Firewall";//correct
            answers[8] = 3;
            //9
            questions[9, 0] = "Non physical components of the computer are referred to as";
            questions[9, 1] = "Software";//correct
            answers[9] = 1;
            questions[9, 2] = "Hardware";
            questions[9, 3] = "Program";
            #endregion
            int[] randomQuestions = new int[10];
            int score = 0;
            int correct = 0;
            int wrong = 0;
            FillArrRandom(randomQuestions, 0, 10, 10);
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                int index = randomQuestions[i];
                string answer = ControlConsole(questions, 3, index);
                Console.Clear();
                if (answer == questions[index, answers[index]])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!!");
                    score += 10;
                    correct++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong!!");
                    if (score > 0) score -= 10;
                    wrong++;
                }
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Clear();
            Console.WriteLine($"You complete exam\nScore: {score} \nCorrect Answers: {correct} \nWrong Answers: {wrong}");
        }
    }
}
