namespace Hangman.Utils;

class InputValidator 
{
	private string word;
	private string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public InputValidator(string word)
	{
		this.word = word;
	}

	// returns a response code

	/** 
	 * error code
	 * 1 -> empty input
	 * 2 -> letter already guessed
	 * 3 -> contains symbols
	 * 4 -> not a letter
	 * 5 -> wrong letter
	 * 
	 * success codes
	 * 10 -> correct letter
	*/
	public int validate(string? input)
	{
		if (String.IsNullOrWhiteSpace(input)) {
			return 1;
		}
		else if (
			Letters.WrongLetters.Contains(input) ||
			Letters.GuessedLetters.Contains(input)
		) {
			return 2;
		}
		else if (input.Length >= 2) {
			return 3;
		}
		else if (!this.letters.Contains(input)) {
			return 4;
		}
		else if (!this.word.Contains(input)) {
			Letters.WrongLetters.Add(input.ToLower());
			Scores.score -= 50;
			Scores.lives -= 1;
			return 5;
		}
		else if (this.word.Contains(input)) {
			Controllers.AddLetterToGuessed(Letters.GuessedLetters, this.word, input);
			Scores.score += 100;
			return 10;
		}
		else {
			return 0; // nothing happens
		}
	}
	// returns error message from a specific errorcode
	public string error(int errorCode)
	{
		switch (errorCode)
		{
			case 1:
				return "Letter cannot be empty.";
			case 2:
				return "Letter already guessed.";	
			case 3:
				return "Not a word.";
			case 4:
				return "Cannot be a special character.";
			case 5:
				return "Wrong letter.";
			default:
				return "";
		}
	}
	
	public string success(int successCode)
	{
		switch (successCode) 
		{
			case 10:
				return "Letter guessed!";
			default:
				return "";
		}
	}
}
