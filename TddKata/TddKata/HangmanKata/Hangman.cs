namespace TddKata.HangmanKata;

public class Hangman
{
    public string Word { get; }
    public int IncorrectGuesses { get; } = 0;

    public State CurrentState = State.InProgress;

    public Hangman(string word)
    {
        Word = word.ToUpper();
    }

    public enum State
    {
        Undefined=0,
        InProgress=1,
    }
}