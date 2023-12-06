namespace OneBackComboTrainingWeb.Domains.Tennis;

public class TennisBox
{
    private StateBase _currentState;
    private int _firstPlayerScore;
    private int _secondPlayerSocre;
    private string _firstPlayerName;
    private string _secondPlayerName;

    public TennisBox(string firstPlayerName, string secondPlayerName)
    {
        _currentState = new AllState(this);
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
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

    public string GetFirstPlayerName()
    {
        return _firstPlayerName;
    }

    public string GetSecondPlayerName()
    {
        return _secondPlayerName;
    }

    public string GetAdvPlayer()
    {
        return _firstPlayerScore > _secondPlayerSocre ? _firstPlayerName : _secondPlayerName;                                                                            
    }
}