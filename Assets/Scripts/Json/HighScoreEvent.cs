using Unity.Services.Analytics;

public class HighScoreEvent : Event
{
    public HighScoreEvent() : base("Bridge_Jumpers_HighScoreReport")
    {
        
    }
    
    public int Score { set { SetParameter("HighScore_Score", value); } }
    public string Character { set { SetParameter("HighScore_Character", value); } }
}
