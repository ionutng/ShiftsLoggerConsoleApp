using Spectre.Console;
using System.ComponentModel.DataAnnotations;

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
        DateTime startShift = new(startDate, startTime);
        DateTime endShift = new(endDate, endTime);
        var duration = endShift - startShift;

        var shift = new Shift
        {
            FirstName = firstName,
            LastName = lastName,
            StartDate = startDate,
            EndDate = endDate,
            StartTime = startTime,
            EndTime = endTime,
            Duration = duration
        };

        return shift;
    }

    internal static Shift UpdateShift(Shift shift)
    {
        shift.FirstName = AnsiConsole.Confirm("Update first name?")
            ? AnsiConsole.Ask<string>("First Name:")
            : shift.FirstName;

        shift.LastName = AnsiConsole.Confirm("Update last name?")
            ? AnsiConsole.Ask<string>("Last Name:")
            : shift.LastName;
        
        if (AnsiConsole.Confirm("Update start date?"))
            shift.StartDate = AnsiConsole.Ask<DateOnly>("Start Date (Format: yyyy-MM-dd):");

        if (AnsiConsole.Confirm("Update end date?"))
            shift.EndDate = AnsiConsole.Ask<DateOnly>("End Date (Format: yyyy-MM-dd):");

        if (AnsiConsole.Confirm("Update start time?"))
            shift.StartTime = AnsiConsole.Ask<TimeOnly>("Start Time (Format: HH:mm):");

        if (AnsiConsole.Confirm("Update end time?"))
            shift.EndTime = AnsiConsole.Ask<TimeOnly>("End Time (Format: HH:mm):");

        shift.Duration = shift.EndTime - shift.StartTime;

        return shift;
    }
}
