using System;
using System.Text;

public class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public DateTime Date
    {
        get
        {
            return this.date;
        }

        private set
        {
            this.date = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }

        private set
        {
            this.title = value;
        }
    }

    public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                this.location = value;
            }
        }

    public int CompareTo(object someObject)
    {
        Event otherEvent = someObject as Event;
        int compareDate = this.date.CompareTo(otherEvent.date);
        int compareTitle = this.title.CompareTo(otherEvent.title);
        int compareLocation = this.location.CompareTo(otherEvent.location);
        if (compareDate == 0)
        {
            if (compareTitle == 0)
            {
                return compareLocation;
            }
            else
            {
                return compareTitle;
            }
        }
        else
        {
            return compareDate;
        }
    }

    public override string ToString()
    {
        StringBuilder resultString = new StringBuilder();
        resultString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        resultString.Append(" | " + this.title);
        if (this.location != null && this.location != string.Empty)
        {
            resultString.Append(" | " + this.location);
        }

        return resultString.ToString();
    }
}
