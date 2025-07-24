using System;

[Serializable]
public class GameData
{
    public float finalScore;
    public float finalTime;

    public GameData()
    {
        finalScore = 0;
        finalTime = 0;
    }
}
