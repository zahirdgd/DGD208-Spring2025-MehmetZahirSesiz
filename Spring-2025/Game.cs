using System;
using System.Threading.Tasks;

namespace InteractivePetSimulator
{
    public class Game
    {
        private bool isRunning = true;

        public async void Run()
        {
            while (isRunning)
            {
                ShowMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Pets's System");
                        break;
                    case "2":
                        ShowCreatorInfo();
                        break;                   
                    case "3":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("Try Again");
                        break;
                }

                await Task.Delay(1000); 
                Console.Clear();
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("Interactive Pet Simulator");
            Console.WriteLine("1. Pets);
            Console.WriteLine("2. Creator");
            Console.WriteLine("3. Exit");
            Console.Write("Seçiminiz: ");
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("\nMehmet Zahir SESİZ"); 
            Console.WriteLine("225040047"); 
        }

        private void ExitGame()
        {
            Console.WriteLine("Oyun kapatılıyor...");
            isRunning = false;
        }
    }
}
