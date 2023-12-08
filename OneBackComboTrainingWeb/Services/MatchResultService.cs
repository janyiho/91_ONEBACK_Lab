using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Models;
using OneBackComboTrainingWeb.Repositories;

namespace OneBackComboTrainingWeb.Services;

public class MatchResultService
{
    private readonly IMatchResultRepo _matchResultRepo;

    public MatchResultService(IMatchResultRepo matchResultRepo)
    {
        _matchResultRepo = matchResultRepo;
    }

    public string UpdateMatchResult(int matchId, MatchEvent @event)
    {
        string resultFromRepo = _matchResultRepo.GetMatchResult(matchId);
        var matchResultModel = new MatchResultModel(resultFromRepo, matchId);
        matchResultModel.HandleEvent(@event);

        _matchResultRepo.UpdateMatchResult(matchId, matchResultModel.OriginalData);

        return matchResultModel.GetDisplayScore();
    }
}