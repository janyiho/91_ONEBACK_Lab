namespace OneBackComboTrainingWeb.Domains.Tennis;

public class DeuceState : StateBase
{
    public DeuceState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override string GetScore()
    {
        return $"deuce";
    }

    public override void Next()
    {
        GoAdv();
    }
}