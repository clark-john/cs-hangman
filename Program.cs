using Hangman.Utils;

namespace Hangman; 

internal class Program 
{
	async static Task Main(string[] args)
	{
		Game g = new Game();
		await g.Start();
	}
}

// made with just Sublime