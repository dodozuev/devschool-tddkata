using FluentAssertions;
using NUnit.Framework;
using TddKata.HangmanKata;

namespace TddKata.Tests;

public class HangmanTests
{
    [Test]
    public void WhenHangmanCreated_ShouldAcceptWord()
    {
        var testWord = "TESTWORD";
        var sut = new Hangman(testWord);

        sut.Word.Should().Be(testWord);
    }

    [Test]
    public void WhenHangmanCreated_ShouldStoreWordInUpperCase()
    {
        var testWord = "Testword";
        var sut = new Hangman(testWord);

        sut.Word.Should().Be(testWord.ToUpper());
    }

    [Test]
    public void WhenHangmanCreated_IncorrectGuessesShouldBeZero()
    {
        var sut = new Hangman("testWord");

        sut.IncorrectGuesses.Should().Be(0);
    }

    [Test]
    public void WhenHangmanCreated_GameIsInProgress()
    {
        var sut = new Hangman("testWord");

        sut.CurrentState.Should().Be(Hangman.State.InProgress);
    }

    [Test]
    public void WhenTryGuessing_AndGuessIsWrong_ShouldAddToGuesses()
    {
        var sut = new Hangman("testWord");

        sut.Guess('z');

        sut.IncorrectGuesses.Should().Be(1);
    }

    [Test]
    public void WhenTryGuessing_AndGuessIsRight_ShouldNotAddToGuesses()
    {
        var sut = new Hangman("testWord");

        sut.Guess('t');

        sut.IncorrectGuesses.Should().Be(0);
    }
}