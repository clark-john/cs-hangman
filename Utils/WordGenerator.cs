namespace Hangman.Utils;

class WordGenerator
{
	private Random r = new Random();
	private WordFetcher wf = new WordFetcher();

	async public Task<string> Generate(string hg) {
		Dictionary<string, string[]> dictionary = await wf.GetWords();
		string[] words = dictionary[hg];
		return words[new Random().Next(words.Length)];
	}
}
