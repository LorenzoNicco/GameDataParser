//CLASSE PER LA CREAZIONE DI UN LOG
public class Logger
{
    //Proprietà contenente il nome del file di log
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    //METODO PER LA CREAZIONE DEL LOG
    public void Log(Exception ex)
    {
        //Inizializzo la variabile contenente il messaggio di log
        var entry =
            $@"[{DateTime.Now}
            Exception message: {ex.Message}
            Stack trace: {ex.StackTrace}

            ]";

        //Scrivo il log nel file
        File.AppendAllText(_logFileName, entry);
    }
}