namespace OneBackComboTrainingWeb.Domains.Tennis;

public class LookUpState : StateBase
{
    private readonly TennisBox _tennisBox;

    public LookUpState(TennisBox tennisBox) : base(tennisBox)
    {
        _tennisBox = tennisBox;
    }

    public override string GetScore()
    {
        return $"{_scoreMapping[_tennisBox.GetFirstPlayerScore()]} {_scoreMapping[_tennisBox.GetSecodPlayerScore()]}";
    }

    public override void Next()
    {
        if (_tennisBox.GetFirstPlayerScore() == _tennisBox.GetSecodPlayerScore())
        {
            if (_tennisBox.GetFirstPlayerScore() >= 3)
            {
                GoDeuce();
            }
            else
            {
                GoAllState();
            }
        }
        else
        {
            if (_tennisBox.GetFirstPlayerScore() >= 4 || _tennisBox.GetSecodPlayerScore() >= 4)
            {
                GoWin();
            }
            else
            {
                GoLookUp();
            }
        }
    }
}