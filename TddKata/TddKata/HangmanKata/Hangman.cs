namespace TddKata.HangmanKata;

public class Hangman
{
    public string Word { get; }
    public int IncorrectGuesses { get; } = 0;

    public Hangman(string word)
    {
        Word = word.ToUpper();
    }
}