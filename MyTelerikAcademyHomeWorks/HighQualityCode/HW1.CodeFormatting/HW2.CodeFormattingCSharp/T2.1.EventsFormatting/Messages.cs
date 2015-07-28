using System.Text;

internal static class Messages
{
    private static readonly StringBuilder OutputMessage = new StringBuilder();

    public static string OutputString
    {
        get
        {
            return OutputMessage.ToString();
        }
    }

    public static void EventAdded()
    {
        OutputMessage.Append("Event added System.Environment.NewLine");
    }

    public static void EventDeleted(int eventsDeleted)
    {
        if (eventsDeleted == 0)
        {
            NoEventsFound();
        }
        else
        {
            OutputMessage.AppendFormat("{0} events deleted System.Environment.NewLine", eventsDeleted);
        }
    }

    public static void NoEventsFound()
    {
        OutputMessage.Append("No events found System.Environment.NewLine");
    }

    public static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            OutputMessage.Append(eventToPrint + "System.Environment.NewLine");
        }
    }
}
