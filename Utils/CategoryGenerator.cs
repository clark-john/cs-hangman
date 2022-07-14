namespace Hangman.Utils;

static class HangmanCategories 
{
	public static string[] urls = {
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/food.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/music_instruments.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/coding.txt"
	};
}	
class CategoryGenerator
{
	public string GetCategory()
	{	
		string[] urls = HangmanCategories.urls;
		List<string> categories = new WordFetcher().GetCategories(urls);
		return categories[new Random().Next(categories.Count)];
	}
}
