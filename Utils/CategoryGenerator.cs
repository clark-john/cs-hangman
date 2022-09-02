namespace Hangman.Utils;

static class HangmanCategories 
{
	public static string[] urls = {
		// anything that starts with wordlists/master/nouns
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/food.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/architecture.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/buildings.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/condiments.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/screenwriting.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/storage.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/music_instruments.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/coding.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/data_structures.txt",
		"https://raw.githubusercontent.com/imsky/wordlists/master/nouns/design.txt",
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
