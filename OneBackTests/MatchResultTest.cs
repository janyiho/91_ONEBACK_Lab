using NSubstitute;
using OneBackComboTrainingWeb.Controllers;
using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Exceptions;
using OneBackComboTrainingWeb.Repositories;
using OneBackComboTrainingWeb.Services;

namespace OneBackTests;

public class MatchResultTest
{
    private MatchResultController _matchResultController;
    private IMatchResultRepo _matchResultRepo;
    private MatchResultService _matchResultService;

    [SetUp]
    public void SetUp()
    {
        _matchResultRepo = Substitute.For<IMatchResultRepo>();
        _matchResultService = new MatchResultService(_matchResultRepo);
        _matchResultController = new MatchResultController(_matchResultService);
    }

    [Test(Description = "zero, then HG")]
    public void home_goal()
    {
        Assert.That(_matchResultController.UpdateMatchResult(91, MatchEvent.HomeGoal), Is.EqualTo("1:0 (First Half)"));
    }
    
    [Test(Description = "HG, then AG")]
    public void away_goal_after_home_goal()
    {
        GiveCurrentResult("H");
        Assert.That(_matchResultController.UpdateMatchResult(91,MatchEvent.AwayGoal), Is.EqualTo("1:1 (First Half)"));
    }

    private void GiveCurrentResult(string returnThis)
    {
        _matchResultRepo.GetMatchResult(Arg.Any<int>()).Returns(returnThis);
    }

    [Test(Description = "zero, then NextPeriod")]
    public void switch_secondHalf()
    {
        Assert.That(_matchResultController.UpdateMatchResult(91,MatchEvent.NextPeriod), Is.EqualTo("0:0 (Second Half)"));
    }
    [Test(Description = "HG AG, then NextPeriod")]
    public void HA_secondHalf()
    {
        GiveCurrentResult("HA");
        Assert.That(_matchResultController.UpdateMatchResult(91,MatchEvent.NextPeriod), Is.EqualTo("1:1 (Second Half)"));
    }
    [Test(Description = "HG AG & NextPeriod, then HG")]
    public void HG_under_HA_secondHalf()
    {
        GiveCurrentResult("HA;");
        Assert.That(_matchResultController.UpdateMatchResult(91,MatchEvent.HomeGoal), Is.EqualTo("2:1 (Second Half)"));
    }
    [Test(Description = "HA & NextPeriod, then AC")]
    public void AC_under_HA_secondHalf()
    {
        GiveCurrentResult("HA;");
        Assert.That(_matchResultController.UpdateMatchResult(91,MatchEvent.AwayCancel), Is.EqualTo("1:0 (Second Half)"));
    }
    [Test(Description = "zero & NextPeriod, then AC")]
    public void AC_under_zero_secondHalf()
    {
        GiveCurrentResult(";");

        Assert.Throws<FailEventException>((() => { _matchResultController.UpdateMatchResult(91, MatchEvent.AwayCancel);}));
    }
    
    
}