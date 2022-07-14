namespace Hangman.Utils;

static class Utils
{
	public static List<int> Indices(string letter, string word)
	{
		List<int> indices = new List<int>();
		for (int x = 0; x < word.Length; x++)
		{	
			if (!indices.Contains(x))
			{
				int index = word.IndexOf(letter, x);
				if (index != -1)
				{
					indices.Add(index);
				}		
			}
		}
		List<int> RemoveDuplicates(List<int> list)
		{
			List<int> NoDuplicates = new List<int>();

			foreach (int x in list)
			{
				if (!NoDuplicates.Contains(x))
				{
					NoDuplicates.Add(x);
				}
			}
			return NoDuplicates;
		}
		return RemoveDuplicates(indices);
	}

	public static int NumberOf(string letter, string word)
	{	
		// Logic:
		// Number of letters in a word
		int count = 0;
		foreach (char x in word)
		{
			if (x == Convert.ToChar(letter))
			{
				count++;
			}
		}
		return count;
	}	
}

static class Controllers
{
	public static void AddLetterToGuessed(
			List<string> list, 
			string word, 
			string letter
		)
	{
		int LetterCount = Utils.NumberOf(letter, word);
		if (LetterCount > 1 && LetterCount != 0)
		{
			List<int> indices = Utils.Indices(letter, word);
			foreach (int x in indices)
			{
				list[x] = letter.ToLower();
			}
		}
		else
		{
			list[word.IndexOf(letter)] = letter;
		}
	}
}
