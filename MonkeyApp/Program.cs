
using MyMonkeyApp;

/// <summary>
/// Main entry point for the MonkeyApp console application.
/// </summary>
class Program
{
	static void Main()
	{
		while (true)
		{
			Console.WriteLine("\n=== MonkeyApp Menu ===");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Show details for a monkey");
			Console.WriteLine("3. Pick a random monkey");
			Console.WriteLine("4. Exit");
			Console.Write("Select an option (1-4): ");

			var userInput = Console.ReadLine();
			Console.WriteLine();

			switch (userInput)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					ShowMonkeyDetails();
					break;
				case "3":
					ShowRandomMonkey();
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Please try again.");
					break;
			}
		}
	}

	/// <summary>
	/// Lists all monkeys.
	/// </summary>
	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		if (monkeys.Count == 0)
		{
			Console.WriteLine("No monkeys found.");
			return;
		}

		// Table header
		Console.WriteLine("{0,-25} | {1,10} | {2,-30}", "Name", "Population", "Location");
		Console.WriteLine(new string('-', 70));

		// Table rows
		foreach (var monkey in monkeys)
		{
			Console.WriteLine("{0,-25} | {1,10:N0} | {2,-30}", monkey.Name, monkey.Population, monkey.Location);
		}
	}

	/// <summary>
	/// Shows details for a selected monkey.
	/// </summary>
	static void ShowMonkeyDetails()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
		if (monkey is not null)
		{
			Console.WriteLine($"Name: {monkey.Name}");
			Console.WriteLine($"Location: {monkey.Location}");
			Console.WriteLine($"Population: {monkey.Population}");
		}
		else
		{
			Console.WriteLine("Monkey not found.");
		}
	}

	/// <summary>
	/// Shows a random monkey.
	/// </summary>
	static void ShowRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		Console.WriteLine("Random Monkey:");
		Console.WriteLine($"Name: {monkey.Name}");
		Console.WriteLine($"Location: {monkey.Location}");
		Console.WriteLine($"Population: {monkey.Population}");
	}
}
