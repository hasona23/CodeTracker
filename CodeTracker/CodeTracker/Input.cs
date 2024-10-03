using CodeTrackerLibrary;

namespace CodeTracker;

public class Input
{
    public CodingSession GetCodingSession()
    {
        DateTime day = GetDay();
        DateTime startTime = GetStartTime(day);
        DateTime endTime = GetEndTime(day,startTime);
        CodingSession codingSession = new CodingSession(startTime,endTime);
        Console.WriteLine($"Session Details: {codingSession}");
        Console.WriteLine("press enter to continue...");
        Console.ReadLine();
        return codingSession;
    }

    public DateTime GetEndTime(DateTime day , DateTime startTime)
    {
        DateTime endTime;
        Console.WriteLine("Enter ending time (HH:MM) or press enter for current time:");
        do
        {
            var readline = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(readline))
                endTime = DateTime.Now;
            else
            {
                DateTime.TryParse(readline, out endTime);
            }
            endTime = new DateTime(day.Year, day.Month, day.Day, endTime.Hour, endTime.Minute, endTime.Second);

        } while (endTime > DateTime.Now || endTime <= startTime || (endTime.Date - startTime.Date).Days >= 1);
        
        Console.WriteLine(endTime.ToString("g"));
        return endTime;
    }
    public DateTime GetStartTime(DateTime day)
    {
        DateTime startTime;
        Console.WriteLine("Enter starting time (HH:MM):");
        do
        {
            var readline = Console.ReadLine();
            DateTime.TryParse(readline, out startTime);
        } while (startTime > DateTime.Now || startTime <= DateTime.MinValue );
        startTime = new DateTime(day.Year, day.Month, day.Day, startTime.Hour, startTime.Minute, startTime.Second);
        Console.WriteLine(startTime.ToString("g"));
        return startTime;
    }
    public DateTime GetDay()
    {
        DateTime day;
        Console.WriteLine("Enter date (dd-mm-yyyy) or press any key to get current date.");
        do
        {
            var readline = Console.ReadLine();
            if (String.IsNullOrEmpty(readline))
                day = DateTime.Today;
            else
                DateTime.TryParse(readline, out day);
        } while (day <= DateTime.MinValue || day > DateTime.Now);

        return day;
    }
}