using Spectre.Console;

namespace ShiftsLoggerConsoleApp;

internal class ShiftsHelper
{
    internal static string GetShiftId()
    {
        ShiftsService.GetShifts();
        string shiftId = AnsiConsole.Ask<string>("Shift's id:");

        return shiftId;
    }

    internal static Shift GetShiftInput()
    {
        string firstName = AnsiConsole.Ask<string>("First Name:");
        string lastName = AnsiConsole.Ask<string>("Last Name:");
        DateOnly startDate = AnsiConsole.Ask<DateOnly>("Start Date (Format: yyyy-MM-dd):");
        DateOnly endDate = AnsiConsole.Ask<DateOnly>("End Date (Format: yyyy-MM-dd):");
        TimeOnly startTime = AnsiConsole.Ask<TimeOnly>("Start Time (Format: HH:mm):");
        TimeOnly endTime = AnsiConsole.Ask<TimeOnly>("End Time (Format: HH:mm):");

        var shift = new Shift
        {
            FirstName = firstName,
            LastName = lastName,
            StartDate = startDate,
            EndDate = endDate,
            StartTime = startTime,
            EndTime = endTime
        };

        return shift;
    }
}
