using System;
using System.Text;

namespace Events
{
    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event anotherEvent = obj as Event;
            int compareByDate = this.Date.CompareTo(anotherEvent.Date);
            int compareByTitle = this.Title.CompareTo(anotherEvent.Title);
            int compareByLocation = this.Location.CompareTo(anotherEvent.Location);

            if(compareByDate == 0)
            {
                if(compareByTitle == 0)
                {
                    return compareByLocation;
                }                    
                else
                {
                    return compareByTitle;
                }
            }
            else
            {
                return compareByDate;
            }       
        }

        public override string ToString()
        {
            StringBuilder eventData = new StringBuilder();
            eventData.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            eventData.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                eventData.Append(" | " + this.Location);
            }

            return eventData.ToString();
        }
    }
}
