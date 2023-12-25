using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace ShiftsLoggerConsoleApp;

internal static class ShiftsService
{
    internal static List<Shift> GetShifts()
    {
        try
        {
            var client = new RestClient("https://localhost:7290/");
            var request = new RestRequest("api/Shifts");
            var response = client.Get(request);

            List<Shift> shifts = JsonConvert.DeserializeObject<List<Shift>>(response.Content);

            UserInterface.ShowShifts(shifts);

            return shifts;
        } catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message + "\n");
            UserInterface.Menu();
        }

        return [];
    }

    internal static void GetShift()
    {
        try
        {
            string shiftId = ShiftsHelper.GetShiftId();

            var client = new RestClient("https://localhost:7290/");
            var request = new RestRequest($"api/Shifts/{HttpUtility.UrlEncode(shiftId)}");
            var response = client.Get(request);

            Shift shift = JsonConvert.DeserializeObject<Shift>(response.Content);

            UserInterface.ShowShift(shift);
        } catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message + "\n");
            UserInterface.Menu();
        }
    }

    internal static void AddShift()
    {
        try
        {
            var shift = ShiftsHelper.GetShiftInput();

            var client = new RestClient("https://localhost:7290/");
            var request = new RestRequest("api/Shifts");

            request.AddJsonBody(shift);

            var response = client.Post(request);
        } catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message + "\n");
            UserInterface.Menu();
        }
    }

    internal static void UpdateShift()
    {
        try
        {
            string shiftId = ShiftsHelper.GetShiftId();

            var client = new RestClient("https://localhost:7290/");
            var request = new RestRequest($"api/Shifts/{HttpUtility.UrlEncode(shiftId)}");
            var response = client.Get(request);

            Shift shift = JsonConvert.DeserializeObject<Shift>(response.Content);

            shift = ShiftsHelper.UpdateShift(shift);

            request.AddJsonBody(shift);

            var response2 = client.ExecutePut(request);
        } catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message + "\n");
            UserInterface.Menu();
        }
    }

    internal static void DeleteShift()
    {
        try
        {
            string shiftId = ShiftsHelper.GetShiftId();

            var client = new RestClient("https://localhost:7290/");
            var request = new RestRequest($"api/Shifts/{HttpUtility.UrlEncode(shiftId)}");

            var response = client.Delete(request);
        } catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message + "\n");
            UserInterface.Menu();
        }
    }
}
