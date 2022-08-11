namespace TddKata.HangmanKata;

public class Hangman
{
    public string Word { get; }
    public int IncorrectGuesses { get; private set; }

    public State CurrentState = State.InProgress;

    public Hangman(string word)
    {
        Word = word.ToUpper();
    }

    public void Guess(char character)
    {
        var upperCharacter = Char.ToUpper(character);
        ValidateCharacter(upperCharacter);
        if (!Word.Contains(upperCharacter))
            IncorrectGuesses++;
    }

    public enum State
    {
        Undefined=0,
        InProgress=1,
    }

    private void ValidateCharacter(char character)
    {
        if (character < 'A' || character > 'Z')
            throw new ArgumentException();
    }
}