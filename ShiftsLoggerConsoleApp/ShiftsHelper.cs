using Spectre.Console;

namespace ShiftsLoggerConsoleApp;

internal class ShiftsHelper
{
    internal static string GetShiftId()
    {
        var shifts = ShiftsService.GetShifts();

        string shiftId = AnsiConsole.Ask<string>("Shift's id:");

        if (!Validation.IsIdValid(shiftId) || !shifts.Any(s => s.ShiftId == Convert.ToInt32(shiftId)))
        {
            Console.Clear();
            Console.WriteLine("Invalid ID!\n");
            UserInterface.Menu();
        }

        return shiftId;
    }

    internal static Shift GetShiftInput()
    {
        Console.Clear();

        string firstName = AnsiConsole.Ask<string>("First Name:");
        if (!Validation.IsNameValid(firstName))
        {
            Console.Clear();
            Console.WriteLine("Invalid name!\n");
            UserInterface.Menu();
        }
        firstName = string.Concat(firstName[0].ToString().ToUpper(), firstName[1..].ToLower());

        string lastName = AnsiConsole.Ask<string>("Last Name:");
        if (!Validation.IsNameValid(lastName))
        {
            Console.Clear();
            Console.WriteLine("Invalid name!\n");
            UserInterface.Menu();
        }
        lastName = string.Concat(lastName[0].ToString().ToUpper(), lastName[1..].ToLower());

        DateOnly startDate = AnsiConsole.Ask<DateOnly>("Start Date (Format: yyyy-MM-dd):");
        if (!Validation.IsDateValid(startDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid date!\n");
            UserInterface.Menu();
        }

        DateOnly endDate = AnsiConsole.Ask<DateOnly>("End Date (Format: yyyy-MM-dd):");
        if (!Validation.IsDateValid(endDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid date!\n");
            UserInterface.Menu();
        }

        TimeOnly startTime = AnsiConsole.Ask<TimeOnly>("Start Time (Format: HH:mm):");
        if (!Validation.IsTimeValid(startTime, startDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid time!\n");
            UserInterface.Menu();
        }

        TimeOnly endTime = AnsiConsole.Ask<TimeOnly>("End Time (Format: HH:mm):");
        if (!Validation.IsTimeValid(endTime, endDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid time!\n");
            UserInterface.Menu();
        }

        if(!Validation.AreTimesValid(startTime,endTime,startDate,endDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid time!\n");
            UserInterface.Menu();
        }

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

        Console.Clear();

        return shift;
    }

    internal static Shift UpdateShift(Shift shift)
    {
        Console.Clear();

        if (AnsiConsole.Confirm("Update first name?"))
        {
            shift.FirstName = AnsiConsole.Ask<string>("First Name:");
            if (!Validation.IsNameValid(shift.FirstName))
            {
                Console.Clear();
                Console.WriteLine("Invalid name!\n");
                UserInterface.Menu();
            }
        }

        if (AnsiConsole.Confirm("Update last name?"))
        {
            shift.LastName = AnsiConsole.Ask<string>("Last Name:");
            if (!Validation.IsNameValid(shift.LastName))
            {
                Console.Clear();
                Console.WriteLine("Invalid name!\n");
                UserInterface.Menu();
            }
        }

        if (AnsiConsole.Confirm("Update start date?"))
        {
            shift.StartDate = AnsiConsole.Ask<DateOnly>("Start Date (Format: yyyy-MM-dd):");
            if (!Validation.IsDateValid(shift.StartDate))
            {
                Console.Clear();
                Console.WriteLine("Invalid date!\n");
                UserInterface.Menu();
            }
        }

        if (AnsiConsole.Confirm("Update end date?"))
        {
            shift.EndDate = AnsiConsole.Ask<DateOnly>("End Date (Format: yyyy-MM-dd):");
            if (!Validation.IsDateValid(shift.EndDate))
            {
                Console.Clear();
                Console.WriteLine("Invalid date!\n");
                UserInterface.Menu();
            }
        }

        if (AnsiConsole.Confirm("Update start time?"))
        {
            shift.StartTime = AnsiConsole.Ask<TimeOnly>("Start Time (Format: HH:mm):");
            if (!Validation.IsTimeValid(shift.StartTime, shift.StartDate))
            {
                Console.Clear();
                Console.WriteLine("Invalid time!\n");
                UserInterface.Menu();
            }
        }

        if (AnsiConsole.Confirm("Update end time?"))
        {
            shift.EndTime = AnsiConsole.Ask<TimeOnly>("End Time (Format: HH:mm):");
            if (!Validation.IsTimeValid(shift.EndTime, shift.EndDate))
            {
                Console.Clear();
                Console.WriteLine("Invalid time!\n");
                UserInterface.Menu();
            }
        }

        shift.Duration = shift.EndTime - shift.StartTime;

        Console.Clear();

        return shift;
    }
}
