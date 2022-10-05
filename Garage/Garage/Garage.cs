using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage
    {
        #region Properties
        public string GarageName { get; set; }
        public int GarageTotalSpace { get; set; }
        public int GarageAvailableSpace { get; set; }

        int takenSlot = 0;
        #endregion

        Car car = new Car();
        public List<Car> cars = new List<Car>();

        public void CreateGarage()
        {
            if (Utilities.isGarageCreated == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Garaż już został utworzony.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.Clear();
            Console.WriteLine("Witaj użytkowniku, wprowadź dane swojego garażu. Proszę podać nazwę: ");
            GarageName = Utilities.InputDataAsString();
            Console.WriteLine("Dziękuję za wprowadzenie nazwy. Proszę podać ile maksymalnie pomieści on samochodów.");
            GarageTotalSpace = Utilities.InputDataAsInt(0, 5000, 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Garaż został poprawnie utworzony.");
            Console.ForegroundColor = ConsoleColor.White;
            Utilities.isGarageCreated = true;
        }
        public void AddCarToGarage()
        {
            if (Utilities.isGarageCreated == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak garażu, proszę najpierw utworzyć garaż.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (takenSlot == GarageTotalSpace)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak miejsca w garażu! Nie można dodać nowego pojazdu.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.Clear();
            Console.WriteLine("Proszę podać model samochodu: ");
            string garageName = Utilities.InputDataAsString();
            Console.WriteLine("Proszę podać model samochodu: ");
            int dom = Utilities.InputDataAsInt(1950, 2022, 1);
            cars.Add(new Car{ Model = garageName, Dom = dom });
            Console.Clear();
            takenSlot++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Poprawnie dodano samochód.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintAllCars()
        {
            Console.Clear();
            if (Utilities.isGarageCreated == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak garażu, proszę najpierw utworzyć garaż.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (cars.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("W garażu nie ma żadnych samochodów.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int i = 0;
                foreach (var car in cars)
                {
                    i++;
                    //Console.Write($"Model: {car.Model}\tRok produkcji: {car.Dom}");
                    Console.Write($"{i}. Model: \t\t");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{car.Model}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{i}. Rok produkcji: \t");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{car.Dom}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("==================================");
                }
            }
        }
        public void DisplayInfoAboutGarage()
        {
            if (Utilities.isGarageCreated == false)
            {
                //Console.Clear();
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Brak garażu, proszę najpierw utworzyć garaż.");
                //Console.ForegroundColor = ConsoleColor.White;
                Utilities.WriteLineColorText("Brak garażu, proszę najpierw utworzyć garaż.", ConsoleColor.Red, true);
            }
            else
            {
                Console.Clear();
                Console.Write($"Nazwa garażu: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\t\t\t\t\t{GarageName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Całkowita pojemność garażu: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\t\t\t{GarageTotalSpace}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Dostępna ilość wolnych miejsc w garażu: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\t{CalcEmptySpaceInGarage()}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }           
        }
        private int CalcEmptySpaceInGarage()
        {
            GarageAvailableSpace = GarageTotalSpace - takenSlot;
            return GarageAvailableSpace;
        }
    }
}
