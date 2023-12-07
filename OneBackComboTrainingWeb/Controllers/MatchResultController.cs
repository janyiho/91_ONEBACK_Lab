using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Services;

namespace OneBackComboTrainingWeb.Controllers;

public class MatchResultController
{
    private readonly MatchResultService _matchResultService;

    public MatchResultController(MatchResultService matchResultService)
    {
        _matchResultService = matchResultService;
    }

    public string UpdateMatchResult(int matchId, MatchEvent @event)
    {
        return _matchResultService.UpdateMatchResult(matchId, @event);
    }
}