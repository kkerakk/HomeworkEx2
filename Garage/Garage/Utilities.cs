using System.Text.RegularExpressions;


namespace Garage
{
    public static class Utilities
    {
        public static bool isGarageCreated = false;
        public static string InputDataAsString()
        {
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length >= 2 && input.Length <= 100)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Podano niepoprawną nazwę garażu. Proszę sprobować raz jeszcze");
            }
            return input;
        }
        public static string InputDataAsString(int valueSwitch)
        { 
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length >= 2 && input.Length <= 100)
            {
                return input;
            }
            else
            {
                switch (valueSwitch)
                {
                    case 1:
                        Console.WriteLine("Podano niepoprawną nazwę garażu. Proszę sprobować raz jeszcze");
                        break;
                    default:
                        Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
                        break;
                }
                return InputDataAsString(valueSwitch);
            }
        }
        public static string InputDataAsString(int valueSwitch, Regex rgx)
        {
            string input = Console.ReadLine();
            bool isString = rgx.IsMatch(input);
            if (!isString && !string.IsNullOrEmpty(input) && input.Length >= 2)
            {
                return input;
            }
            else
            {
                switch (valueSwitch)
                {
                    case 1:
                        Console.WriteLine("Podano niepoprawną nazwę garażu. Proszę sprobować raz jeszcze");
                        break;
                    default:
                        Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
                        break;
                }
                return InputDataAsString(valueSwitch, rgx);
            }
        }
        ///<summary>Get Data as int input with validation </summary>
        public static int InputDataAsInt(int minValue, int maxValue, int valueSwitch)
        {
            int number;

            string input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Niepoprawny format danych, proszę spróbować raz jeszcze");
                return InputDataAsInt(minValue, maxValue, valueSwitch);
            }
            else if ((number < minValue || number > maxValue))
            {
                switch (valueSwitch)
                {
                    case 1:
                        Console.WriteLine($"Podano niepoprawną ilość miejsc w garażu, proszę spróbować raz jeszcze. Prawidłowy przedział jest od {minValue} do {maxValue}");
                        break;
                    default:
                        Console.WriteLine("Podano niepoprawną wartość");
                        break;
                }
                return InputDataAsInt(minValue, maxValue, valueSwitch);
            }
            else
            {
                return number;
            }
        }
        public static void WriteColorText(string textColored, ConsoleColor firstColor = ConsoleColor.Red, bool isConsoleCleared = false)
        {
            if (isConsoleCleared)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.Write(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteColorText(string text,string textColored,ConsoleColor firstColor = ConsoleColor.White,ConsoleColor secondColor = ConsoleColor.Red, bool isConsoleCleared = false)
        {
            if (isConsoleCleared)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.Write(text);
            Console.ForegroundColor = secondColor;
            Console.Write(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLineColorText(string textColored, ConsoleColor firstColor = ConsoleColor.Red, bool isConsoleCleared = false)
        {
            if (isConsoleCleared)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.WriteLine(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
