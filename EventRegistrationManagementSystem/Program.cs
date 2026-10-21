using EventRegistrationManagementSystem.Models;
using EventRegistrationManagementSystem.Service;
class Program
{
    public static void Main(String[] args)
    {
        EventManagementService eventManagementService = new EventManagementService();
        Event createdEvent = eventManagementService.CreateEvent(
            1,
            "Seminar",
            "Seminar hall",
            new DateTime(2026, 10, 30),
            50,
            500
            );
        Console.WriteLine("Event Created!!");
        Console.WriteLine($"EventID : {createdEvent.EventId}");
        Console.WriteLine($"EventName : {createdEvent.EventName}");
        Console.WriteLine($"Venue : {createdEvent.Venue}");
        Console.WriteLine($"EventDate : {createdEvent.EventDate}");
        Console.WriteLine($"Capacity : {createdEvent.Capacity}");
        Console.WriteLine($"RegistrationFee : {createdEvent.RegistrationFee}");
        Console.WriteLine();

        List<Event> events = eventManagementService.GetAllEvents();
        foreach (var eve in events)
        {
            Console.WriteLine("Events");
            Console.WriteLine($"EventID : {eve.EventId}");
            Console.WriteLine($"EventName : {eve.EventName}");
            Console.WriteLine($"Venue : {eve.Venue}");
            Console.WriteLine($"EventDate : {eve.EventDate}");
            Console.WriteLine($"Capacity : {eve.Capacity}");
            Console.WriteLine($"RegistrationFee : {eve.RegistrationFee}");
        }
        Console.Write("Enter event name or venue to search: ");
        string searchText = Console.ReadLine();

        List<Event> searchedEvents = eventManagementService.SearchEvent(searchText);
        if (searchedEvents.Count > 0)
        {
            Console.WriteLine("Events found with the given name.");
        }
        else
        {
            Console.WriteLine("Not Found");
        }
     
    }
}
