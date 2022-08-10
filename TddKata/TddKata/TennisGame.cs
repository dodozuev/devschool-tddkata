﻿namespace TddKata;

public class TennisGame
{
    public Player Player1 = new Player();
    public Player Player2 = new Player();

    public Player GetWinner()
    {
        var players = new[] {Player1, Player2};

        var highestScore = players.Max(p => p.Points);
        var playerWithHighestScore = players.First(p => p.Points == highestScore);
        return playerWithHighestScore;
    }
}