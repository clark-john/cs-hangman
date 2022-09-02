namespace Hangman.Utils;

static class SnakeToTitle 
{
	private static string Capitalize(string word) => Char.ToUpper(word[0]) + word.Substring(1); 
	
	public static string SnakeToTitleCase(string input)
	{
		string[] split = input.Split('_', ' ');
		for (int x = 0; x < split.Length; x++) 
		{
			split[x] = Capitalize(split[x]); 
		}
		return String.Join(" ", split);
	}
}
