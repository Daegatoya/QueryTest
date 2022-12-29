namespace Test
{
    public static class Class
    {
        public struct Student
        {
            public int[] Notes { get; set; }
            public string Name { get; set; }
        }
        public static void Main()
        {
            Student student = new Student();
            int[] notes = student.Notes;
            string name = student.Name;
            int display;
            IEnumerable<int> QueryNotes;
            int j = 0;

            Console.Write("What is the name of the student? ");
            name = Console.ReadLine();

            Console.Write("How many notes are there? ");
            notes = new int[int.Parse(Console.ReadLine())];

            for (int i = 0; i < notes.Length; i++)
            {
                Console.Write($"Enter the note #{i + 1} : ");
                notes[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("What is the minimal note you want to display? ");
            display = int.Parse(Console.ReadLine());

            Func<IEnumerable<int>> y = () => QueryNotes =
                from x in notes
                where x >= display
                orderby x ascending
                select x;

            foreach (int n in y())
            {
                j++;
            }

            Console.WriteLine($"\nHere are {name}'s notes, from {display}% : {String.Join(" ", y())}");
            Console.WriteLine($"\n{j} notes out of {notes.Length} are displayed");
        }
    }
}
