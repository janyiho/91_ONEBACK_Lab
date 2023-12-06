namespace OneBackComboTrainingWeb.Domains.Tennis;

public class AdvState : StateBase
{
    public AdvState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override string GetScore()
    {
        return $"{_tennisBox.GetFirstPlayerName()} adv";
    }

    public override void Next()
    {
        if (_tennisBox.GetFirstPlayerScore()!= _tennisBox.GetSecodPlayerScore())
        {
            GoWin();
        }
        else
        {
            GoDeuce();
        }
    }
}