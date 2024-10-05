using System.Globalization;
using CodeTrackerLibrary;

namespace CodeTracker;

public class Input
{
    public CodingSession GetCodingSession()
    {
        DateTime day = GetDay();
        DateTime startTime = GetStartTime(day);
        DateTime endTime = GetEndTime(day,startTime);
        CodingSession codingSession = new CodingSession(startTime,endTime,GetDescription());
        Console.WriteLine($"Session Details: {codingSession}");
        Console.WriteLine("press enter to continue...");
        Console.ReadLine();
        return codingSession;
    }

    public string GetDescription()
    {
        string description = "";
        Console.WriteLine("Please enter a description : (language , task , project name)");
        do
        {
            description = Console.ReadLine();
           
        }while(String.IsNullOrEmpty(description));
        return description;
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
        } while ((startTime > DateTime.Now && day.Date == DateTime.Today) || startTime <= DateTime.MinValue );
        startTime = new DateTime(day.Year, day.Month, day.Day, startTime.Hour, startTime.Minute, startTime.Second);
        Console.WriteLine(startTime.ToString("g"));
        return startTime;
    }

    public DateTime GetOptionalDate()
    {
        
        DateTime date;
                    
        do
        {
            var readLine = Console.ReadLine();
            if (String.IsNullOrEmpty(readLine))
            {
                date = DateTime.MinValue;
                break;
            }
            if (DateTime.TryParseExact(readLine,CodingSession.DayFormat,CultureInfo.InvariantCulture,DateTimeStyles.None,out date))
            {
                break;
            }
        } while (true);

        return date;
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
                DateTime.TryParseExact(readline, "d-M-yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out day);
        } while (day <= DateTime.MinValue || day > DateTime.Now);

        Console.WriteLine(day.ToString(CodingSession.DayFormat));
        Console.ReadLine();
        return day;
    }

   
    
}