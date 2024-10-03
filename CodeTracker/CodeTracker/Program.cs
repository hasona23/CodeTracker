namespace CodeTracker;
using CodeTrackerLibrary;
class Program
{
    static void Main()
    { 
        Database.InitializeDatabase();
        Menu.Greeting();
        bool isRunning = true;
        var inputManager = new Input();
        while (isRunning)
        {
            switch (Menu.MainMenu())
            {
                case Options.SessionsHistory:
                    break;
                case Options.AddSession:
                    Database.AddCodingSession(inputManager.GetCodingSession());
                    break;
                case Options.RemoveSession:
                       break;
                case Options.UpdateSession:
                    break;
                case Options.Help:
                    Menu.HelpMenu();
                    break;
                case Options.Exit:
                    Console.WriteLine("----Thanks for using CodeTracker----");
                    isRunning = false;
                    break;
              
            }
            
        }
       
    }
}
