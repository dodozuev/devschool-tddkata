using System;
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

    [Test]
    public void WhenTryGuessing_AndGuessIsNotWord_ShouldThrow()
    {
        var sut = new Hangman("testWord");

        Assert.Throws<ArgumentException>(() => sut.Guess('2'));
    }

    [Test]
    public void WhenTryGuessing_AddWordToGuesses()
    {
        var sut = new Hangman("testWord");

        var guess = 'z';
        sut.Guess(guess);

        sut.Guesses.Keys.Should().Contain(Char.ToUpper(guess));
    }

    [Test]
    public void WhenTryGuessingTwiceSame_ShouldIncreaseIncorrectGuessesOnlyOnce()
    {
        var sut = new Hangman("testWord");

        var guess = 'z';
        sut.Guess(guess);
        sut.Guess(guess);

        sut.IncorrectGuesses.Should().Be(1);
    }

    [Test]
    public void WhenTryGuessingTwiceSame_ShouldAddOnlyOneGuessToGuesses()
    {
        var sut = new Hangman("testWord");

        var guess = 't';
        sut.Guess(guess);
        sut.Guess(guess);

        sut.Guesses.Keys.Count.Should().Be(1);
    }

    [Test]
    public void WhenGuessedWrong_ShouldReturnFalse()
    {
        var sut = new Hangman("testWord");

        var guess = 'z';

        sut.Guess(guess).Should().BeFalse();
    }

    [Test]
    public void WhenGuessedRight_ShouldReturnTrue()
    {
        var sut = new Hangman("testWord");

        var guess = 'z';

        sut.Guess(guess).Should().BeTrue();
    }
}