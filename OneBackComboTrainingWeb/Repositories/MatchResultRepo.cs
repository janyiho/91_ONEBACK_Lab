namespace OneBackComboTrainingWeb.Repositories;

public interface IMatchResultRepo
{
    string GetMatchResult(int matchId);
    void UpdateMatchResult(int matchId, string dataString);
}

public class MatchResultRepo : IMatchResultRepo
{
    private readonly Dictionary<int, string> _db = new Dictionary<int, string>();
    public string GetMatchResult(int matchId)
    {
        return _db.GetValueOrDefault(matchId, "");
    }

    public void UpdateMatchResult(int matchId, string dataString)
    {
        if (_db.ContainsKey(matchId))
        {
            _db[matchId] = dataString;
        }
        else
        {
            _db.Add(matchId,dataString);
        }
    }
}