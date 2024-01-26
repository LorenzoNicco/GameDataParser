var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    app.run();
}
catch(Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    logger.Log(ex);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();
