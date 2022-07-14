namespace Hangman.Utils;

sealed class SnakeToTitle 
{
	private string Capitalize(string word)
	{
		return Char.ToUpper(word[0]) + word.Substring(1); 
	}
	public string SnakeToTitleCase(string input)
	{
		string[] split = input.Split('_', ' ');
		for (int x = 0; x < split.Length; x++) 
		{
			split[x] = this.Capitalize(split[x]); 
		}
		return String.Join(" ", split);
	}
}
