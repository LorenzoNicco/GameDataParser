//Creo le dependency per app e log
var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    //Faccio partire l'app
    app.run();
}
catch(Exception ex)
{
    //In caso di errore generico, lo scrivo in un file di log
    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    logger.Log(ex);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();
