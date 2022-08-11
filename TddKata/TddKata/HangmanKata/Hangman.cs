namespace TddKata.HangmanKata;

public class Hangman
{
    public string Word { get; }
    public int IncorrectGuesses { get; private set; }
    public Dictionary<char, bool> Guesses { get; private set; }

    public State CurrentState {
        get
        {
            if (!Word.Except(Guesses.Keys.ToArray()).Any())
                return State.Won;
            if (IncorrectGuesses >= _maxGuessCount)
                return State.Lost;
            return State.InProgress;
        }
    }

    private readonly int _maxGuessCount;

    public Hangman(string word, int maxGuessCount)
    {
        Word = word.ToUpper();
        _maxGuessCount = maxGuessCount;
        Guesses = new Dictionary<char, bool>();
    }

    public bool Guess(char character)
    {
        var upperCharacter = Char.ToUpper(character);

        if (Guesses.ContainsKey(upperCharacter))
            return Guesses[upperCharacter];


        ValidateCharacter(upperCharacter);
        if (!Word.Contains(upperCharacter))
        {
            Guesses.Add(upperCharacter, false);
            IncorrectGuesses++;
        }
        else
        {
            Guesses.Add(upperCharacter, true);
        }

        return Guesses[upperCharacter];
    }

    public enum State
    {
        Undefined=0,
        InProgress=1,
        Lost=2,
        Won=3
    }

    private void ValidateCharacter(char character)
    {
        if (character < 'A' || character > 'Z')
            throw new ArgumentException();
    }
}