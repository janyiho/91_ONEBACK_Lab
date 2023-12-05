using OneBackComboTrainingWeb;

namespace OneBackTests;

public class HolidayTests
{
    private HolidayForTest _holiday;
    
    

    private void ThemeShouldBe(string expected)
    {
        Assert.That(expected, Is.EqualTo(_holiday.GetTheme()));                                                                         
    }

    [Test]
    public void IsTodayXmas()
    {
        GivenToday(12, 25);
        ThemeShouldBe("Merry Xmas");
    }

    [Test]
    public void IsTodayNotXmas()
    {
        GivenToday(11, 25);
        ThemeShouldBe("Today is not Xmas");
    }

    private void GivenToday(int month, int day)
    {
        _holiday.Today = new DateTime(2023, month, day);
    }

    public class HolidayForTest : Holiday
    {
        private DateTime _today;

        public DateTime Today
        {
            set => _today = value;
        }

        public override DateTime GetToday()
        {
            return _today;
        }
    }
}