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
        var player = new Player();

        player.Score();

        player.Points.Should().Be(15);
    }

    [Test]
    public void WhenPlayerScoresTwice_Adds30Points()
    {
        var player = new Player();

        player.Score();
        player.Score();

        player.Points.Should().Be(30);
    }

    [Test]
    public void WhenPlayerScoresThirdTime_ScoreIs40()
    {
        var player = new Player();

        player.Score();
        player.Score();
        player.Score();

        player.Points.Should().Be(40);
    }

    [Test]
    public void WhenPlayer1ScoresFourTimesFromBeginning_HeWins()
    {
        var game = new TennisGame();
        game.Player1.Score();
        game.Player1.Score();
        game.Player1.Score();
        game.Player1.Score();

        game.Winner.Should().Be(game.Player1);
    }

    [Test]
    public void WhenPlayer2ScoresFourTimesFromBeginning_HeWins()
    {
        var game = new TennisGame();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();

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
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player1.Score();
        game.Player1.Score();
        game.Player1.Score();

        game.Winner.Should().Be(null);
    }

    [Test]
    public void WhenDeuce_AndOneOfPlayersGetsTwoPoints_ShouldReturnWinner()
    {
        var game = new TennisGame();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player1.Score();
        game.Player1.Score();
        game.Player1.Score();
        game.Player2.Score();

        game.Winner.Should().Be(game.Player2);
    }

    [Test]
    public void WhenAPlayerWins_ResultIsSaved()
    {
        var game = new TennisGame();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player2.Score();
        game.Player1.Score();
        game.Player1.Score();
        game.Player1.Score();

        game.Winner.Should().Be(game.Player2);
    }
}