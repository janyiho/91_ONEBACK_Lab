using OneBackComboTrainingWeb.Domains.Tennis;

namespace OneBackTests;

public class TennisBoxTests
{
    private TennisBox _tennisBox = null;

    [SetUp]
    public void SetUp()
    {
        _tennisBox = new TennisBox();
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