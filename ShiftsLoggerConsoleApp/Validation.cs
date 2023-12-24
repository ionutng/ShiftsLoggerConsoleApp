namespace ShiftsLoggerConsoleApp;

internal static class Validation
{
    internal static bool IsIdValid(string shiftId)
    {
        if (string.IsNullOrEmpty(shiftId))
            return false;

        foreach (char character in shiftId)
            if (!char.IsDigit(character))
                return false;

        return true;
    }

    internal static bool IsNameValid(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        return true;
    }

    internal static bool IsDateValid(DateOnly date)
    {
        DateTime currentDate = DateTime.Now;

        if (string.IsNullOrEmpty(date.ToString()))
            return false;

        if (date.CompareTo(DateOnly.FromDateTime(currentDate)) == 1)
            return false;

        return true;
    }

    internal static bool IsTimeValid(TimeOnly time, DateOnly date)
    {
        DateTime currentTime = DateTime.Now;
        
        if (string.IsNullOrEmpty(time.ToString()))
            return false;

        if (time.CompareTo(TimeOnly.FromDateTime(currentTime)) == 1 && date == DateOnly.FromDateTime(DateTime.Now))
            return false;

        return true;
    }

    internal static bool AreTimesValid(TimeOnly startTime, TimeOnly endTime, DateOnly startDate, DateOnly endDate)
    {
        if (startDate == endDate && startTime > endTime)
            return false;

        return true;
    }
}
