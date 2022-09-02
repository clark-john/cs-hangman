using static Hangman.Utils.SnakeToTitle;

namespace Hangman.Utils;

class WordFetcher
{
	public List<string> GetCategories(string[] urls)
	{
		List<string> categories = new List<string>();

		foreach (string x in urls) {
			string f = SnakeToTitleCase((x.Substring(63)).Replace(".txt", ""));
			categories.Add(f);
		}
		return categories;
	}
	
	async private Task<List<HttpResponseMessage>> GetResponses(
			HttpClient http, 
			string[] urls
		) 
	{
		List<HttpResponseMessage> responses = new List<HttpResponseMessage>();
		for (int x = 0; x < urls.Length; x++)
		{
			responses.Add(await http.GetAsync(urls[x]));
		}
		return responses;
	}

	async public Task<Dictionary<string, string[]>> GetWords() {
		string[] urls = HangmanCategories.urls;
		List<string> categories = this.GetCategories(urls);			

		Dictionary<string, string[]> words = new Dictionary<string, string[]>();
		List<HttpResponseMessage> responses = await GetResponses(new HttpClient(), urls);
			
		for (int x = 0; x < responses.Count; x++) {
			string stringOfWords = await responses[x].Content.ReadAsStringAsync();
			words.Add(categories[x], stringOfWords.Split('\n'));				
		}
		return words;
	}
}
