using System;
using System.Text;
using Wintellect.PowerCollections;

namespace Events
{
    public class Events
    {
        private static StringBuilder eventsOutput = new StringBuilder();
        private static EventHolder events = new EventHolder();

        public static void Main()
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(eventsOutput);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            switch (command[0])
            {
                case 'A':
                    AddEvent(command);
                    return true;
                case 'D':
                    DeleteEvents(command);
                    return true;
                case 'L':
                    ListEvents(command);
                    return true;
                case 'E':
                default:
                    return false;
            }
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            events.PrintEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            events.RemoveEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, "AddEvent", out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }

        public static class Messages
        {
            public static void EventAdded()
            {
                eventsOutput.Append("Event added\n");
            }

            public static void EventRemoved(int removedEventsCount)
            {
                if (removedEventsCount == 0)
                {
                    NoEventsFound();
                }
                else
                {
                    eventsOutput.AppendFormat("{0} events removed\n", removedEventsCount);
                }
            }

            public static void NoEventsFound()
            {
                eventsOutput.Append("No events found\n");
            }

            public static void PrintEvent(Event eventToPrint)
            {
                if (eventToPrint != null)
                {
                    eventsOutput.Append(eventToPrint + "\n");
                }
            }
        }

        public class EventHolder
        {
            private MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);

            private OrderedBag<Event> eventsByDate = new OrderedBag<Event>();

            public void AddEvent(DateTime date, string title, string location)
            {
                Event newEvent = new Event(date, title, location);
                this.eventsByTitle.Add(title.ToLower(), newEvent);
                this.eventsByDate.Add(newEvent);
                Messages.EventAdded();
            }

            public void RemoveEvents(string titleToRemove)
            {
                string title = titleToRemove.ToLower();
                int removed = 0;
                foreach (var eventToRemove in this.eventsByTitle[title])
                {
                    removed++;
                    this.eventsByDate.Remove(eventToRemove);
                }

                this.eventsByTitle.Remove(title);
                Messages.EventRemoved(removed);
            }

            public void PrintEvents(DateTime date, int count)
            {
                OrderedBag<Event>.View eventsToPrint = this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
                int printed = 0;
                foreach (var eventToPrint in eventsToPrint)
                {
                    if (printed == count)
                    {
                        break;
                    }

                    Messages.PrintEvent(eventToPrint);
                    printed++;
                }

                if (printed == 0)
                {
                    Messages.NoEventsFound();
                }
            }
        }
    }
}
