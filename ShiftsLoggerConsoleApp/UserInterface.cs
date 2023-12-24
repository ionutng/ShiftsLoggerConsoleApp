using Spectre.Console;
using static ShiftsLoggerConsoleApp.Enums;

namespace ShiftsLoggerConsoleApp;

internal static class UserInterface
{
    internal static void Menu()
    {
        while (true)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.ViewShifts,
                    MenuOptions.ViewShift,
                    MenuOptions.AddShift,
                    MenuOptions.UpdateShift,
                    MenuOptions.DeleteShift,
                    MenuOptions.Quit));

            switch (option)
            {
                case MenuOptions.ViewShifts:
                    ShiftsService.GetShifts();
                    break;
                case MenuOptions.ViewShift:
                    ShiftsService.GetShift();
                    break;
                case MenuOptions.AddShift:
                    ShiftsService.AddShift();
                    break;
                case MenuOptions.UpdateShift:
                    ShiftsService.UpdateShift();
                    break;
                case MenuOptions.DeleteShift:
                    ShiftsService.DeleteShift();
                    break;
                case MenuOptions.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    internal static void ShowShifts(List<Shift> shifts)
    {
        Console.Clear();

        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Date");
        table.AddColumn("Time");
        table.AddColumn("Duration");

        foreach (var shift in shifts)
            table.AddRow(
                shift.ShiftId.ToString(),
                shift.FirstName + " " + shift.LastName,
                shift.StartDate + " - " + shift.EndDate,
                shift.StartTime + " - " + shift.EndTime,
                shift.Duration.ToString());

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    internal static void ShowShift(Shift shift)
    {
        var panel = new Panel(
            $"Id: {shift.ShiftId}" +
            $"\nName: {shift.FirstName + " " + shift.LastName}" +
            $"\nDate: {shift.StartDate + " - " + shift.EndDate}" +
            $"\nTime: {shift.StartTime + " - " + shift.EndTime}" +
            $"\nDuration: {shift.Duration}")
        {
            Header = new PanelHeader("Shift Info"),
            Padding = new Padding(2, 2, 2, 2)
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to go back to the menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
