namespace Test
{
    using System;
    using System.Text.RegularExpressions;

    public static class Class
    {
      public static void Main()
        {
            string pattern = @"^([0-9]|10)$";
            Regex regex = new Regex(pattern);
            string num, num2;
            int n1, n2;
            int[,] numbers;
            int _new;
            int display;
            IEnumerable<int> _QueryOrderAsc;
            IEnumerable<int> _QueryOrderDes;
            int[] _QuerySelector;
            string order;

            Color("How many tables do you want to create? ");
            n1 = regex.IsMatch(num = Console.ReadLine()) ? int.Parse(num) : 1;
            Color("How many numbers per table do you want to enter? ");
            n2 = regex.IsMatch(num2 = Console.ReadLine()) ? int.Parse(num2) : 1;
            numbers = new int[n1, n2];
            Beep();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                Color($"Table #{i + 1}\n\n");
                for(int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write("Enter the {0}{1} number : ", _new = j + 1, _new == 1 ? "st" : _new == 2 ? "nd" : _new == 3 ? "rd" : "th");
                    numbers[i, j] = int.Parse(Console.ReadLine());
                }
               Beep();
            }

            do
            {
                Color("Which table do you wish to display? ");
                display = int.Parse(Console.ReadLine());
                Color("\nHow do you wish to display it? (Asc/Des) : ");
                order = Console.ReadLine();
                _QuerySelector = new int[numbers.GetLength(1)];
                Beep();

                for (int k = 0; k < numbers.GetLength(1); k++)
                {
                    _QuerySelector[k] = numbers[display - 1, k];
                }

                Func<IEnumerable<int>> x = () => _QueryOrderAsc =
                from y in _QuerySelector
                orderby y ascending
                select y;

                Func<IEnumerable<int>> y = () => _QueryOrderDes =
                from y in _QuerySelector
                orderby y descending
                select y;

                Console.WriteLine("{0}", order == "Asc" || order == "asc" ? String.Join("\n", x()) : order == "Des" || order == "des" ? String.Join("\n", y()) : "Invalid input");
                Color("\n\n\tPress ENTER to continue");
                Console.ReadLine();
                Beep();
            } while (true);
        }

        public static void Color(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input);
            Console.ResetColor();
        }

        public static void Beep()
        {
            Console.Clear();
            Console.Beep();
        }
    }
}
