using GameDataParser.FileInteraction;
using GameDataParser.UserInteraction;
using System.Text.Json;

public class GameDataParserApp
{
    //Creo la dependency per l'interazione con l'utente
    private UserInteraction _userInteraction = new UserInteraction();
    //Creo la dependency per stampare i videogiochi
    private PrintLoadedGames _printLoadedGames = new PrintLoadedGames();
    //Inizializzo una flag per verificare che il file sia letto con successo
    bool FileReadFlag = false;
    //Variabile per salvare il file cercato
    string fetchFile = default;
    //Variabile per salvare il nome file inserito dall'utente
    string fileNameFromUser = default;

    //METODO DI FUNZIONAMENTO GENERALE DELL'APP
    public void run()
    {
        //La richiesta di un input dall'utente e la ricerca di un file con quel nome viene ripetuta finchè non esente da errori
        do
        {
            try
            {
                _userInteraction.AskUserAFileName();

                fileNameFromUser = _userInteraction.GetFileNameFromUser();

                fetchFile = File.ReadAllText(fileNameFromUser);

                //Se la ricerca trova un risultato, la flag diventa true e si esce dal loop
                FileReadFlag = true;
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("File name cannot be null.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("File name cannot be empty.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found.");
            }
        }
        while (!FileReadFlag);

        //Dichiaro una lista dove salvare i dati dei videogiochi
        List<VideoGame> videoGamesList = default;

        try
        {
            //Deserializzo il json trovato con la ricerca per estrarre la lista dei giochi
            videoGamesList = JsonSerializer.Deserialize<List<VideoGame>>(fetchFile);
        }
        //In caso di reperimento di un file json non valido
        catch(JsonException ex)
        {
            //Caratteri rossi
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"JSON in the {fileNameFromUser}  was not in a valid format. JSON body:");
            //Stampa del file non valido trovato
            Console.WriteLine(fetchFile);

            //Caratteri neri
            Console.ForegroundColor = ConsoleColor.White;

            throw new JsonException($"{ex.Message} The file is: {fileNameFromUser}", ex);
        }

        //Stampa dei videogiochi trovati
        _printLoadedGames.PrintGamesList(videoGamesList);
    }
}