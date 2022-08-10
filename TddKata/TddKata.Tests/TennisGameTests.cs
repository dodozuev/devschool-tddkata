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
}