using Hangman.Utils;
using Hangman.PluginsManager;

namespace Hangman;

static class Scores
{
	public static int score = 0;
	public static int lives = 10;
}

static class ConsoleUtils
{
	public static void WriteColor(
			string str, 
			ConsoleColor color, 
			bool noNewLine = false
		)
	{
		Console.ForegroundColor = color;
		if (noNewLine) {
			Console.Write(str);
		} else {
			Console.WriteLine(str);
		}
		Console.ResetColor();
	}
}

sealed class Game
{
	private void BeforeStart()
	{
		Manager man = new();
		List<string> plugins = man.GetPluginsFromDirectory("./plugins");
		man.LoadAllPlugins(plugins);
	}
	async public Task Start()
	{
		BeforeStart();
		Console.WriteLine("Hangman v1.0.0");

		CategoryGenerator cg = new CategoryGenerator();
		WordGenerator wg = new WordGenerator();

		string category = cg.GetCategory();
		string word = await wg.Generate(category);
		
		InputValidator v = new InputValidator(word);
		LettersContainer container = new LettersContainer(word);

		while (true) 
		{
			ConsoleUtils.WriteColor("|  W O R D  |", ConsoleColor.Green, true);

			// appear wrong letters list if the user enters a wrong letter for the first time
			if (Letters.WrongLetters.Count != 0)
			{
				Console.Write(" Wrong letters: ");
				foreach (string x in Letters.WrongLetters)
				{
					ConsoleUtils.WriteColor($"{x} ", ConsoleColor.Red, true);
				}
			}
			Console.WriteLine($"\nCategory: {category}");

			container.DisplayContainer();
			Console.Write("Input => ");

			// when the game finished
			if (container.All(Letters.GuessedLetters)) 
			{ 
				ConsoleUtils.WriteColor("\nComplete!", ConsoleColor.Green);
				int BonusPoints = Scores.lives * 100;
				Console.WriteLine($"Score: {Scores.score + BonusPoints}");
				Console.WriteLine($"Lives: {Scores.lives} (+{BonusPoints} points)");
				break; 
			}
			
			// if no lives
			if (Scores.lives == 0)
			{
				Console.WriteLine("You lose!");
				Console.WriteLine($"Answer: {word}");
				break;
			}

			// input
			string? input = Console.ReadLine();
			
			// exit or giveup mystery words
			if (input == "exit") {
				Console.WriteLine("Are you sure? (y/n)");
				if (Console.ReadKey().Key == ConsoleKey.Y) {
					break; 
				} else {
					continue;
				}
			} else if (input == "giveup") {
				Console.WriteLine("Are you sure? (y/n)");
				if (Console.ReadKey().Key == ConsoleKey.Y) {
					Console.WriteLine("You lose!");
					Console.WriteLine($"Answer: {word}");
					break; 
				} else {
					continue;
				}
			} 

			// validation
			int ResponseCode = v.validate(input);
			if (ResponseCode <= 9 && ResponseCode > 0) {
				if (ResponseCode == 5) {
					ConsoleUtils.WriteColor(v.error(ResponseCode), ConsoleColor.Red);
					Console.WriteLine($"Lives remaining: {Scores.lives}");
				} else {
					ConsoleUtils.WriteColor(v.error(ResponseCode), ConsoleColor.Yellow);
				}
			} else {
				Console.WriteLine(v.success(ResponseCode));
			}
		}
	}
}
