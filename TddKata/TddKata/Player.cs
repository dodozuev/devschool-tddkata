namespace TddKata;

public class Player
{
    public void Score()
    {
        if (Points < 30)
            Points += 15;
        else
            Points += 10;
    }

    public int Points = 0;
}