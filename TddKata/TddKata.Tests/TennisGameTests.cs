using FluentAssertions;
using NUnit.Framework;

namespace TddKata.Tests;

public class TennisGameTests
{
    [Test]
    public void WhenGameStarts_AllPlayersShouldHave0Points()
    {
        var sut = new TennisGame();

        sut.Player1.Points.Should().Be(0);
        sut.Player2.Points.Should().Be(0);
    }

    [Test]
    public void WhenPlayerScores_Adds15Points()
    {
        var game = new TennisGame();

        game.ScorePlayer(game.Player1);
        game.Player1.Points.Should().Be(15);
    }

    [Test]
    public void WhenPlayerScoresTwice_Adds30Points()
    {
        var game = new TennisGame();

        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);

        game.Player1.Points.Should().Be(30);
    }

    [Test]
    public void WhenPlayerScoresThirdTime_ScoreIs40()
    {
        var game = new TennisGame();

        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);

        game.Player1.Points.Should().Be(40);
    }

    [Test]
    public void WhenPlayer1ScoresFourTimesFromBeginning_HeWins()
    {
        var game = new TennisGame();

        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);

        game.Winner.Should().Be(game.Player1);
    }

    [Test]
    public void WhenPlayer2ScoresFourTimesFromBeginning_HeWins()
    {
        var game = new TennisGame();

        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);

        game.Winner.Should().Be(game.Player2);
    }

    [Test]
    public void WhenGameIsNotFinished_GetWinnerReturnsNull()
    {
        var game = new TennisGame();

        game.Winner.Should().Be(null);
    }


    [Test]
    public void WhenDeuce_ShouldNotReturnWinner()
    {
        var game = new TennisGame();
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);

        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);

        game.Winner.Should().Be(null);
    }

    [Test]
    public void WhenDeuce_AndOneOfPlayersScores_ShouldReturnWinner()
    {
        var game = new TennisGame();
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);

        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);

        game.Winner.Should().Be(game.Player2);
    }

    [Test]
    public void WhenAPlayerWins_ResultIsSaved()
    {
        var game = new TennisGame();

        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);
        game.ScorePlayer(game.Player2);

        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);
        game.ScorePlayer(game.Player1);

        game.Winner.Should().Be(game.Player2);
    }
}