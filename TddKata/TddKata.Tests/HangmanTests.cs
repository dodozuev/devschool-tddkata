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
}