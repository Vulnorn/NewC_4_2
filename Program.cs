namespace NewC_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int positionHealthBar = 10;
            int positionManaBar = 11;
            int lengthBar = 10;
            int lengthFilledHealthBar;
            int lengthFilledManaBar;
            string healthBar = "Здоровье";
            string manaBar = "Мана";
            char simbolHealth = '#';
            char simbolMana = '@';

            lengthFilledHealthBar = СountFilling(lengthBar, healthBar);
            lengthFilledManaBar = СountFilling(lengthBar, manaBar);
            DrawBar(lengthBar, lengthFilledHealthBar, simbolHealth, positionHealthBar);
            DrawBar(lengthBar, lengthFilledManaBar, simbolMana, positionManaBar);
        }

        static void DrawBar(int lengthBar, int lengthFilledBar, char filledBar,int position=0)
        {
            char openBar = '[';
            char closeBar = ']';
            char nullBar = '_';            

            char[] bar = new char[lengthBar];

            Console.SetCursorPosition(0, position);
            Console.Write($"{openBar}");
            FillBar(bar,0, lengthFilledBar, filledBar);
            FillBar(bar, lengthFilledBar, lengthBar, nullBar);
            Console.Write($"{closeBar}");
        }

        static char[] FillBar(char[] simbols,int startPosition , int leanghtFill, char simbol)
        {
            for (int i = startPosition; i < leanghtFill; i++)
            {
                simbols[i] = simbol;
                Console.Write($"{simbols[i]}");
            }

            return simbols;
        }

        static int СountFilling(int lengthBar, string nameBar)
        {
            int lowerLimitRangeNumbers = 0;
            int upperLimitRangeNumbers = 100;
            Console.WriteLine($"Введите на какой % заполнен бар {nameBar}");

            int userInput = Utilite.GetNumber(lowerLimitRangeNumbers, upperLimitRangeNumbers);
            double number = (lengthBar * userInput/upperLimitRangeNumbers);
            int lengthFilledBar =Convert.ToInt32(Math.Truncate(number));

            return lengthFilledBar;
        }
    }

    class Utilite
    {
        public static int GetNumber(int lowerLimitRangeNumbers = Int32.MinValue, int upperLimitRangeNumbers = Int32.MaxValue)
        {
            bool isEnterNumber = true;
            int enterNumber = 0;
            string userInput;

            while (isEnterNumber)
            {
                Console.WriteLine($"Введите число.");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out enterNumber) == false)
                    Console.WriteLine("Не корректный ввод.");
                else if (GetNumberInRange(enterNumber, lowerLimitRangeNumbers, upperLimitRangeNumbers))
                    isEnterNumber = false;
            }

            return enterNumber;
        }

        private static bool GetNumberInRange(int number, int lowerLimitRangeNumbers, int upperLimitRangeNumbers)
        {
            if (number < lowerLimitRangeNumbers)
            {
                Console.WriteLine($"Число вышло за нижний предел допустимого значения.");
                return false;
            }
            else if (number > upperLimitRangeNumbers)
            {
                Console.WriteLine($"Число вышло за верхний предел допустимого значения.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
