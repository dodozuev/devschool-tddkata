namespace TddKata;

public class TennisGame
{
    public Player Player1 = new Player();
    public Player Player2 = new Player();

    public Player? GetWinner()
    {
        var players = new[] {Player1, Player2};

        if (players.All(x => x.Points <= 40))
            return null;

        var winnerCandidate = players.OrderBy(p => p.Points).Last();
        var secondPlace = players.Except(new[] {winnerCandidate}).First();

        if (winnerCandidate.Points - secondPlace.Points >= 20)
        {
            return winnerCandidate;
        }

        return null;
    }
}