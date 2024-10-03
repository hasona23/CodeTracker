namespace CodeTrackerLibrary;

public class CodingSession
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Id { get; set; }


    public CodingSession(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
    public TimeSpan Duration()
    {
        return EndTime - StartTime;
    }

    public override string ToString()
    {
        return $"Start: {StartTime.ToString("g")}, End: {EndTime.ToString("g")}, Duration: {Duration().Hours}h : {Duration().Minutes}m";
    }

    public string DurationToString()
    {
        return $"Duration: {Duration().Hours}h : {Duration().Minutes}m";
    }
   
}