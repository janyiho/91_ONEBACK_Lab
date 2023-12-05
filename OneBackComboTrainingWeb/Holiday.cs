namespace OneBackComboTrainingWeb;

public class Holiday
{
    public string GetTheme()
    {
        var dateTime = GetToday();
        if (dateTime.Month == 12 && dateTime.Day == 25)
        {
            return "Merry Xmas";
        }

        return "Today is not Xmas";
    }

    public virtual DateTime GetToday()
    {
        return DateTime.Now;
    }
}