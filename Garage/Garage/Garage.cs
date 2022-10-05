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
        ConsoleColor ccGreen = ConsoleColor.Green;
        ConsoleColor ccRed = ConsoleColor.Red;
        ConsoleColor ccWhite = ConsoleColor.White;
        #endregion

        Car car = new Car();
        public List<Car> cars = new List<Car>();

        public void CreateGarage()
        {
            if (Utilities.isGarageCreated == true)
            {
                Utilities.WriteLineColorText("Garaż już został utworzony.", ccRed, true);
                return;
            }
            Console.Clear();
            Console.WriteLine("Witaj użytkowniku, wprowadź dane swojego garażu. Proszę podać nazwę: ");
            GarageName = Utilities.InputDataAsString();
            Console.WriteLine("Dziękuję za wprowadzenie nazwy. Proszę podać ile maksymalnie pomieści on samochodów.");
            GarageTotalSpace = Utilities.InputDataAsInt(0, 5000, 1);
            Utilities.WriteLineColorText("Garaż został poprawnie utworzony.", isConsoleCleared: true);
            Utilities.isGarageCreated = true;
        }
        public void AddCarToGarage()
        {
            if (Utilities.isGarageCreated == false)
            {
                Utilities.WriteLineColorText("Brak garażu, proszę najpierw utworzyć garaż.", ccRed, true);
                return;
            }
            if (takenSlot == GarageTotalSpace)
            {
                Utilities.WriteLineColorText("Brak miejsca w garażu! Nie można dodać nowego pojazdu.", ccRed, true);
                return;
            }
            Console.Clear();
            Console.WriteLine("Proszę podać model samochodu: ");
            string brand = Utilities.InputDataAsString(1, rgx: Utilities.rgxAZ);
            Console.WriteLine("Proszę podać markę samochodu: ");
            string model = Utilities.InputDataAsString(1,rgx:Utilities.rgxAZ);
            Console.WriteLine("Proszę podać rok produkcji: ");
            int dom = Utilities.InputDataAsInt(1950, 2022, 1);
            cars.Add(new Car{ Brand = brand, Model = model, Dom = dom });
            Console.Clear();
            takenSlot++;
            Utilities.WriteLineColorText("Poprawnie dodano samochód.");
        }
        public void PrintAllCars()
        {
            Console.Clear();
            if (Utilities.isGarageCreated == false)
            {
                Utilities.WriteLineColorText("Brak garażu, proszę najpierw utworzyć garaż.", ccRed, true);
                return;
            }
            if (cars.Count() == 0)
            {
                Utilities.WriteLineColorText("W garażu nie ma żadnych samochodów.", ccRed, true);
            }
            else
            {
                int i = 0;
                foreach (var car in cars)
                {
                    i++;
                    Utilities.WriteLineColorText($"{i}. Marka: ", $"{car.Brand}", multiplierTab: 2);
                    Utilities.WriteLineColorText($"{i}. Model: ", $"{car.Model}", multiplierTab:2);
                    Utilities.WriteLineColorText($"{i}. Rok produkcji: ", $"{car.Dom}", multiplierTab:1);
                    Utilities.Underline('=', 50);
                }
            }
        }
        public void DisplayInfoAboutGarage()
        {
            if (Utilities.isGarageCreated == false)
            {
                Utilities.WriteLineColorText("Brak garażu, proszę najpierw utworzyć garaż.", ccRed, true);
            }
            else
            {
                Utilities.WriteLineColorText($"Nazwa garażu: ", $"{GarageName}",isConsoleCleared: true, multiplierTab: 5);
                Utilities.WriteLineColorText("Całkowita pojemność garażu: ",$"{GarageTotalSpace}", multiplierTab: 3);
                Utilities.WriteLineColorText("Dostępna ilość wolnych miejsc w garażu: ", $"{CalcEmptySpaceInGarage()}", multiplierTab: 1);
                Utilities.Underline('=', 50);
            }
        }
        private int CalcEmptySpaceInGarage()
        {
            GarageAvailableSpace = GarageTotalSpace - takenSlot;
            return GarageAvailableSpace;
        }
    }
}
