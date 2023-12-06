using OneBackComboTrainingWeb.Domains.Tennis;

namespace OneBackTests;

public class TennisBoxTests
{
    private TennisBox _tennisBox = null;

    [SetUp]
    public void SetUp()
    {
        _tennisBox = new TennisBox($"Eva", $"Eric");
    }

    [Test]
    public void love_all()
    {
        ScoreShouldBe("love all");
    }

    [Test(Description = "all to lookup")]
    public void fifteen_love()
    {
        GiveFirstPlayerScore(1);
        ScoreShouldBe("fifteen love");
    }

    [Test(Description = "lookup to lookup")]
    public void thirty_love()
    {
        GiveFirstPlayerScore(2);
        ScoreShouldBe("thirty love");
    }

    [Test(Description = "lookup to all")]
    public void fifteen_all()
    {
        GiveFirstPlayerScore(1);
        GiveSecondPlayerScore(1);
        ScoreShouldBe("fifteen all");
    }

    [Test(Description = "all to lookup")]
    public void fifteen_thirty()
    {
        GiveFirstPlayerScore(1);
        GiveSecondPlayerScore(1);
        WhenScondPlayerGoal();
        ScoreShouldBe("fifteen thirty");
    }

    [Test(Description = "lookup to deuce")]
    public void deuce()
    {
        GiveFirstPlayerScore(3);
        GiveSecondPlayerScore(2);
        WhenScondPlayerGoal();
        ScoreShouldBe("deuce");
    }

    [Test(Description = "deuce to adv")]
    public void first_player_adv()
    {
        GiveDeuce();
        WhenFirstPlayerGoal();
        ScoreShouldBe("Eva adv");
    }

    [Test(Description = "adv to deuce")]
    public void adv_to_deuce()
    {
        GiveFirstPlayerScore(3);
        GiveSecondPlayerScore(4);
        WhenFirstPlayerGoal();
        ScoreShouldBe("deuce");
    }

    [Test(Description = "adv to win")]
    public void avd_to_win()
    {
        GiveFirstPlayerScore(3);
        GiveSecondPlayerScore(4);
        WhenScondPlayerGoal();
        ScoreShouldBe("Eric win");
    }

    [Test(Description = "lookup to win")]
    public void lookup_to_win()
    {
        GiveFirstPlayerScore(1);
        GiveSecondPlayerScore(3);
        WhenScondPlayerGoal();
        ScoreShouldBe("Eric win");
    }

    private void WhenFirstPlayerGoal()
    {
        _tennisBox.FirstPlayerGoal();
    }

    private void GiveDeuce()
    {
        GiveFirstPlayerScore(3);
        GiveSecondPlayerScore(3);
    }


    private void WhenScondPlayerGoal()
    {
        _tennisBox.SecondPlayerGoal();
    }

    private void GiveSecondPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisBox.SecondPlayerGoal();
        }
    }

    private void GiveFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisBox.FirstPlayerGoal();
        }
    }

    [Test]
    public void forty_love()
    {
        _tennisBox.FirstPlayerGoal();
        _tennisBox.FirstPlayerGoal();
        _tennisBox.FirstPlayerGoal();
        ScoreShouldBe("forty love");
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.AreEqual(expected, _tennisBox.Score());
    }
}