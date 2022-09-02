namespace Hangman.Utils;

class WordGenerator
{
	async public Task<string> Generate(string hg) {
		Dictionary<string, string[]> dictionary = await new WordFetcher().GetWords();
		string[] words = dictionary[hg];
		return words[new Random().Next(words.Length)];
	}
}
