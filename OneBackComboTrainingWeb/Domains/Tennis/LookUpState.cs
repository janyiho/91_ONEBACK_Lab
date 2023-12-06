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
        if (_tennisBox.GetFirstPlayerScore()==2)
        {
            return $"{_scoreMapping[_tennisBox.GetFirstPlayerScore()]} love";
        }

        return $"{_scoreMapping[_tennisBox.GetFirstPlayerScore()]} love";
    }
}