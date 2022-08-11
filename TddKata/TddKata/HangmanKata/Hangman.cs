namespace TddKata.HangmanKata;

public class Hangman
{
    public string Word { get; }

    public Hangman(string word)
    {
        Word = word.ToUpper();
    }
}