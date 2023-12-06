namespace OneBackComboTrainingWeb.Domains.Tennis;

public abstract class StateBase
{
    protected Dictionary<int, string> _scoreMapping = new Dictionary<int, string>()
    {
        { 0, "love" },
        { 1, "fifteen" },
        { 2, "thirty" },
        { 3, "forty" },
    };

    protected TennisBox _tennisBox;

    public StateBase(TennisBox tennisBox)
    {
        _tennisBox = tennisBox;
    }

    public abstract string GetScore();
    public abstract void Next();

    protected void GoLookUp()
    {
        _tennisBox.SetState(new LookUpState(_tennisBox));
    }

    protected void GoAllState()
    {
        _tennisBox.SetState(new AllState(_tennisBox));
    }

    protected void GoDeuce()
    {
        _tennisBox.SetState(new DeuceState(_tennisBox));
    }

    protected void GoAdv()
    {
        _tennisBox.SetState(new AdvState(_tennisBox));
    }

    protected void GoWin()
    {
        _tennisBox.SetState(new WinState(_tennisBox));
    }
}

public class WinState : StateBase
{
    public WinState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override string GetScore()
    {
        return $"{_tennisBox.GetAdvPlayer()} win";
    }

    public override void Next()
    {
        
    }
}