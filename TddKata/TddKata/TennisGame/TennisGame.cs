namespace TddKata;

public class TennisGame
{
    public readonly Player Player1 = new Player();
    public readonly Player Player2 = new Player();
    public Player? Winner = null;
    public void ScorePlayer(Player player)
    {
        if (player.Points < 30)
            player.Points += 15;
        else
            player.Points += 10;

        Winner ??= GetWinner();
    }

    private Player? GetWinner()
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