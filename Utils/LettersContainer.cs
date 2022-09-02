namespace Hangman.Utils;

static class Letters
{
	// public static 
	public static List<string> WrongLetters = new List<string>();
	public static List<string> GuessedLetters = new List<string>();
}
class LettersContainer
{
	private string word;

	public LettersContainer(string word)
	{
		this.word = word;
		for (int x = 0; x < this.word.Length; x++)
		{
			Letters.GuessedLetters.Add(" ");
		}
	}

	public bool All(List<string> list)
	{
		// returns false if it contains spaces
		foreach (string x in list)
		{
			if (x == " ")
			{
				return false;
			}
		}	
		return true;
	}

	public void DisplayContainer()
	{
		foreach (string x in Letters.GuessedLetters)
		{
			Console.Write(x + " ");
		}			
		Console.Write('\n');
		for (int x = 0; x < this.word.Length; x++) {
			Console.Write("_ ");
		}
		Console.Write('\n');
	}
}
