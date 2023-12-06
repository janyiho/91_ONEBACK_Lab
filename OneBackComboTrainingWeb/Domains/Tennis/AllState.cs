namespace OneBackComboTrainingWeb.Domains.Tennis;

public class AllState : StateBase
{
    public AllState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override string GetScore()
    {
        return $"{_scoreMapping[_tennisBox.GetFirstPlayerScore()]} all";    }
}