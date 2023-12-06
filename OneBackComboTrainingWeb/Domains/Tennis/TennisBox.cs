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
        _currentState = new LookUpState(this);
    }

    public void SecondPlayerGoal()
    {
        _secondPlayerSocre++;
        _currentState = new AllState(this);
    }

    public int GetFirstPlayerScore()
    {
        return _firstPlayerScore;
    }
}