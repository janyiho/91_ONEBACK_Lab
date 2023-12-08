using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Exceptions;

namespace OneBackComboTrainingWeb.Models;

public class MatchResultModel
{
    public MatchResultModel(string matchResult, int matchid)
    {
        MatchId = matchid; 
        OriginalData = matchResult;
    }
    public int MatchId { get; set; }
    private int HomeScore => OriginalData.Count(c => c == 'H');
    private int AwayScore => OriginalData.Count(c => c == 'A');
    private bool IsSecondPeriod =>OriginalData.Any(c => c == ';');
    public string OriginalData;

    public string GetDisplayScore()
    {
        return $"{HomeScore}:{AwayScore} ({(IsSecondPeriod ? "Second Half" : "First Half")})";
    }

    private bool CheckLastChar(char lastChar)
    {
        return this.OriginalData.Length > 0 && this.OriginalData.EndsWith(lastChar);
    }

    private bool CheckSecondLastChar(char lastChar)
    {
        return this.OriginalData.Length >= 2 && this.OriginalData.ToCharArray()[this.OriginalData.Length-2] == lastChar;
    }

    private void RemoveSecondLastChar()
    {
        this.OriginalData = this.OriginalData.Remove(this.OriginalData.Length - 2, 1);
    }

    private void RemoveLastChar()
    {
        this.OriginalData = this.OriginalData.Remove(this.OriginalData.Length - 1);
    }

    private void CancelScore(char @char)
    {
        if (CheckLastChar(@char))
        {
            RemoveLastChar();
        }
        else if (CheckLastChar(';'))
        {
            if (CheckSecondLastChar(@char))
            {
                RemoveSecondLastChar();
            }
            else
            {
                throw new FailEventException("not allow");
            }
        }
        else
        {
            throw new FailEventException("not allow");
        }
    }

    private void NextPeriod()
    {
        OriginalData += ";";
    }

    private void AwayGoal()
    {
        OriginalData += "A";
    }

    private void HomeGoal()
    {
        OriginalData += "H";
    }

    public void HandleEvent(MatchEvent @event)
    {
        switch (@event)
        {
            case MatchEvent.HomeGoal:
                HomeGoal();
                break;
            case MatchEvent.AwayGoal:
                AwayGoal();
                break;
            case MatchEvent.HomeCancel:
                CancelScore('H');
                break;
            case MatchEvent.AwayCancel:
                CancelScore('A');
                break;
            case MatchEvent.NextPeriod:
                NextPeriod();
                break;
        }
    }
}