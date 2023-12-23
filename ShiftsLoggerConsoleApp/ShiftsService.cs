using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace ShiftsLoggerConsoleApp;

internal static class ShiftsService
{
    internal static List<Shift> GetShifts()
    {
        var client = new RestClient("https://localhost:7290/");
        var request = new RestRequest("api/Shifts");
        var response = client.Get(request);

        List<Shift> shifts = JsonConvert.DeserializeObject<List<Shift>>(response.Content);

        UserInterface.ShowShifts(shifts);

        return shifts;
    }

    internal static void GetShift(string shiftId)
    {
        var client = new RestClient("https://localhost:7290/");
        var request = new RestRequest($"api/Shifts/{HttpUtility.UrlEncode(shiftId)}");
        var response = client.Get(request);

        Shift shift = JsonConvert.DeserializeObject<Shift>(response.Content);

        UserInterface.ShowShift(shift);
    }
}
