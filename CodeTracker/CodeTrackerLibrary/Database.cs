using Dapper;
using Microsoft.Data.Sqlite;

namespace CodeTrackerLibrary;

public static class Database
{
    private static string _connectionString { get; set; }

    public static void InitializeDatabase()
    {
       
        _connectionString = $"DataSource=CodingTracker.db";
        //Initialisation logic
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string createTable = @"CREATE TABLE IF NOT EXISTS CodingSessions (
        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
        Date TEXT NOT NULL ,
        StartTime TEXT NOT NULL,
        EndTime TEXT NOT NULL,
        Duration TEXT NOT NULL)";
            connection.Execute(createTable);
        }
    }

    public static void AddCodingSession(CodingSession codingSession)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();
        string command = @"INSERT INTO CodingSessions(Date,StartTime,EndTime,Duration) 
            VALUES (@Date, @StartTime, @EndTime, @Duration)";
        connection.Execute(command, new
        {
            Date = codingSession.StartTime.ToString("dd-mm-yyyy"),
            StartTime = codingSession.StartTime.ToString("HH:MM tt"),
            EndTime = codingSession.StartTime.ToString("HH:MM tt"),
            Duration = codingSession.DurationToString(),
        });
    }

    public static void GetCodingSessionRecord()
    {
        
    }

    public static void DeleteCodingSession()
    {
        
    }

    public static void UpdateCodingSession()
    {
        
    }

}