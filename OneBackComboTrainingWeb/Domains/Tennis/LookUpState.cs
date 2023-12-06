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
            GoAllState();
        }
        else
        {
            GoLookUp();
        }
    }
}