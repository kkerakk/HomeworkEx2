using System.Text.RegularExpressions;
using System;

//Regex rgxAZ09 = new Regex("[^a-zA-Z0-9]");
namespace Garage
{
    static class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            DisplayMenu();

            void DisplayMenu()
            {
                while (true)
                {
                    Console.WriteLine("Wcisnij odpowiedni przycisk, żeby przejść dalej:");
                    Console.WriteLine("1. Utwórz nowy garaż\n2. Utwórz nowe auto\n3. Przejrzyj auta w garażu\n4. Wyświetl dane o garażu\n5. Wyjdź z programu");
                    int.TryParse(Console.ReadLine(), out int input);

                    switch (input)
                    {
                        case 1:
                            garage.CreateGarage();
                            break;
                        case 2:
                            garage.AddCarToGarage();
                            break;
                        case 3:
                            garage.PrintAllCars();
                            break;
                        case 4:
                            garage.DisplayInfoAboutGarage();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
