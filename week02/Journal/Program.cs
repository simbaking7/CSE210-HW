

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Show statistics");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        journal.SaveToFile(saveFile);
                        Console.WriteLine("Journal saved successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename. Save cancelled.");
                    }
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile) && File.Exists(loadFile))
                    {
                        journal.LoadFromFile(loadFile);
                        Console.WriteLine("Journal loaded successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename or file not found. Load cancelled.");
                    }
                    break;
                case "5":
                    journal.ShowStatistics();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-6.");
                    break;
            }
        }
    }
}