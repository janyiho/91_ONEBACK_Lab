namespace OneBackComboTrainingWeb.Domains.Tennis;

public class TennisBox
{
    private StateBase _currentState;
    private int _firstPlayerScore;
    private int _secondPlayerSocre;

    public TennisBox()
    {
        _currentState = new AllState(this);
    }

    public string Score()
    {
        return _currentState.GetScore();
    }

    public void FirstPlayerGoal()
    {
        _firstPlayerScore++;
        _currentState.Next();
    }

    public void SecondPlayerGoal()
    {
        _secondPlayerSocre++;
        _currentState.Next();
    }

    public int GetFirstPlayerScore()
    {
        return _firstPlayerScore;
    }

    public int GetSecodPlayerScore()
    {
        return _secondPlayerSocre;
    }

    public void SetState(StateBase allState)
    {
        _currentState = allState;
    }
}