namespace OneBackComboTrainingWeb.Domains.Tennis;

public abstract class StateBase
{
    protected TennisBox _tennisBox;

    protected Dictionary<int, string> _scoreMapping = new Dictionary<int, string>()
    {
        {0,"love"},
        {1,"fifteen"},
        {2,"thirty"},
        {3,"forty"},
    };

    public StateBase(TennisBox tennisBox)
    {
        _tennisBox = tennisBox;
    }

    public abstract string GetScore();
}